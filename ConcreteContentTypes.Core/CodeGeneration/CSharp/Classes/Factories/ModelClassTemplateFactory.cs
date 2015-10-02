using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes.Factories
{
	public class ModelClassTemplateFactory : ICodeTemplateFactory<IModelClassDefinition>
	{
		public IErrorTracker ErrorTracker { get; private set; }
		public ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; private set; }
		public ICodeTemplateFactory<IModelClassPropertyDefinition> PropertyTemplateFactory { get; private set; }

		public ModelClassTemplateFactory(IErrorTracker errorTracker,
			ICodeTemplateFactory<IAttributeDefinition> atf,
			ICodeTemplateFactory<IModelClassPropertyDefinition> ptf)
		{
			this.ErrorTracker = errorTracker;
			this.AttributeTemplateFactory = atf;
			this.PropertyTemplateFactory = ptf;
		}

		public ICodeTemplate GetTemplate(IModelClassDefinition definition)
		{
			return new ModelClassTemplate(definition, AttributeTemplateFactory, PropertyTemplateFactory, ErrorTracker);
		}
	}
}
