using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class BaseClassPropertyDefinition : PropertyDefinition
	{
		public BaseClassProperty Property { get; set; }

		public BaseClassPropertyDefinition(BaseClassProperty property)
			: base(property.ToString(), GetType(property))
		{
			this.Property = property;
		}

		private static Type GetType(BaseClassProperty property)
		{
			switch (property)
			{
				case BaseClassProperty.Content:
					return typeof(IPublishedContent);
				case BaseClassProperty.CreateDate:
					return typeof(DateTime);
				case BaseClassProperty.Id:
					return typeof(int);
				case BaseClassProperty.Name:
					return typeof(string);
				case BaseClassProperty.ParentId:
					return typeof(int);
				case BaseClassProperty.Path:
					return typeof(string);
				case BaseClassProperty.UpdateDate:
					return typeof(DateTime);
				case BaseClassProperty.Url:
					return typeof(string);
				default:
					throw new ArgumentOutOfRangeException("property", "Unknown property");
			}
		}
	}
}
