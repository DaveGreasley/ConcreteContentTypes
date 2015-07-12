using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.FileWriters;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.ModelGeneration.Generators
{
	public class ContentTypeModelsGenerator : ModelsGeneratorBase
	{
		public ContentTypeModelsGenerator()
		{
			_cSharpOutputFolder = string.Format("{0}\\Content", _cSharpOutputFolderBase);
		}

		public override void GenerateModels()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			BuildContentTypes(typesToBuild);
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

		private List<ModelClassDefinition> CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			List<ModelClassDefinition> modelClasses = new List<ModelClassDefinition>();

			//Create our base class definition and add to global list of generated classes
			UmbracoContentClassDefinition baseClassDefintion = new UmbracoContentClassDefinition("UmbracoContent", _contentTypeNameSpace, PublishedItemType.Content);
			_classDefinitions.Add(baseClassDefintion);

			//Notify subscribers that base class is about to be generated
			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefintion, PublishedItemType.Content);

			//Write base class .cs file
			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefintion);
			baseClassWriter.WriteBaseClass(_cSharpOutputFolder);

			//Create classes for all passed content types
			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				//Create model class definition from ContentType and add to list of defintions we return
				ModelClassDefinition classDefinition = new ModelClassDefinition(contentType, parent, _contentTypeNameSpace, PublishedItemType.Content, "UmbracoContent");
				classDefinition.UsingNamespaces.Add(_mediaTypeNameSpace);
				modelClasses.Add(classDefinition);

				//Notify subscribers that model class is about to be generated
				ConcreteEvents.RaiseModelClassGenerating(classDefinition, PublishedItemType.Content);

				//Write model class .cs file
				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_cSharpOutputFolder);
			}

			//Add our model classes to global list of generated classes
			_classDefinitions.AddRange(modelClasses);

			return modelClasses;
		}
	}
}
