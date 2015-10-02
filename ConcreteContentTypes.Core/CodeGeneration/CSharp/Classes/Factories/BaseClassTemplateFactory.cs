using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes.Factories
{
	public class BaseClassTemplateFactory : ICodeTemplateFactory<IBaseClassDefinition>
	{
		public IErrorTracker ErrorTracker { get; private set; }
		public ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; private set; }

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
