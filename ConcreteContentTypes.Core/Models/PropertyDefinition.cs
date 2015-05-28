using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models
{
	public class PropertyDefinition
	{
		public string PropertyEditorAlias { get; set; }
		public string PropertyTypeAlias { get; set; }
		public int DataTypeDefinitionId { get; set; }
		public string PropertyName { get; set; }
		public string Description { get; set; }
		public bool Required { get; set; }

		public string NicePropertyName { get { return NamingConventionHelper.GetConventionalName(this.PropertyName); } }

		public PropertyDefinition(PropertyType propertyType)
		{
			this.PropertyEditorAlias = propertyType.PropertyEditorAlias;
			this.PropertyTypeAlias = propertyType.Alias;
			this.DataTypeDefinitionId = propertyType.DataTypeDefinitionId;
			this.PropertyName = propertyType.Name;
			this.Description = propertyType.Description;
			this.Required = propertyType.Mandatory;
		}
	}
}
