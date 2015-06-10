using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates
{
	public partial class UmbracoContentClassTemplate
	{
		protected UmbracoContentClassDefinition _classDefinition;
		protected List<AttributeCSharpWriter> _attributeWriters;
		protected Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>> _propertyAttributeWriters;
		protected List<string> _usingNamespaces;

		public UmbracoContentClassTemplate(UmbracoContentClassDefinition definition, List<AttributeCSharpWriter> attributeWriters, Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>> propertyAttributeWriters)
		{
			_classDefinition = definition;
			_attributeWriters = attributeWriters;
			_propertyAttributeWriters = propertyAttributeWriters;
			_usingNamespaces = definition.GetUsingNamespaces();

			
		}
	}
}
