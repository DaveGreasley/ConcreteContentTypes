using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.ModelGeneration.FileWriters;
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
		public void BuildContentTypes(IEnumerable<IContentType> contentTypes)
		{
			if (ConcreteSettings.Current.Enabled)
				CreateCSharp(contentTypes);
		}

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			//Create our base class definition 
			UmbracoContentClassDefinition baseClassDefintion = new UmbracoContentClassDefinition("UmbracoContent", _contentTypeNameSpace, PublishedItemType.Content);

			//Notify subscribers that base class is about to be generated
			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefintion, PublishedItemType.Content);

			//Write base class .cs file
			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefintion);
			baseClassWriter.WriteBaseClass(_cSharpOutputFolder);

			//Create classes for all passed content types
			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				//Create model class definition from ContentType
				ContentModelClassDefinition classDefinition = new ContentModelClassDefinition(contentType, parent, _contentTypeNameSpace, "UmbracoContent");
				//Make sure we add the namespace of our media models to the generated class so we can reference Media models by name
				classDefinition.AddUsingNamespace(_mediaTypeNameSpace);

				//Notify subscribers that model class is about to be generated
				ConcreteEvents.RaiseModelClassGenerating(classDefinition, PublishedItemType.Content);

				//Write model class .cs file
				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_cSharpOutputFolder);
			}
		}
	}
}
