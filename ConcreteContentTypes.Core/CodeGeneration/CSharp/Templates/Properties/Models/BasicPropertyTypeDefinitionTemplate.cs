using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Properties
{
	public partial class BasicPropertyTypeDefinitionTemplate : ICodeTemplate
	{
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _description;
		protected bool _required;
		protected List<AttributeTemplate> _attributeTemplates;
		protected bool HasDescription { get { return !string.IsNullOrEmpty(_description); } }

		public BasicPropertyTypeDefinitionTemplate(string typeName, string nicePropertyAlias, string description, bool required,
			List<AttributeTemplate> attributeTemplates)
		{
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_description = description;
			_required = required;
			_attributeTemplates = attributeTemplates;
		}
	}
}
