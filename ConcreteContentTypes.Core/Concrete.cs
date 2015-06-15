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
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using ConcreteContentTypes.Core.Templates;
using System.IO;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Compilation;

namespace ConcreteContentTypes.Core
{
	public class Concrete
	{
		#region Private Variables

		IContentTypeService _contentTypeService;

		string _contentTypeNameSpace;
		string _contentTypeCSharpOutputFolder;
		string _mediaTypeNameSpace;
		string _mediaTypeCSharpOutputFolder;

		string _assemblyOutputDirectory;
		string _assemblyDependencyDirectory;

		List<ClassDefinitionBase> _classDefinitions;

		#endregion

		#region Constructor

		public Concrete()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;

			_contentTypeNameSpace = ConcreteSettings.Current.Namespace + ".Content";
			_contentTypeCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder + "\\Content";

			_mediaTypeNameSpace = ConcreteSettings.Current.Namespace + ".Media";
			_mediaTypeCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder + "\\Media";

			_assemblyOutputDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyOutputDirectory;
			_assemblyDependencyDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyDependencyDirectory;
			_classDefinitions = new List<ClassDefinitionBase>();
		}

		#endregion

		#region Public Methods

		public void BuildMediaTypes()
		{
			var mediaTypes = _contentTypeService.GetAllMediaTypes();

			BuildMediaTypes(mediaTypes);
		}

		public void BuildMediaTypes(IEnumerable<IMediaType> mediaTypes)
		{
			if (ConcreteSettings.Current.Enabled)
			{
				CreateCSharp(mediaTypes);
			}
		}

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
			if (ConcreteSettings.Current.Enabled)
			{
				CreateCSharp(contentTypes);
			}
		}


		public void BuildAssembly()
		{
			if (ConcreteSettings.Current.Enabled && ConcreteSettings.Current.AssemblyGeneration)
			{
				AssemblyBuilder builder = new AssemblyBuilder();
				builder.CreateAssembly(
					_contentTypeCSharpOutputFolder,
					_assemblyOutputDirectory,
					ConcreteSettings.Current.AssemblyName,
					_assemblyDependencyDirectory,
					GetDependentAssemblies());
			}
		}

		#endregion

		#region Private Methods

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			UmbracoContentClassDefinition baseClassDefintion = new UmbracoContentClassDefinition("UmbracoContent", _contentTypeNameSpace, Models.Enums.ContentType.Content);
			_classDefinitions.Add(baseClassDefintion);

			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefintion, Models.Enums.ContentType.Content);

			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefintion);
			baseClassWriter.WriteBaseClass(_contentTypeCSharpOutputFolder);

			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				ModelClassDefinition classDefinition = new ModelClassDefinition(contentType, parent, _contentTypeNameSpace, Models.Enums.ContentType.Content, "UmbracoContent");
				_classDefinitions.Add(classDefinition);
				classDefinition.UsingNamespaces.Add(_mediaTypeNameSpace);

				ConcreteEvents.RaiseModelClassGenerating(classDefinition, Models.Enums.ContentType.Content);

				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_contentTypeCSharpOutputFolder);
			}
		}

		private void CreateCSharp(IEnumerable<IMediaType> mediaTypes)
		{
			UmbracoContentClassDefinition baseClassDefinition = new UmbracoContentClassDefinition("UmbracoMedia", _mediaTypeNameSpace, Models.Enums.ContentType.Media);
			_classDefinitions.Add(baseClassDefinition);

			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefinition, Models.Enums.ContentType.Media);

			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefinition);
			baseClassWriter.WriteBaseClass(_mediaTypeCSharpOutputFolder);

			foreach (IMediaType mediaType in mediaTypes)
			{
				var parent = mediaTypes.FirstOrDefault(x => x.Id == mediaType.ParentId);

				ModelClassDefinition classDefinition = new ModelClassDefinition(mediaType, parent, _mediaTypeNameSpace, Models.Enums.ContentType.Media, "UmbracoMedia");
				_classDefinitions.Add(classDefinition);

				ConcreteEvents.RaiseModelClassGenerating(classDefinition, Models.Enums.ContentType.Media);

				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_mediaTypeCSharpOutputFolder);
			}
		}

		private List<string> GetDependentAssemblies()
		{
			List<string> assemblies = new List<string>();

			foreach (var c in _classDefinitions)
			{
				foreach (var assembly in c.DependantAssemblies)
				{
					if (!assemblies.Contains(assembly))
						assemblies.Add(assembly);
				}
			}

			return assemblies;
		}

		#endregion
	}
}
