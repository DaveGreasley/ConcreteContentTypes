using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ModelClassPropertyDefinition : PropertyDefinition
	{
		public string PropertyAlias { get; set; }

		public ModelClassPropertyDefinition(string propertyName, string propertyAlias, string clrType = "")
			: base(propertyName, clrType) 
		{
			this.PropertyAlias = propertyAlias;
		}
	}
}
