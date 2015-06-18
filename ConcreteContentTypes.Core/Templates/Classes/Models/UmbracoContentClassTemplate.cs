using ConcreteContentTypes.Core.CSharpWriters;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Templates.Classes
{
	public partial class UmbracoContentClassTemplate
	{
		protected UmbracoContentClassDefinition _classDefinition;
		protected List<AttributeCSharpWriter> _attributeWriters;
		protected Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>> _propertyAttributeWriters;
		protected List<string> _usingNamespaces;
		protected string _cacheName;

		public UmbracoContentClassTemplate(
			UmbracoContentClassDefinition definition, 
			List<AttributeCSharpWriter> attributeWriters, 
			Dictionary<PublishedContentProperty, List<AttributeCSharpWriter>> propertyAttributeWriters,
			PublishedItemType contentType)
		{
			_classDefinition = definition;
			_attributeWriters = attributeWriters;
			_propertyAttributeWriters = propertyAttributeWriters;
			_usingNamespaces = definition.GetUsingNamespaces();
			_cacheName = CacheNameHelper.GetCacheName(contentType);
		}
	}
}
