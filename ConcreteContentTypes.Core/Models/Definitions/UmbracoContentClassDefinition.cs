using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class UmbracoContentClassDefinition : ClassDefinitionBase
	{
		public Dictionary<BaseClassProperty, List<AttributeDefinition>> StandardPropertyAttributes;

		internal UmbracoContentClassDefinition(string name, string nameSpace, PublishedItemType contentType)
			: base(name, nameSpace, contentType)
		{
			this.StandardPropertyAttributes = new Dictionary<BaseClassProperty, List<AttributeDefinition>>();
			foreach (BaseClassProperty property in Enum.GetValues(typeof(BaseClassProperty)))
			{
				this.StandardPropertyAttributes.Add(property, new List<AttributeDefinition>());
			}
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
