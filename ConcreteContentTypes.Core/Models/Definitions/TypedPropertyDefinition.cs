using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class TypedPropertyDefinition : PropertyDefinition, ITypedPropertyDefinition
	{
		public string ClrType { get; set; }

		public TypedPropertyDefinition(string name, string type)
			: base(name)
		{
			this.ClrType = type;
		}
	}
}
