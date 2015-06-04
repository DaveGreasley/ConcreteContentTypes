﻿using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ClassDefinition
	{
		public string Namespace { get; set; }
		public string Name { get; set; }
		public string BaseClass { get; set; }
		public bool HasBaseClass { get { return !string.IsNullOrEmpty(this.BaseClass); } }
		public string ChildType { get; set; }
		public bool HasConcreteChildType { get { return !string.IsNullOrEmpty(this.ChildType) && this.ChildType != "IPublishedContent";  } }
		protected List<string> UsingNamespaces { get; set; }

		public List<AttributeDefinition> Attributes { get; set; }
		public List<PropertyDefinition> Properties { get; set; }

		public ClassDefinition(List<PropertyDefinition> properties, string className, string nameSpace, string baseClass = "")
		{
			this.Namespace = nameSpace;
			this.Name = className;
			this.BaseClass = baseClass;
			this.Properties = properties;
			this.Attributes = new List<AttributeDefinition>();
		}

		public ClassDefinition(IContentType contentType, IContentType parent, string nameSpace, string defaultBaseClass = "")
		{
			this.Namespace = nameSpace;
			this.Name = contentType.Alias;
			this.BaseClass = GetBaseClass(contentType, defaultBaseClass);
			this.Properties = new List<PropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();

			CreateDefinition(contentType, parent);
		}

		public List<string> GetUsingNamespaces()
		{
			this.UsingNamespaces = new List<string>();

			foreach (var attribute in this.Attributes)
			{
				if (!this.UsingNamespaces.Contains(attribute.Namespace))
					this.UsingNamespaces.Add(attribute.Namespace);
			}

			foreach (var property in this.Properties)
			{
				foreach (var attribute in property.Attributes)
				{
					if (!this.UsingNamespaces.Contains(attribute.Namespace))
						this.UsingNamespaces.Add(attribute.Namespace);
				}
			}

			return this.UsingNamespaces;
		}
		
		private void CreateDefinition(IContentType contentType, IContentType parent)
		{
			this.ChildType = GetChildType(contentType);

			IEnumerable<PropertyType> propertyTypes = GetPropertyTypesNotDeclaredOnParent(contentType, parent);

			foreach (var propertyType in propertyTypes)
			{
				try
				{
					this.Properties.Add(new PropertyDefinition(propertyType));
				}
				catch { }
			}
		}

		private string GetChildType(IContentType contentType)
		{
			if (contentType.AllowedContentTypes.Count() > 1)
				return "IPublishedContent";

			if (contentType.AllowedContentTypes.Count() == 1)
				return contentType.AllowedContentTypes.First().Alias;

			return "";
		}

		private IEnumerable<PropertyType> GetPropertyTypesNotDeclaredOnParent(IContentType contentType, IContentType parent)
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
	
		private string GetBaseClass(IContentType contentType, string defaultBaseClass = "")
		{
			if (contentType.ParentId == -1)
				return defaultBaseClass;

			var parent = UmbracoContext.Current.Application.Services.ContentTypeService.GetContentType(contentType.ParentId);

			return parent.Alias;
		}
	}
}
