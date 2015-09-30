using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class BaseClassPropertyDefinition : PropertyDefinition, IBaseClassPropertyDefinition
	{
		public BaseClassProperty Property { get; set; }

		public BaseClassPropertyDefinition(BaseClassProperty property)
			: base(property.ToString())
		{
			this.Property = property;
		}
	}
}
