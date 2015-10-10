using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.Classes
{
	public class BaseClassTemplateFactory : ICodeTemplateFactory<IBaseClassDefinition>
	{
		IErrorTracker ErrorTracker { get; set; }
		ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; set; }

		public BaseClassTemplateFactory(IErrorTracker errorTracker,
			ICodeTemplateFactory<IAttributeDefinition> atf)
		{
			this.ErrorTracker = errorTracker;
			this.AttributeTemplateFactory = atf;
		}

		public ICodeTemplate GetTemplate(IBaseClassDefinition definition)
		{
			return new BaseClassTemplate(definition, AttributeTemplateFactory, ErrorTracker);
		}
	}
}
