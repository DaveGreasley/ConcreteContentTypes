using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class AttributeDefinition
	{
		public string Type { get; set; }
		public string Namespace { get; set; }
		public string ParamtersString { get; set; }

		public AttributeDefinition(string type, string nameSpace, string parametersString)
		{
			this.Type = type;
			this.Namespace = nameSpace;
			this.ParamtersString = parametersString;
		}
	}
}
