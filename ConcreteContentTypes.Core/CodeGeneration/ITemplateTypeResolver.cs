using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	/// <summary>
	/// Resolves a Template Name to the actual ClrType
	/// </summary>
	public interface ITemplateTypeResolver
	{
		/// <summary>
		/// Resolves a given template name into the appropriate CLR Type.
		/// </summary>
		/// <param name="templateName">The name of a Template</param>
		/// <returns>A Type object if a match is found, otherwise null.</returns>
		Type ResolveType(string templateName);
	}
}
