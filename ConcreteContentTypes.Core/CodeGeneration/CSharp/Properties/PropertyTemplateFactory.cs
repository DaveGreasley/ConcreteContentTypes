using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Properties
{
	public class PropertyTemplateFactory : ICodeTemplateFactory<IModelClassPropertyDefinition>
	{
		public IErrorTracker ErrorTracker { get; private set; }
		public IConcreteSettings ConcreteSettings { get; private set; }
		public IPropertyTypeDefaultsSettings PropertySettings { get; private set; }
		public ITemplateTypeResolver TemplateTypeResolver { get; private set; }

		public PropertyTemplateFactory(IErrorTracker errorTracker,
			IConcreteSettings concreteSettings,
			IPropertyTypeDefaultsSettings propertySettings,
			ITemplateTypeResolver templateTypeResolver)
		{
			this.ErrorTracker = errorTracker;
			this.ConcreteSettings = concreteSettings;
			this.PropertySettings = propertySettings;
			this.TemplateTypeResolver = templateTypeResolver;
		}

		public ICodeTemplate GetTemplate(IModelClassPropertyDefinition definition)
		{
			string templateName = GetTemplateName(definition);

			var templateType = TemplateTypeResolver.ResolveType(templateName);

			//TODO: This probably won't be good enough. Will need to pass in constructor params. Not sure if we can guarantee 
			//what they'll be though?
			var template = (ICodeTemplate)Activator.CreateInstance(templateType);

			return template;
		}

		private string GetTemplateName(IModelClassPropertyDefinition definition)
		{
			var template = PropertySettings.DefaultTemplate;

			var config = PropertySettings.PropertyTypes.FirstOrDefault(x => x.Alias == definition.Alias);
			if (config != null)
			{
				if (string.IsNullOrWhiteSpace(config.Template))
					template = config.Template;
			}

			return template;
		}
	}
}
