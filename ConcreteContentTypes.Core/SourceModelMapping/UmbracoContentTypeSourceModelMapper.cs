using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public class UmbracoContentTypeSourceModelMapper : UmbracoSourceModelMapperBase, ISourceModelMapper
	{
		public string Namespace { get { return string.Format("{0}.Content", this.Settings.Namespace); } }

		public IEnumerable<IContentType> ContentTypes { get; set; }

		public UmbracoContentTypeSourceModelMapper(
			IConcreteSettings settings,
			IConcreteEvents events, 
			IEnumerable<IContentType> contentTypes
			)
			: base(settings, events, contentTypes)
		{
			this.ContentTypes = contentTypes;
		}

		public UmbracoBaseClassDefinition GetBaseClassDefinition()
		{
			var baseClassDefinition = new UmbracoBaseClassDefinition("UmbracoContent", this.Namespace);
			baseClassDefinition.Properties = GetBaseClassProperties();

			this.Events.RaiseContentBaseClassGenerating(baseClassDefinition);

			return baseClassDefinition;
		}

		public IEnumerable<UmbracoModelClassDefinition> GetModelClassDefinitions()
		{
			List<UmbracoModelClassDefinition> classDefinitions = new List<UmbracoModelClassDefinition>();

			foreach (var contentType in this.ContentTypes)
			{
				UmbracoModelClassDefinition definition = new UmbracoModelClassDefinition(
					NamingConventionHelper.GetConventionalName(contentType.Name),
					this.Namespace);

				definition.Properties = GetProperties(definition, contentType, PublishedItemType.Content);
				definition.BaseClass = GetBaseClass(contentType, GetParent(contentType), "UmbracoContent");

				this.Events.RaiseContentModelClassGenerating(definition);

				classDefinitions.Add(definition);
			}

			return classDefinitions;
		}
	}
}
