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
	public class AttributeDefinition
	{
		public string Type { get; set; }
		public string Namespace { get; set; }
		public List<object> Params { get; set; }

		public AttributeDefinition(Type type)
			: this(type.Name.Replace("Attribute", ""), type.Namespace)
		{
		}

		public AttributeDefinition(string type, string nameSpace)
		{
			this.Type = type;
			this.Namespace = nameSpace;

			this.Params = new List<object>();
		}

		public void AddStringParameterValue(string paramValue)
		{
			this.Params.Add(string.Format("\"{0}\"", paramValue));
		}

		public void AddNonStringParameterValue(object paramValue)
		{
			this.Params.Add(paramValue);
		}

		public string GetParametersValuesString()
		{
			var parameters = new StringBuilder();

			foreach (var param in this.Params)
			{
				parameters.Append(param);

				if (this.Params.Last() != param)
					parameters.Append(", ");
			}

			return parameters.ToString();
		}
	}
}
