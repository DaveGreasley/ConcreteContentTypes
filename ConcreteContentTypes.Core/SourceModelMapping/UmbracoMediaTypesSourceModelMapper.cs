using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public class UmbracoMediaTypesSourceModelMapper : UmbracoSourceModelMapperBase, ISourceModelMapper
	{
		public string Namespace { get { return string.Format("{0}.Media", this.Settings.Namespace); } }

		public IEnumerable<IMediaType> MediaTypes { get; private set; }

		public UmbracoMediaTypesSourceModelMapper(
			IConcreteSettings settings,
			IConcreteEvents events,
			IEnumerable<IMediaType> mediaTypes
			)
			: base(settings, events, mediaTypes)
		{
			this.MediaTypes = mediaTypes;
		}

		public UmbracoBaseClassDefinition GetBaseClassDefinition()
		{
			var baseClassDefinition = new UmbracoBaseClassDefinition("UmbracoMedia", this.Namespace);
			baseClassDefinition.Properties = GetBaseClassProperties();

			this.Events.RaiseMediaBaseClassGenerating(baseClassDefinition);

			return baseClassDefinition;
		}

		public IEnumerable<UmbracoModelClassDefinition> GetModelClassDefinitions()
		{
			List<UmbracoModelClassDefinition> classDefinitions = new List<UmbracoModelClassDefinition>();

			foreach (var mediaType in this.MediaTypes)
			{
				UmbracoModelClassDefinition definition = new UmbracoModelClassDefinition(
					NamingConventionHelper.GetConventionalName(mediaType.Name),
					this.Namespace
					);
				definition.Properties = GetProperties(definition, mediaType, PublishedItemType.Media);
				definition.BaseClass = GetBaseClass(mediaType, GetParent(mediaType), "UmbracoMedia");

				this.Events.RaiseMediaModelClassGenerating(definition);

				classDefinitions.Add(definition);
			}

			return classDefinitions;
		}
	}
}
