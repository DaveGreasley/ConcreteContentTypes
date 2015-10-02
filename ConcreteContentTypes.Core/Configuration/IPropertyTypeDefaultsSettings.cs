using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public interface IPropertyTypeDefaultsSettings
	{
		string DefaultTemplate { get; }
		IEnumerable<IPropertyTypeSettings> PropertyTypes { get; }
	}
}
