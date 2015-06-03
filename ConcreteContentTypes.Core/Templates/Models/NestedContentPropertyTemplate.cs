using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class NestedContentPropertyTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;
		protected string _individualTypeName;
		protected string _nicePropertyAlias;
		protected bool _isCollection;

		public NestedContentPropertyTemplate(string propertyAlias, string nicePropertyAlias, string typeName, bool isCollection)
		{
			_propertyAlias = propertyAlias;
			_nicePropertyAlias = nicePropertyAlias;
			_isCollection = isCollection;

			if (isCollection)
			{
				_typeName = string.Format("List<{0}>", typeName);
				_individualTypeName = typeName;
			}
			else
			{
				_typeName = typeName;
			}
		}
	}
}
