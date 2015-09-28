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
		UmbracoBaseClassDefinition GetBaseClassDefinition();

		/// <summary>
		/// Maps the data source items to our <see cref="UmbracoModelClassDefinition"/> type.
		/// </summary>
		/// <returns>A list of <see cref="UmbracoModelClassDefinition"/>s</returns>
		IEnumerable<UmbracoModelClassDefinition> GetModelClassDefinitions();
	}
}
