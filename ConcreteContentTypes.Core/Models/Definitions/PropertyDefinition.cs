using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class PropertyDefinition
	{
		public string PropertyEditorAlias { get; set; }
		public string PropertyTypeAlias { get; set; }
		public int DataTypeDefinitionId { get; set; }
		public string PropertyName { get; set; }
		public string Description { get; set; }
		public bool Required { get; set; }

		public List<AttributeDefinition> Attributes { get; set; }

		public string NicePropertyName { get { return NamingConventionHelper.GetConventionalName(this.PropertyName); } }

		public PropertyDefinition(PropertyType propertyType)
		{
			this.PropertyEditorAlias = propertyType.PropertyEditorAlias;
			this.PropertyTypeAlias = propertyType.Alias;
			this.DataTypeDefinitionId = propertyType.DataTypeDefinitionId;
			this.PropertyName = propertyType.Name;
			this.Description = propertyType.Description;
			this.Required = propertyType.Mandatory;

			this.Attributes = new List<AttributeDefinition>();
		}

		//This is a hack and will be removed
		public PropertyDefinition(string propertyName, string propertyTypeAlias, string description)
		{
			this.PropertyName = propertyName;
			this.PropertyTypeAlias = propertyTypeAlias;
			this.Description = description;

			this.Attributes = new List<AttributeDefinition>();
		}
	}
}
