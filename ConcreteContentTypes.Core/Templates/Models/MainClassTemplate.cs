using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class MainClassTemplate
	{
		protected ClassDefinition _classDefinition;
		protected List<AttributeCSharpWriter> _attributeWriters;
		protected List<PropertyCSharpWriterBase> _propertyWriters;
		protected List<string> _usingNamespaces;

		public MainClassTemplate(ClassDefinition definition, 
			List<AttributeCSharpWriter> attributeWriters,
			List<PropertyCSharpWriterBase> propertyWriters)
		{
			_classDefinition = definition;
			_propertyWriters = propertyWriters;
			_attributeWriters = attributeWriters;
			_usingNamespaces = definition.GetUsingNamespaces();
		}
	}
}
