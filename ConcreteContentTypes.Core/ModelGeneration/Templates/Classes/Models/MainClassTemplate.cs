using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters;
using ConcreteContentTypes.Core.ModelGeneration.CSharpWriters.PropertyCSharpWriters;
using ConcreteContentTypes.Core.ModelGeneration.Templates.Properties;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Classes
{
	public partial class MainClassTemplate
	{
		protected ModelClassDefinition _classDefinition;
		protected List<AttributeCSharpWriter> _attributeWriters;
		protected List<PropertyCSharpWriterBase> _propertyWriters;
		protected List<string> _usingNamespaces;
		protected string _children;

		public MainClassTemplate(ModelClassDefinition definition, 
			List<AttributeCSharpWriter> attributeWriters,
			List<PropertyCSharpWriterBase> propertyWriters)
		{
			_classDefinition = definition;
			_propertyWriters = propertyWriters;
			_attributeWriters = attributeWriters;
			_usingNamespaces = definition.GetUsingNamespaces();

			_children = definition.HasConcreteChildType
				? new TypedChildrenPropertyTemplate(definition.ChildType).TransformText()
				: new IPublishedContentChildrenPropertyTemplate().TransformText();
		}
	}
}
