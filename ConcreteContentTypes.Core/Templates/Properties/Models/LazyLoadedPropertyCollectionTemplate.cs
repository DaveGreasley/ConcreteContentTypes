using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates.Properties
{
	public partial class LazyLoadedPropertyCollectionTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;
		protected string _nicePropertyAlias;

		public LazyLoadedPropertyCollectionTemplate(string propertyAlias, string nicePropertyAlias, string typeName)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
		}
	}
}
