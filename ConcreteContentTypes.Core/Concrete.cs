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
using System.IO;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Compilation;
using ConcreteContentTypes.Core.Templates.Classes;
using ConcreteContentTypes.Core.FileWriters;

namespace ConcreteContentTypes.Core
{
	public class Concrete
	{
		#region Private Variables

		IContentTypeService _contentTypeService;

		string _contentTypeNameSpace;
		string _contentTypeCSharpOutputFolder;

		string _contentTypeServiceNameSpace;
		string _contentTypeServiceCSharpOutputFolder;

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

			_contentTypeServiceNameSpace = ConcreteSettings.Current.Namespace + ".Services";
			_contentTypeServiceCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder + "\\Services";

			_mediaTypeNameSpace = ConcreteSettings.Current.Namespace + ".Media";
			_mediaTypeCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder + "\\Media";

			_assemblyOutputDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyOutputDirectory;
			_assemblyDependencyDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyDependencyDirectory;
			_classDefinitions = new List<ClassDefinitionBase>();
		}

		#endregion

		#region Public Methods

		public void BuildServiceClasses(List<ModelClassDefinition> modelClasses)
		{
			CSharpServiceBaseClassFileWriter serviceBaseWriter = new CSharpServiceBaseClassFileWriter(_contentTypeServiceNameSpace);
			serviceBaseWriter.WriteFile(_contentTypeServiceCSharpOutputFolder);

			foreach (var model in modelClasses)
			{
				CSharpServiceClassFileWriter serviceWriter = new CSharpServiceClassFileWriter(model, _contentTypeServiceNameSpace);
				serviceWriter.WriteClass(_contentTypeServiceCSharpOutputFolder);
			}
		}

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
		public List<ModelClassDefinition> BuildContentTypes()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			return BuildContentTypes(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed ContentTypes
		/// </summary>
		public List<ModelClassDefinition> BuildContentTypes(IEnumerable<IContentType> contentTypes)
		{
			if (ConcreteSettings.Current.Enabled)
				return CreateCSharp(contentTypes);

			return new List<ModelClassDefinition>();
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

		private List<ModelClassDefinition> CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			List<ModelClassDefinition> modelClasses = new List<ModelClassDefinition>();

			//Create our base class definition and add to global list of generated classes
			UmbracoContentClassDefinition baseClassDefintion = new UmbracoContentClassDefinition("UmbracoContent", _contentTypeNameSpace, Models.Enums.ContentType.Content);
			_classDefinitions.Add(baseClassDefintion);

			//Notify subscribers that base class is about to be generated
			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefintion, Models.Enums.ContentType.Content);

			//Write base class .cs file
			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefintion);
			baseClassWriter.WriteBaseClass(_contentTypeCSharpOutputFolder);

			//Create classes for all passed content types
			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				//Create model class definition from ContentType and add to list of defintions we return
				ModelClassDefinition classDefinition = new ModelClassDefinition(contentType, parent, _contentTypeNameSpace, Models.Enums.ContentType.Content, "UmbracoContent");
				classDefinition.UsingNamespaces.Add(_mediaTypeNameSpace);
				modelClasses.Add(classDefinition);

				//Notify subscribers that model class is about to be generated
				ConcreteEvents.RaiseModelClassGenerating(classDefinition, Models.Enums.ContentType.Content);

				//Write model class .cs file
				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_contentTypeCSharpOutputFolder);
			}

			//Add our model classes to global list of generated classes
			_classDefinitions.AddRange(modelClasses);

			return modelClasses;
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
