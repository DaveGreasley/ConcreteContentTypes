using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IModelClassDefinition : IClassDefinition
	{
		List<IModelClassPropertyDefinition> Properties { get; set; }
		string ChildType { get; set; }
	}
}
