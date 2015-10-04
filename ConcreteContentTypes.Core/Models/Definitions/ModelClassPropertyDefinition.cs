using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ModelClassPropertyDefinition : PropertyDefinition, IModelClassPropertyDefinition
	{
		public string Alias { get; set; }
		public string PropertyEditorAlias { get; set; }
		public PublishedItemType ItemType { get; set; }

		public ModelClassPropertyDefinition(
			string propertyName, 
			string propertyAlias, 
			string propertyEditorAlias,
			string clrType,
			PublishedItemType itemType
			)
			: base(propertyName, clrType) 
		{
			this.Alias = propertyAlias;
			this.PropertyEditorAlias = propertyEditorAlias;
			this.ItemType = itemType;
		}
	}
}
