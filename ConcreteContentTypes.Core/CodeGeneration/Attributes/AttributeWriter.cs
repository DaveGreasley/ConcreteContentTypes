using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.Attributes
{
	public class AttributeWriter
	{
		ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; set; }
		IErrorTracker ErrorTracker { get; set; }

		public AttributeWriter(ICodeTemplateFactory<IAttributeDefinition> attributeTemplateFactory, IErrorTracker errorTracker)
		{
			this.AttributeTemplateFactory = attributeTemplateFactory;
			this.ErrorTracker = errorTracker;
		}

		public string WriteAttribute(IAttributeDefinition attributeDefinition)
		{
			try
			{
				if (attributeDefinition == null)
				{
					this.ErrorTracker.Error("AttributeDefinition is null.");
					return string.Empty;
				}

				var template = this.AttributeTemplateFactory.GetTemplate(attributeDefinition);
				return template.GenerateCode();
			}
			catch (Exception ex)
			{
				this.ErrorTracker.Error("Error writing attribute " + attributeDefinition.Type, ex);
				return string.Empty;
			}
		}
	}
}
