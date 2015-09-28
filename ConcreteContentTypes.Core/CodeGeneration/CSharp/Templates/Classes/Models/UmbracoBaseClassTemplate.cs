using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Attributes;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Classes
{
	public partial class UmbracoBaseClassTemplate : IModelClassTemplate
	{
		public UmbracoModelClassDefinition CurrentDefinition { get; private set; }
		public IEnumerable<AttributeTemplate> AttributeTemplates { get; private set; }

		public UmbracoBaseClassTemplate()
		{
			this.CurrentDefinition = null;
			this.AttributeTemplates = null;
		}

		public string TransformText(UmbracoModelClassDefinition classDefinition)
		{
			if (classDefinition == null)
				throw new ArgumentNullException("classDefinition");

			this.CurrentDefinition = classDefinition;
			this.AttributeTemplates = GetAttributeTemplates();

			//return TransformText();
			return "";
		}

		private IEnumerable<AttributeTemplate> GetAttributeTemplates()
		{
			List<AttributeTemplate> attributeTemplates = new List<AttributeTemplate>();

			foreach (var attributeDefinition in this.CurrentDefinition.Attributes)
			{
				attributeTemplates.Add(new AttributeTemplate(attributeDefinition));
			}

			return attributeTemplates;
		}
	}
}
