using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.Attributes
{
	public class AttributeTemplateFactory : ICodeTemplateFactory<IAttributeDefinition>
	{
		IErrorTracker ErrorTracker { get; set; }

		public AttributeTemplateFactory(IErrorTracker errorTracker)
		{
			this.ErrorTracker = errorTracker;
		}

		public ICodeTemplate GetTemplate(IAttributeDefinition definition)
		{
			return new AttributeTemplate(definition, ErrorTracker);
		}
	}
}
