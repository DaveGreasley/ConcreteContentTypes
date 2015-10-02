using ConcreteContentTypes.Core.CodeGeneration.CSharp.Attributes;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes
{
	public partial class BaseClassTemplate : ICodeTemplate
	{
		public IBaseClassDefinition Definition { get; private set; }

		public ICodeTemplateFactory<IAttributeDefinition> AttributeTemplateFactory { get; private set; }

		public IEnumerable<string> UsingNamespaces { get; private set; }
		public string CacheName { get; private set; }

		public IErrorTracker ErrorTracker { get; private set; }

		public BaseClassTemplate(IBaseClassDefinition classDefinition,
			ICodeTemplateFactory<IAttributeDefinition> atf,
			IErrorTracker errorTracker)
		{
			this.Definition = classDefinition;
			this.AttributeTemplateFactory = atf;

			this.UsingNamespaces = classDefinition.GetUsingNamespaces();
			this.CacheName = CacheNameHelper.GetCacheName(classDefinition.PublishedItemType);
		}

		public string GenerateCode()
		{
			return this.TransformText();
		}

		protected IEnumerable<IAttributeDefinition> GetPropertyAttributes(BaseClassProperty property)
		{
			return this.Definition.Properties.Any(x => x.Property == property)
				? this.Definition.Properties.Single().Attributes
				: new List<IAttributeDefinition>();
		}

		protected string WriteAttribute(IAttributeDefinition attributeDefinition)
		{
			try
			{
				if (attributeDefinition == null)
				{
					this.ErrorTracker.Error("AttributeDefinition passed to BaseClassTemplate.WriteAttribte() method is null. Current Class: " + this.Definition.Name);
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

	}
}
