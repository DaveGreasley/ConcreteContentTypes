using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public abstract class ClassDefinitionBase
	{
		public string Name { get; internal set; }
		public string Namespace { get; set; }
		public List<AttributeDefinition> Attributes { get; set; }
		public List<string> DependantAssemblies { get; set; }
		public string BaseClass { get; set; }

		protected List<string> UsingNamespaces { get; set; }

		public ClassDefinitionBase(string name, string nameSpace)
		{
			this.Name = name;
			this.Namespace = nameSpace;
			this.Attributes = new List<AttributeDefinition>();
			this.DependantAssemblies = new List<string>();
			this.UsingNamespaces = new List<string>();
		}

		public virtual List<string> GetUsingNamespaces()
		{
			foreach (var attribute in this.Attributes)
			{
				if (!this.UsingNamespaces.Contains(attribute.Namespace))
					this.UsingNamespaces.Add(attribute.Namespace);
			}

			//Ensure we add our extensions namespace to all classes
			AddUsingNamespace("ConcreteContentTypes.Core.Extensions");

			return this.UsingNamespaces;
		}

		public void AddUsingNamespace(string nameSpace)
		{
			if (!this.UsingNamespaces.Contains(nameSpace) && !string.IsNullOrWhiteSpace(nameSpace))
				this.UsingNamespaces.Add(nameSpace);
		}
	}
}
