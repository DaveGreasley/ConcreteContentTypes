using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class BasicPropertyTypeDefinitionTemplate
	{
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _description;
		protected bool _required;

		public BasicPropertyTypeDefinitionTemplate(string typeName, string nicePropertyAlias, string description, bool required)
		{
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_description = description;
			_required = required;
		}
	}
}
