using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Exceptions
{
	public class UnknownPropertyTypeException : Exception
	{
		public string PropertyTypeAlias { get; set; }

		public UnknownPropertyTypeException(string propertyTypeAlias)
			: base(string.Format("Unsupported PropertyType - {0}", propertyTypeAlias))
		{
			this.PropertyTypeAlias = propertyTypeAlias;
		}
	}
}
