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
	public partial class BaseClassTemplate : IBaseClassTemplate
	{
		public BaseClassDefinition Definition { get; private set; }
		public IAttributeTemplate AttributeTemplate { get; private set; }
		public List<string> UsingNamespaces { get; private set; }
		public string CacheName { get; private set; }

		public BaseClassTemplate(IAttributeTemplate attributeTemplate)
		{
			this.AttributeTemplate = attributeTemplate;

			this.Definition = null;
			this.UsingNamespaces = new List<string>();
			this.CacheName = string.Empty;
		}

		public string TransformText(BaseClassDefinition classDefinition)
		{
			if (classDefinition == null)
				throw new ArgumentNullException("classDefinition");

			this.Definition = classDefinition;
			this.UsingNamespaces = classDefinition.GetUsingNamespaces();
			this.CacheName = CacheNameHelper.GetCacheName(classDefinition.PublishedItemType);

			return TransformText();
		}

		protected IEnumerable<AttributeDefinition> GetPropertyAttributes(BaseClassProperty property)
		{
			return this.Definition.Properties.Any(x => x.Property == property)
				? this.Definition.Properties.Single().Attributes
				: new List<AttributeDefinition>();
		}

		//private IEnumerable<AttributeTemplate> GetAttributeTemplates()
		//{
		//	List<AttributeTemplate> attributeTemplates = new List<AttributeTemplate>();

		//	foreach (var attributeDefinition in this.CurrentDefinition.Attributes)
		//	{
		//		attributeTemplates.Add(new AttributeTemplate(attributeDefinition));
		//	}

		//	return attributeTemplates;
		//}
	}
}
