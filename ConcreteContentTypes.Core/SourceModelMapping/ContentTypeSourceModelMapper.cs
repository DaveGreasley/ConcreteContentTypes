using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	public class ContentTypeSourceModelMapper : SourceModelMapperBase, ISourceModelMapper
	{
		string Namespace { get { return string.Format(CultureInfo.InvariantCulture, "{0}.Content", this.Settings.Namespace); } }

		IEnumerable<IContentType> ContentTypes { get; set; }

		public ContentTypeSourceModelMapper(
			IConcreteSettings settings,
			IConcreteEvents events, 
			IEnumerable<IContentType> contentTypes
			)
			: base(settings, events, contentTypes)
		{
			this.ContentTypes = contentTypes;
		}

		public IBaseClassDefinition GetBaseClassDefinition()
		{
			var baseClassDefinition = new BaseClassDefinition("UmbracoContent", this.Namespace, PublishedItemType.Content);
			baseClassDefinition.Properties = GetBaseClassProperties();

			this.Events.RaiseContentBaseClassGenerating(baseClassDefinition);

			return baseClassDefinition;
		}

		public IEnumerable<IModelClassDefinition> GetModelClassDefinitions()
		{
			List<ModelClassDefinition> classDefinitions = new List<ModelClassDefinition>();

			foreach (var contentType in this.ContentTypes)
			{
				ModelClassDefinition definition = new ModelClassDefinition(
					NamingConventionHelper.GetConventionalName(contentType.Name),
					this.Namespace);

				definition.Properties = GetProperties(definition, contentType, PublishedItemType.Content);
				definition.BaseClass = GetBaseClass(contentType, GetParent(contentType), "UmbracoContent");
				definition.ChildType = GetChildType(contentType);

				this.Events.RaiseContentModelClassGenerating(definition);

				classDefinitions.Add(definition);
			}

			return classDefinitions;
		}
	}
}
