using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models
{
	public class AttributeDefinition
	{
		public string Type { get; set; }
		public string Namespace { get; set; }

		public Dictionary<string, object> NamedParameters { get; private set; }
		public object[] Parameters { get; private set; }

		public AttributeDefinition(Attribute attribute, object[] parameters)
		{
			var attributeType = attribute.GetType();

			this.Type = attributeType.Name;
			this.Namespace = attributeType.Namespace;
			this.Parameters = parameters;
			this.NamedParameters = null;
		}

		public AttributeDefinition(Attribute attribute, Dictionary<string, object> namedParameters)
		{
			var attributeType = attribute.GetType();

			this.Type = attributeType.Name;
			this.Namespace = attributeType.Namespace;
			this.NamedParameters = namedParameters;
			this.Parameters = null;
		}

		public AttributeDefinition(string type, string nameSpace, object[] parameters)
		{
			this.Type = type;
			this.Namespace = nameSpace;
			this.Parameters = parameters;
			this.NamedParameters = null;
		}

		public AttributeDefinition(string type, string nameSpace, Dictionary<string, object> namedParameters)
		{
			this.Type = type;
			this.Namespace = nameSpace;
			this.NamedParameters = namedParameters;
			this.Parameters = null;
		}
	}
}
