using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	/// <summary>
	/// A language agnostic interface for a code generator. Assumes language is OO and that we always want a BaseClass.
	/// </summary>
	public interface ICodeGenerator
	{
		/// <summary>
		/// Generates the Code required to implement the base class for the current <see cref="ICodeGenerator"/>.
		/// </summary>
		/// <returns>A string containing the generated code.</returns>
		string GenerateBaseClass(UmbracoBaseClassDefinition classDefinition);

		/// <summary>
		/// Generates the Code required to implement a given <see cref="UmbracoModelClassDefinition" />
		/// </summary>
		/// <param name="classDefinition">The <see cref="UmbracoModelClassDefinition" />to generate code for.</param>
		/// <returns>A string containing the generated code.</returns>
		string GenerateModelClass(UmbracoModelClassDefinition classDefinition);
	}
}
