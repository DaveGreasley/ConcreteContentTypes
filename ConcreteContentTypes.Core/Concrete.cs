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
using ConcreteContentTypes.Core.PropertyTypeCSharpWriters;
using ConcreteContentTypes.Core.Templates;
using System.IO;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models;

namespace ConcreteContentTypes.Core
{
	public class Concrete
	{
		#region Private Variables

		IContentTypeService _contentTypeService;

		string _contentTypeNameSpace;
		string _contentTypeCSharpOutputFolder;

		string _assemblyOutputFolder;

		#endregion

		#region Constructor

		public Concrete()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;

			_contentTypeNameSpace = Settings.Current.Namespace;
			_contentTypeCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + Settings.Current.CSharpOutputFolder;

			_assemblyOutputFolder = AppDomain.CurrentDomain.BaseDirectory + Settings.Current.AssemblyOutputFolder;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Updates or creates C# files for all ContentTypes
		/// </summary>
		public void BuildContentTypes()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			BuildContentTypes(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed ContentTypes
		/// </summary>
		public void BuildContentTypes(IEnumerable<IContentType> contentTypes)
		{
			if (Settings.Current.Enabled)
			{
				CreateCSharp(contentTypes);
			}
		}

		/// <summary>
		/// Compiles the generated C# files into a DLL. Doesn't really work, not sure why I wrote this...
		/// </summary>
		public void BuildAssembly()
		{
			AssemblyBuilder assemblyBuilder = new AssemblyBuilder();
			assemblyBuilder.CreateAssembly(
				_contentTypeCSharpOutputFolder,
				_assemblyOutputFolder,
				Settings.Current.AssemblyName);
		}

		#endregion

		#region Private Methods

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				ClassDefinition classDefinition = new ClassDefinition(contentType, parent, _contentTypeNameSpace, "UmbracoContent");
				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteFile(_contentTypeCSharpOutputFolder);
			}
		}

		#endregion
	}
}
