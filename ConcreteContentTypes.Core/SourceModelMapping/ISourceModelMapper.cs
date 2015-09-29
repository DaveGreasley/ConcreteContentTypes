using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.SourceModelMapping
{
	/// <summary>
	/// A data source agnostic mapper that allows conversion to the object model used by Concrete to generate models.
	/// </summary>
	public interface ISourceModelMapper
	{
		BaseClassDefinition GetBaseClassDefinition();

		/// <summary>
		/// Maps the data source items to our <see cref="ModelClassDefinition"/> type.
		/// </summary>
		/// <returns>A list of <see cref="ModelClassDefinition"/>s</returns>
		IEnumerable<ModelClassDefinition> GetModelClassDefinitions();
	}
}
