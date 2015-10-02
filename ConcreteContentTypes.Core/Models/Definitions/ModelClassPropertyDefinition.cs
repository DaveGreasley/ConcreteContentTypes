using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ModelClassPropertyDefinition : TypedPropertyDefinition, IModelClassPropertyDefinition
	{
		public string Alias { get; set; }
		public string PropertyEditorAlias { get; set; }

		public ModelClassPropertyDefinition(string propertyName, 
			string propertyAlias, 
			string propertyEditorAlias,
			string clrType = ""
			)
			: base(propertyName, clrType) 
		{
			this.Alias = propertyAlias;
			this.PropertyEditorAlias = propertyEditorAlias;
		}
	}
}
