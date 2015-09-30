using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ModelClassDefinition : ClassDefinitionBase, IModelClassDefinition
	{
		public List<IModelClassPropertyDefinition> Properties { get; set; }
		public string ChildType { get; set; }

		public ModelClassDefinition(string name, string nameSpace)
			: base(name, nameSpace)
		{
			this.Properties = new List<IModelClassPropertyDefinition>();
			this.ChildType = typeof(SimpleConcreteModel).Name; //TODO: Set as constant
		}

		public override IEnumerable<string> GetUsingNamespaces()
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
