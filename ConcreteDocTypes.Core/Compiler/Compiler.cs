using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using System.CodeDom.Compiler;
using ConcreteContentTypes.Core.Configuration;
using Umbraco.Core.Services;
using Umbraco.Web;
using System.Web;
using ConcreteContentTypes.Core.PropertyTypeResolution;
using ConcreteContentTypes.Core.Templates;

namespace ConcreteContentTypes.Core.Compiler
{
	public class Compiler
	{
		#region Private Variables

		IContentTypeService _contentTypeService;

		#endregion

		#region Constructor

		public Compiler()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Updates or creates C# files for all ContentTypes and then recompiles the assembly.
		/// </summary>
		public void Build()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			Build(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed ContentTypes and then recompiles the assembly.
		/// </summary>
		public void Build(IEnumerable<IContentType> contentTypes)
		{
			if (Settings.Current.Enabled)
			{
				CreateCSharp(contentTypes);
				BuildAssembly();
			}
		}

		#endregion

		#region Private Methods

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			CreateBaseClass();

			foreach (IContentType contentType in contentTypes)
			{
				ClassDefinition classDefinition = new ClassDefinition(contentType, Settings.Current.Namespace, Settings.Current.BaseClassName);
				CSharpWriter writer = new CSharpWriter(classDefinition);
				writer.WriteFile(Settings.Current.CSharpOutputFolder);
			}
		}

		private void CreateBaseClass()
		{
			UmbracoContentClassTemplate baseClassTemplate = new UmbracoContentClassTemplate(Settings.Current.Namespace, Settings.Current.BaseClassName);
			string cs = baseClassTemplate.TransformText();

			string fileName = string.Format("{0}.cs", Settings.Current.BaseClassName);

			string folder = Settings.Current.CSharpOutputFolder;

			if (!folder.EndsWith(@"\"))
				folder += @"\";

			string fullPath = string.Format("{0}{1}", folder, fileName);

			System.IO.File.WriteAllText(fullPath, cs);
		}

		private void BuildAssembly()
		{
			AssemblyBuilder assemblyBuilder = new AssemblyBuilder();
			assemblyBuilder.CreateAssembly(
				Settings.Current.CSharpOutputFolder,
				Settings.Current.AssemblyOutputFolder,
				Settings.Current.AssemblyName);
		}

		#endregion
	}
}
