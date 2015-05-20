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
		protected string _nicePropertyAlias;

		public LazyLoadedPropertyTemplate(string propertyAlias, string nicePropertyAlias, string typeName)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
		}
	}
}
