using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.ModelGeneration.Generators
{
	public abstract class ModelsGeneratorBase
	{
		protected IContentTypeService _contentTypeService;

		protected string _cSharpOutputFolderBase;
		protected string _cSharpOutputFolder;
		protected string _contentTypeNameSpace;
		protected string _mediaTypeNameSpace;

		string _assemblyOutputDirectory;
		string _assemblyDependencyDirectory;

		protected List<ClassDefinitionBase> _classDefinitions;

		public ModelsGeneratorBase()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;

			_cSharpOutputFolderBase = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder;

			_contentTypeNameSpace = ConcreteSettings.Current.Namespace + ".Content";
			_mediaTypeNameSpace = ConcreteSettings.Current.Namespace + ".Media";

			_assemblyOutputDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyOutputDirectory;
			_assemblyDependencyDirectory = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.AssemblyDependencyDirectory;

			_classDefinitions = new List<ClassDefinitionBase>();
		}

		public abstract void GenerateModels();
	}
}
