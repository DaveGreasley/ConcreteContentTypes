using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class UmbracoModelClassDefinition : ClassDefinitionBase
	{
		public List<UmbracoModelClassPropertyDefinition> Properties { get; set; }

		public UmbracoModelClassDefinition(string name, string nameSpace)
			: base(name, nameSpace)
		{
			this.Properties = new List<UmbracoModelClassPropertyDefinition>();
		}

		public override List<string> GetUsingNamespaces()
		{
			foreach (var property in this.Properties)
			{
				foreach (var attribute in property.Attributes)
				{
					if (!this.UsingNamespaces.Contains(attribute.Namespace))
						this.UsingNamespaces.Add(attribute.Namespace);
				}
			}

			return base.GetUsingNamespaces();
		}
	}
}
