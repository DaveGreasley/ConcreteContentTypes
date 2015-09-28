using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class UmbracoBaseClassPropertyDefinition : PropertyDefinition
	{
		public UmbracoBaseClassProperty Property { get; set; }

		public UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty property)
			: base(property.ToString(), GetType(property))
		{
			this.Property = property;
		}

		private static Type GetType(UmbracoBaseClassProperty property)
		{
			switch (property)
			{
				case UmbracoBaseClassProperty.Content:
					return typeof(IPublishedContent);
				case UmbracoBaseClassProperty.CreateDate:
					return typeof(DateTime);
				case UmbracoBaseClassProperty.Id:
					return typeof(int);
				case UmbracoBaseClassProperty.Name:
					return typeof(string);
				case UmbracoBaseClassProperty.ParentId:
					return typeof(int);
				case UmbracoBaseClassProperty.Path:
					return typeof(string);
				case UmbracoBaseClassProperty.UpdateDate:
					return typeof(DateTime);
				case UmbracoBaseClassProperty.Url:
					return typeof(string);
				default:
					throw new ArgumentOutOfRangeException("property", "Unknown property");
			}
		}
	}
}
