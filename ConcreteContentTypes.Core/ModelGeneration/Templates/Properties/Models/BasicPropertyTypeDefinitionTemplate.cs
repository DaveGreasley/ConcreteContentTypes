using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Properties
{
	public partial class BasicPropertyTypeDefinitionTemplate
	{
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _description;
		protected bool _required;
		protected List<AttributeCSharpWriter> _attributeWriters;
		protected bool HasDescription { get { return !string.IsNullOrEmpty(_description); } }

		public BasicPropertyTypeDefinitionTemplate(string typeName, string nicePropertyAlias, string description, bool required,
			List<AttributeCSharpWriter> attributeWriters)
		{
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_description = description;
			_required = required;
			_attributeWriters = attributeWriters;
		}
	}
}
