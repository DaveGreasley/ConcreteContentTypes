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
	public partial class ModelClassTemplate : IModelClassTemplate
	{
		public IModelClassDefinition Definition { get; private set; }
		public IEnumerable<string> UsingNamespaces { get; private set; }


		public IAttributeTemplate AttributeTemplate { get; private set; }
		public IPropertyTemplateFactory PropertyTemplateFactory { get; private set; }
		public IErrorTracker ErrorTracker { get; private set; }

		public ModelClassTemplate(
			IAttributeTemplate attributeTemplate,
			IPropertyTemplateFactory ptf,
			IErrorTracker errorTracker)
		{
			this.AttributeTemplate = attributeTemplate;
			this.PropertyTemplateFactory = ptf;
			this.ErrorTracker = errorTracker;

			this.Definition = null;
			this.UsingNamespaces = new List<string>();
		}

		public string TransformText(IModelClassDefinition classDefinition)
		{
			if (classDefinition == null)
				throw new ArgumentNullException("classDefinition");

			this.Definition = classDefinition;
			this.UsingNamespaces = classDefinition.GetUsingNamespaces();

			return TransformText();
		}

		private string WriteProperty(IModelClassPropertyDefinition propertyDefintion)
		{
			try
			{
				if (propertyDefintion == null)
				{
					this.ErrorTracker.Error("PropertyDefinition passed to ModelClassTemplate.WriteProperty() method is null. Current Class: " + this.Definition.Name);
					return string.Empty; //Don't write anything for broken properties
				}

				var template = this.PropertyTemplateFactory.GetTemplate(propertyDefintion);
				return template.TransformText(propertyDefintion);
			}
			catch (Exception ex)
			{
				this.ErrorTracker.Error("Error writing property " + propertyDefintion.PropertyAlias + " in " + this.Definition.Name, ex);
				return string.Empty; //Don't write anything for broken properties
			}
		}
	}
}
