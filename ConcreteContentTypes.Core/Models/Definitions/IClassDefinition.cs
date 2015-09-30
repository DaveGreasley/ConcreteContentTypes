using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IClassDefinition
	{
		string Name { get; }
		string Namespace { get; }
		List<IAttributeDefinition> Attributes { get; set; }
		List<string> DependantAssemblies { get; set; }
		string BaseClass { get; set; }

		void AddUsingNamespace(string nameSpace);
		IEnumerable<string> GetUsingNamespaces();
	}
}
