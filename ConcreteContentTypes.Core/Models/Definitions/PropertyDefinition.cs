using ConcreteContentTypes.Core.Helpers;
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
		public string PropertyTypeName { get; set; }
		public int DataTypeDefinitionId { get; set; }
		public string Description { get; set; }
		public bool Required { get; set; }

		/// <summary>
		/// The ClrType to create this property as. Setting this is optional but this will take precedence
		/// over any other mechanism for determining the correct type.
		/// </summary>
		public string ClrType { get; set; }

		public List<AttributeDefinition> Attributes { get; set; }

		public string NicePropertyName { get { return NamingConventionHelper.GetConventionalName(this.PropertyTypeName); } }

		public PropertyDefinition(PropertyType propertyType)
			: this(propertyType.PropertyEditorAlias,
			propertyType.Alias,
			propertyType.Name,
			propertyType.DataTypeDefinitionId,
			propertyType.Description,
			propertyType.Mandatory)
		{
		}

		public PropertyDefinition(
			string propertyEditorAlias,
			string propertyTypeAlias,
			string propertyTypeName,
			int dataTypeDefinitionId,
			string description,
			bool required)
		{
			this.PropertyEditorAlias = propertyEditorAlias;
			this.PropertyTypeAlias = propertyTypeAlias;
			this.PropertyTypeName = propertyTypeName;
			this.DataTypeDefinitionId = dataTypeDefinitionId;
			this.Description = description ?? "";
			this.Required = required;

			this.Attributes = new List<AttributeDefinition>();
		}
	}
}
