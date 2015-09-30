using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	/// <summary>
	/// Represents a C# Attribute Type
	/// </summary>
	public interface IAttributeDefinition
	{
		/// <summary>
		/// The Attribute Type
		/// </summary>
		string Type { get; }

		/// <summary>
		/// The Attribute Namespace
		/// </summary>
		string Namespace { get; }

		/// <summary>
		/// Collection of Objects to pass to the constructor. Will be used in the order added.
		/// </summary>
		IEnumerable<object> ConstructorParameters { get; }

		/// <summary>
		/// Adds a given object to the ConstructorParameters collection
		/// </summary>
		/// <param name="paramValue">Only accepts non-null, Value Type or String</param>
		/// <exception cref="ArgumentNullException" />
		/// <exception cref="ArgumentOutOfRangeException" />
		void AddConstructorParameter(object paramValue);
	}
}
