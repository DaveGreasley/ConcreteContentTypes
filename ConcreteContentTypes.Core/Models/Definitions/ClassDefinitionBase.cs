using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ClassDefinitionBase
	{
		public string Name { get; internal set; }
		public string Namespace { get; set; }
		public List<AttributeDefinition> Attributes { get; set; }
		public List<PropertyDefinition> Properties { get; set; }
		protected List<string> UsingNamespaces { get; set; }

		public ClassDefinitionBase(string name, string nameSpace)
		{
			this.Name = name;
			this.Namespace = nameSpace;
		}

		public List<string> GetUsingNamespaces()
		{
			this.UsingNamespaces = new List<string>();

			foreach (var attribute in this.Attributes)
			{
				if (!this.UsingNamespaces.Contains(attribute.Namespace))
					this.UsingNamespaces.Add(attribute.Namespace);
			}

			foreach (var property in this.Properties)
			{
				foreach (var attribute in property.Attributes)
				{
					if (!this.UsingNamespaces.Contains(attribute.Namespace))
						this.UsingNamespaces.Add(attribute.Namespace);
				}
			}

			return this.UsingNamespaces;
		}
	}
}
