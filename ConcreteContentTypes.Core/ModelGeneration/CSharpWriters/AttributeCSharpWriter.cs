using ConcreteContentTypes.Core.ModelGeneration.Templates.Attributes;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.ModelGeneration.CSharpWriters
{
	public class AttributeCSharpWriter
	{
		protected AttributeDefinition _defintion;

		public AttributeCSharpWriter(AttributeDefinition defintion)
		{
			_defintion = defintion;
		}

		public string WriteAttribute()
		{
			AttributeTemplate template = new AttributeTemplate(_defintion);
			return template.TransformText();
		}
	}
}
