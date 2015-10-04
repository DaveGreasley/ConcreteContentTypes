using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IPropertyDefinition
	{
		string Name { get; set; }
		List<IAttributeDefinition> Attributes { get; set; }
		string Description { get; set; }
		string ClrType { get; set; }
	}
}
