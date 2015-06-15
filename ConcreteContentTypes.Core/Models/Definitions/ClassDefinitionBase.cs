using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public abstract class ClassDefinitionBase
	{
		public string Name { get; internal set; }
		public string Namespace { get; set; }
		public List<AttributeDefinition> Attributes { get; set; }
		public List<PropertyDefinition> Properties { get; set; }
		public List<string> UsingNamespaces { get; set; }
		public List<string> DependantAssemblies { get; set; }
		public ContentType ContentType { get; set; }

		public ClassDefinitionBase(string name, string nameSpace, ContentType contentType)
		{
			this.Name = name;
			this.Namespace = nameSpace;
			this.Attributes = new List<AttributeDefinition>();
			this.Properties = new List<PropertyDefinition>();
			this.DependantAssemblies = new List<string>();
			this.UsingNamespaces = new List<string>();
			this.ContentType = contentType;
		}

		public virtual List<string> GetUsingNamespaces()
		{
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
