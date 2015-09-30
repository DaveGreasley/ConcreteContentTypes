using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IModelClassPropertyDefinition : IPropertyDefinition
	{
		string PropertyAlias { get; set; }
	}
}
