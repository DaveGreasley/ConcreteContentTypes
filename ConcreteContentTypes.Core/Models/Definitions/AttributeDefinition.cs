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

		private List<object> _constructorParameters;
		public IEnumerable<object> ConstructorParameters { get { return _constructorParameters; } }

		public AttributeDefinition(Type type)
			: this(type.Name, type.Namespace)
		{
		}

		public AttributeDefinition(string type, string nameSpace)
		{
			this.Type = type.Replace("Attribute", "");
			this.Namespace = nameSpace;

			_constructorParameters = new List<object>();
		}

		public void AddConstructorParameter(object paramValue)
		{
			if (paramValue == null)
				throw new ArgumentNullException("paramValue");

			if (paramValue.GetType() == typeof(string))
				AddStringParameterValue(paramValue.ToString());
			else
				AddNonStringParameterValue(paramValue);
		}

		private void AddStringParameterValue(string paramValue)
		{
			_constructorParameters.Add(string.Format("\"{0}\"", paramValue));
		}

		private void AddNonStringParameterValue(object paramValue)
		{
			if (!paramValue.GetType().IsValueType)
				throw new ArgumentOutOfRangeException("paramValue", paramValue, paramValue.GetType().Name + "Is not a ValueType or String!");

			_constructorParameters.Add(paramValue);
		}
	}
}
