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
	public partial class UmbracoBaseClassTemplate : IUmbracoBaseClassTemplate
	{
		public UmbracoBaseClassDefinition CurrentDefinition { get; private set; }
		public IEnumerable<AttributeTemplate> ClassAttributeTemplates { get; private set; }
		public List<string> UsingNamespaces { get; private set; }
		public string CacheName { get; private set; }

		public UmbracoBaseClassTemplate()
		{
			this.CurrentDefinition = null;
			this.ClassAttributeTemplates = new List<AttributeTemplate>();
			this.UsingNamespaces = new List<string>();
			this.CacheName = string.Empty;
		}

		public string TransformText(UmbracoBaseClassDefinition classDefinition)
		{
			if (classDefinition == null)
				throw new ArgumentNullException("classDefinition");

			this.CurrentDefinition = classDefinition;
			this.ClassAttributeTemplates = GetAttributeTemplates();
			this.UsingNamespaces = classDefinition.GetUsingNamespaces();
			this.CacheName = CacheNameHelper.GetCacheName(classDefinition.PublishedItemType);

			return TransformText();
		}

		protected IEnumerable<AttributeTemplate> GetPropertyAttributeTemplates(UmbracoBaseClassProperty property)
		{
			List<AttributeTemplate> attributeTemplates = new List<AttributeTemplate>();

			var propertyDefintion = this.CurrentDefinition.Properties.FirstOrDefault(x => x.Property == property);

			if (propertyDefintion != null)
			{
				foreach (var attributeDefinition in propertyDefintion.Attributes)
				{
					attributeTemplates.Add(new AttributeTemplate(attributeDefinition));
				}
			}

			return attributeTemplates;
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
