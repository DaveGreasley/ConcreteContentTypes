﻿using ConcreteContentTypes.Core.Helpers;
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

		/// <summary>
		/// The ClrType to create this property as. Setting this is optional but this will take precedence
		/// over any other mechanism for determining the correct type.
		/// </summary>
		public string ClrType { get; set; }

		public List<AttributeDefinition> Attributes { get; set; }

		public string NicePropertyName { get { return NamingConventionHelper.GetConventionalName(this.PropertyName); } }

		public PropertyDefinition(PropertyType propertyType)
		{
			this.PropertyEditorAlias = propertyType.PropertyEditorAlias;
			this.PropertyTypeAlias = propertyType.Alias;
			this.DataTypeDefinitionId = propertyType.DataTypeDefinitionId;
			this.PropertyName = propertyType.Name;
			this.Description = propertyType.Description ?? "";
			this.Required = propertyType.Mandatory;

			this.Attributes = new List<AttributeDefinition>();
		}
	}
}
