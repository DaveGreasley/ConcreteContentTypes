using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class PropertyDefinition : IPropertyDefinition
	{
		public string Name { get; set; }
		public List<IAttributeDefinition> Attributes { get; set; }
		public string Description { get; set; }

		public PropertyDefinition(string name)
		{
			this.Name = NamingConventionHelper.GetConventionalName(name);
			this.Attributes = new List<IAttributeDefinition>();
			this.Description = "";
		}
	}
}
