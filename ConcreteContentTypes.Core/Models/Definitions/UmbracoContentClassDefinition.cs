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
		public Dictionary<PublishedContentProperty, List<AttributeDefinition>> StandardPropertyAttributes;

		internal UmbracoContentClassDefinition(string name, string nameSpace, ContentType contentType)
			: base(name, nameSpace, contentType)
		{
			this.StandardPropertyAttributes = new Dictionary<PublishedContentProperty, List<AttributeDefinition>>();
			this.StandardPropertyAttributes.Add(PublishedContentProperty.Id, new List<AttributeDefinition>());
			this.StandardPropertyAttributes.Add(PublishedContentProperty.Name, new List<AttributeDefinition>());
			this.StandardPropertyAttributes.Add(PublishedContentProperty.CreateDate, new List<AttributeDefinition>());
			this.StandardPropertyAttributes.Add(PublishedContentProperty.UpdateDate, new List<AttributeDefinition>());
			this.StandardPropertyAttributes.Add(PublishedContentProperty.Path, new List<AttributeDefinition>());
		}

		public override List<string> GetUsingNamespaces()
		{
			var usingNamespaces = base.GetUsingNamespaces();

			foreach (var property in this.StandardPropertyAttributes.Keys)
			{
				foreach (var attribute in this.StandardPropertyAttributes[property])
				{
					if (!usingNamespaces.Contains(attribute.Namespace))
						usingNamespaces.Add(attribute.Namespace);
				}
			}

			return usingNamespaces;
		}
	}
}
