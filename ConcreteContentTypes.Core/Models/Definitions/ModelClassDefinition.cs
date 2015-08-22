﻿using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ModelClassDefinition : ClassDefinitionBase
	{
		public string BaseClass { get; set; }
		public bool HasBaseClass { get { return !string.IsNullOrEmpty(this.BaseClass); } }
		public string ChildType { get; set; }
		public bool HasConcreteChildType { get { return !string.IsNullOrEmpty(this.ChildType) && this.ChildType != "IPublishedContent"; } }

		public ModelClassDefinition(IMediaType mediaType, IMediaType parent, string nameSpace, PublishedItemType contentType, string defaultBaseClass = "")
			: base(mediaType.Alias, nameSpace, contentType)
		{
			this.BaseClass = GetBaseClass(mediaType, parent, defaultBaseClass);
			this.Properties = new List<PropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();
			this.ChildType = GetChildType(mediaType);

			CreateDefinition(mediaType, parent);
		}

		public ModelClassDefinition(IContentType contentType, IContentType parent, string nameSpace, PublishedItemType type, string defaultBaseClass = "")
			: base(contentType.Alias, nameSpace, type)
		{
			this.BaseClass = GetBaseClass(contentType, parent, defaultBaseClass);
			this.Properties = new List<PropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();
			this.ChildType = GetChildType(contentType);

			CreateDefinition(contentType, parent);
		}

		private void CreateDefinition(IContentTypeComposition contentType, IContentTypeComposition parent)
		{
			IEnumerable<PropertyType> propertyTypes = GetPropertyTypesNotDeclaredOnParent(contentType, parent);

			foreach (var propertyType in propertyTypes)
			{
				// Check that we support the property type
				if (CSharpWriterSettings.Current.Writers.Any(x => x.SupportedTypes.Any(s => s.Alias == propertyType.PropertyEditorAlias)))
				{
					var ptd = new PropertyDefinition(propertyType);

					// See if we can work out the Clr Type from any configured PropertyValueConverter
					PropertyValueConverterHelper tch = new PropertyValueConverterHelper(contentType, propertyType, this.PublishedItemType);
					if (tch.CanResolveType)
					{
						ptd.ClrType = tch.GetTypeName();
						AddUsingNamespace(tch.GetNamespace());
					}

					this.Properties.Add(ptd);
				}
			}
		}

		private string GetChildType(IContentTypeBase contentType)
		{
			if (contentType.AllowedContentTypes.Count() > 1)
				return "IPublishedContent";

			if (contentType.AllowedContentTypes.Count() == 1)
				return contentType.AllowedContentTypes.First().Alias;

			return "";
		}

		private IEnumerable<PropertyType> GetPropertyTypesNotDeclaredOnParent(IContentTypeComposition contentType, IContentTypeComposition parent)
		{
			if (parent == null)
				return contentType.CompositionPropertyTypes;

			List<PropertyType> propertyTypes = new List<PropertyType>(contentType.CompositionPropertyTypes);

			foreach (var propertyType in parent.CompositionPropertyTypes)
			{
				propertyTypes.Remove(propertyType);
			}

			return propertyTypes;
		}

		private string GetBaseClass(IContentTypeBase contentType, IContentTypeBase parent, string defaultBaseClass = "")
		{
			if (contentType.ParentId == -1)
				return defaultBaseClass;

			return parent.Alias;
		}
	}
}
