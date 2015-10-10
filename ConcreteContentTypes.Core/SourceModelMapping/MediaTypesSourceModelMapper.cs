using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.SourceModelMapping.TypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public class MediaTypesSourceModelMapper : SourceModelMapperBase, ISourceModelMapper
	{
		string Namespace { get { return string.Format("{0}.Media", this.Settings.Namespace); } }

		IEnumerable<IMediaType> MediaTypes { get; set; }

		public MediaTypesSourceModelMapper(
			IConcreteSettings settings,
			IConcreteEvents events,
			IEnumerable<IMediaType> mediaTypes,
			IPropertyTypeResolverFactory propertyTypeResolverFactory,
			IPropertyTypeDefaultsSettings propertySettings
			)
			: base(settings, events, mediaTypes, propertyTypeResolverFactory, propertySettings)
		{
			this.MediaTypes = mediaTypes;
		}

		public IBaseClassDefinition GetBaseClassDefinition()
		{
			var baseClassDefinition = new BaseClassDefinition("UmbracoMedia", this.Namespace, PublishedItemType.Media);
			baseClassDefinition.Properties = GetBaseClassProperties();

			this.Events.RaiseMediaBaseClassGenerating(baseClassDefinition);

			return baseClassDefinition;
		}

		public IEnumerable<IModelClassDefinition> GetModelClassDefinitions()
		{
			List<IModelClassDefinition> classDefinitions = new List<IModelClassDefinition>();

			foreach (var mediaType in this.MediaTypes)
			{
				ModelClassDefinition definition = new ModelClassDefinition(
					NamingConventionHelper.GetConventionalName(mediaType.Name),
					this.Namespace
					);
				definition.Properties = GetProperties(definition, mediaType, PublishedItemType.Media);
				definition.BaseClass = GetBaseClass(mediaType, GetParent(mediaType), "UmbracoMedia");
				definition.ChildType = GetChildType(mediaType);

				this.Events.RaiseMediaModelClassGenerating(definition);

				classDefinitions.Add(definition);
			}

			return classDefinitions;
		}
	}
}
