using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class LazyLoadedPropertyCollectionTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;

		public LazyLoadedPropertyCollectionTemplate(string propertyAlias, string typeName)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
		}
	}
}
