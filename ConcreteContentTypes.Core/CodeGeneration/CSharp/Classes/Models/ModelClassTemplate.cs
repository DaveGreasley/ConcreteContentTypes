using ConcreteContentTypes.Core.CodeGeneration.CSharp.Attributes;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes
{
	public partial class ModelClassTemplate : ICodeTemplate
	{
		protected IModelClassDefinition Definition { get; set; }
		protected IEnumerable<string> UsingNamespaces { get; set; }

		ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; set; }
		ICodeTemplateFactory<IModelClassPropertyDefinition> PropertyTemplateFactory { get; set; }

		IErrorTracker ErrorTracker { get; set; }

		public ModelClassTemplate(
			IModelClassDefinition definition,
			ICodeTemplateFactory<IAttributeDefinition> atf,
			ICodeTemplateFactory<IModelClassPropertyDefinition> ptf,
			IErrorTracker errorTracker)
		{
			this.AttributeTemplateFactory = atf;
			this.PropertyTemplateFactory = ptf;
			this.ErrorTracker = errorTracker;

			this.Definition = definition;
			this.UsingNamespaces = definition.GetUsingNamespaces();
		}

		public string GenerateCode()
		{
			return this.GenerateCode();
		}

		protected string WriteAttribute(IAttributeDefinition attributeDefinition)
		{
			try
			{
				if (attributeDefinition == null)
				{
					this.ErrorTracker.Error("AttributeDefinition passed to ModelClassTemplate.WriteAttribte() method is null. Current Class: " + this.Definition.Name);
					return string.Empty;
				}

				var template = this.AttributeTemplateFactory.GetTemplate(attributeDefinition);
				return template.GenerateCode();
			}
			catch (Exception ex)
			{
				this.ErrorTracker.Error("Error writing attribute " + attributeDefinition.Type + " in " + this.Definition.Name, ex);
				return string.Empty;
			}
		}

		protected string WriteProperty(IModelClassPropertyDefinition propertyDefintion)
		{
			try
			{
				if (propertyDefintion == null)
				{
					this.ErrorTracker.Error("PropertyDefinition passed to ModelClassTemplate.WriteProperty() method is null. Current Class: " + this.Definition.Name);
					return string.Empty; //Don't write anything for broken properties
				}

				var template = this.PropertyTemplateFactory.GetTemplate(propertyDefintion);
				return template.GenerateCode();
			}
			catch (Exception ex)
			{
				this.ErrorTracker.Error("Error writing property " + propertyDefintion.Alias + " in " + this.Definition.Name, ex);
				return string.Empty; //Don't write anything for broken properties
			}
		}
	}
}
