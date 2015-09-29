using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class BaseClassDefinition : ClassDefinitionBase
	{
		public List<BaseClassPropertyDefinition> Properties { get; set; }
		public PublishedItemType PublishedItemType { get; set; }

		public BaseClassDefinition(string name, string nameSpace, PublishedItemType publishedItemType)
			: base(name, nameSpace)
		{
			this.Properties = new List<BaseClassPropertyDefinition>();
			this.PublishedItemType = publishedItemType;
		}

		public override List<string> GetUsingNamespaces()
		{
			foreach (var property in this.Properties)
			{
				foreach (var attribute in property.Attributes)
				{
					if (!this.UsingNamespaces.Contains(attribute.Namespace))
						UsingNamespaces.Add(attribute.Namespace);
				}
			}

			return base.GetUsingNamespaces();
		}
	}
}
