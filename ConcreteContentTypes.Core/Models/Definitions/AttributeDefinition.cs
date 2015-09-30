using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	/// <summary>
	/// Represents a C# attribute
	/// </summary>
	public class AttributeDefinition : IAttributeDefinition
	{
		public string Type { get; private set; }
		public string Namespace { get; private set; }
		public List<object> Params { get; private set; }

		public AttributeDefinition(Type type)
			: this(type.Name, type.Namespace)
		{
		}

		public AttributeDefinition(string type, string nameSpace)
		{
			this.Type = type.Replace("Attribute", "");
			this.Namespace = nameSpace;

			this.Params = new List<object>();
		}

		public void AddStringParameterValue(string paramValue)
		{
			this.Params.Add(string.Format("\"{0}\"", paramValue));
		}

		public void AddNonStringParameterValue(object paramValue)
		{
			if (paramValue == null)
				throw new ArgumentNullException("paramValue");

			if (!paramValue.GetType().IsPrimitive)
				throw new InvalidOperationException("Can only use primitive types as Attribute Parameters");

			this.Params.Add(paramValue);
		}
	}
}
