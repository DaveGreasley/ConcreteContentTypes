using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class UmbracoContentClassDefinition : ClassDefinitionBase
	{
		public Dictionary<PublishedContentProperty, List<AttributeDefinition>> PropertyAttributes;

		internal UmbracoContentClassDefinition(string name, string nameSpace)
			: base(name, nameSpace)
		{
			this.PropertyAttributes = new Dictionary<PublishedContentProperty, List<AttributeDefinition>>();
			this.PropertyAttributes.Add(PublishedContentProperty.Id, new List<AttributeDefinition>());
			this.PropertyAttributes.Add(PublishedContentProperty.Name, new List<AttributeDefinition>());
			this.PropertyAttributes.Add(PublishedContentProperty.CreateDate, new List<AttributeDefinition>());
			this.PropertyAttributes.Add(PublishedContentProperty.UpdateDate, new List<AttributeDefinition>());
			this.PropertyAttributes.Add(PublishedContentProperty.Path, new List<AttributeDefinition>());

		}
	}
}
