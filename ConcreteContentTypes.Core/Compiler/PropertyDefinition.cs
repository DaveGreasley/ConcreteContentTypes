using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Compiler
{
	public class PropertyDefinition
	{
		public string PropertyEditorAlias { get; set; }
		public string PropertyTypeAlias { get; set; }
		public int DataTypeDefinitionId { get; set; }

		public PropertyDefinition(PropertyType propertyType)
		{
			this.PropertyEditorAlias = propertyType.PropertyEditorAlias;
			this.PropertyTypeAlias = propertyType.Alias;
			this.DataTypeDefinitionId = propertyType.DataTypeDefinitionId;
		}
	}
}
