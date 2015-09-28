using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests.DummyObjects.Concrete
{
	public class DummyContentTypeClassDefinition : ClassDefinitionBase
	{
		public DummyContentTypeClassDefinition(List<PropertyDefinition> propertyDefinitions, string name, string nameSpace, PublishedItemType itemType)
			: base(name, nameSpace, itemType)
		{
			this.Properties = propertyDefinitions;
		}
	}
}
