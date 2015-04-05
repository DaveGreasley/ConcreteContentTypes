using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class LazyLoadedPropertyTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;

		public LazyLoadedPropertyTemplate(string propertyAlias, string typeName)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
		}
	}
}
