using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public interface IBaseClassDefinition : IClassDefinition
	{
		List<IBaseClassPropertyDefinition> Properties { get; set; }
		PublishedItemType PublishedItemType { get; set; }
	}
}
