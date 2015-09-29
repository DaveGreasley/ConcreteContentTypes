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
		public ModelClassDefinition Definition { get; private set; }
		public List<string> UsingNamespaces { get; private set; }


		public IAttributeTemplate AttributeTemplate { get; private set; }
		public IPropertyTemplateFactory PropertyTemplateFactory { get; private set; }

		public ModelClassTemplate(IAttributeTemplate attributeTemplate, IPropertyTemplateFactory ptf)
		{
			this.AttributeTemplate = attributeTemplate;
			this.PropertyTemplateFactory = ptf;

			this.Definition = null;
			this.UsingNamespaces = new List<string>();
		}

		public string TransformText(ModelClassDefinition classDefinition)
		{
			throw new NotImplementedException();
		}

		private string WriteProperty(ModelClassPropertyDefinition propertyDefintion)
		{
			return "";
		}
	}
}
