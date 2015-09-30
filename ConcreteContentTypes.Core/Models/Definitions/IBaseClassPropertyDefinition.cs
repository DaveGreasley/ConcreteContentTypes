using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IBaseClassPropertyDefinition : IPropertyDefinition
	{
		BaseClassProperty Property { get; set; }
	}
}
