using ConcreteContentTypes.Core.PropertyCSharpWriters;
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
		public bool HasConcreteChildType { get { return !string.IsNullOrEmpty(this.ChildType) && this.ChildType != "IPublishedContent";  } }

		public ModelClassDefinition(List<PropertyDefinition> properties, string className, string nameSpace, string baseClass = "")
			: base(className, nameSpace)
		{
			this.BaseClass = baseClass;
			this.Properties = properties;
			this.Attributes = new List<AttributeDefinition>();
		}

		public ModelClassDefinition(IContentType contentType, IContentType parent, string nameSpace, string defaultBaseClass = "")
			: base(contentType.Alias, nameSpace)
		{
			this.BaseClass = GetBaseClass(contentType, defaultBaseClass);
			this.Properties = new List<PropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();

			CreateDefinition(contentType, parent);
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
