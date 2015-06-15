using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates.Attributes
{
	public partial class AttributeTemplate
	{
		protected string _type;
		protected string _parameters;

		public AttributeTemplate(AttributeDefinition definition)
		{
			_type = definition.Type;
			_parameters = definition.ParamtersString;
		}
	}
}
