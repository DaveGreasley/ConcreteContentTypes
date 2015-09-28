using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Attributes;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Properties;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Classes
{
	public partial class MainClassTemplate : ICodeTemplate
	{
		protected ModelClassDefinitionBase _classDefinition;
		protected IEnumerable<AttributeTemplate> _attributeTemplates;
		protected IEnumerable<ICodeTemplate> _propertyWriters;
		protected IEnumerable<string> _usingNamespaces;
		protected string _children;

		public MainClassTemplate(ModelClassDefinitionBase definition,
			IEnumerable<AttributeTemplate> attributeTemplates,
			IEnumerable<ICodeTemplate> propertyWriters)
		{
			_classDefinition = definition;
			_propertyWriters = propertyWriters;
			_attributeTemplates = attributeTemplates;
			_usingNamespaces = definition.GetUsingNamespaces();

			_children = definition.HasConcreteChildType
				? new TypedChildrenPropertyTemplate(definition.ChildType).TransformText()
				: new IPublishedContentChildrenPropertyTemplate().TransformText();
		}
	}
}
