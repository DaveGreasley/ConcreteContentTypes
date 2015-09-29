using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IAttributeDefinition
	{
		string Type { get; }
		string Namespace { get; }
		List<object> Params { get; }

		void AddStringParameterValue(string paramValue);
		void AddNonStringParameterValue(object paramValue);
	}
}
