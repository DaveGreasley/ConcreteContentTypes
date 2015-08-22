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

namespace ConcreteContentTypes.Core.ModelGeneration.Generators
{
	public class MediaTypeModelsGenerator : ModelsGeneratorBase
	{
		public MediaTypeModelsGenerator()
		{
			_cSharpOutputFolder = string.Format("{0}\\Media", _cSharpOutputFolderBase);
		}

		public override void GenerateModels()
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

		private void CreateCSharp(IEnumerable<IMediaType> mediaTypes)
		{
			UmbracoContentClassDefinition baseClassDefinition = new UmbracoContentClassDefinition("UmbracoMedia", _mediaTypeNameSpace, PublishedItemType.Media);
			_classDefinitions.Add(baseClassDefinition);

			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefinition, PublishedItemType.Media);

			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefinition);
			baseClassWriter.WriteBaseClass(_cSharpOutputFolder);

			foreach (IMediaType mediaType in mediaTypes)
			{
				var parent = mediaTypes.FirstOrDefault(x => x.Id == mediaType.ParentId);

				ModelClassDefinition classDefinition = new ModelClassDefinition(mediaType, parent, _mediaTypeNameSpace, PublishedItemType.Media, "UmbracoMedia");
				_classDefinitions.Add(classDefinition);

				ConcreteEvents.RaiseModelClassGenerating(classDefinition, PublishedItemType.Media);

				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_cSharpOutputFolder);
			}
		}
	}
}
