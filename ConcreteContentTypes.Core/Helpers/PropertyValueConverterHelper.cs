using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace ConcreteContentTypes.Core.Helpers
{
	public class PropertyValueConverterHelper
	{
		Type _resolvedType = null;

		public bool CanResolveType { get; set; }

		public PropertyValueConverterHelper(IContentTypeComposition contentType, PropertyType propertyType, PublishedItemType itemType)
		{
			AttemptResolveType(contentType, propertyType, itemType);
		}

		public string GetTypeName()
		{
			if (_resolvedType != null)
				return _resolvedType.Name;

			return "";
		}

		public string GetNamespace()
		{
			if (_resolvedType != null)
				return _resolvedType.Namespace;

			return "";
		}

		private void AttemptResolveType(IContentTypeComposition contentType, PropertyType propertyType, PublishedItemType itemType)
		{
			try
			{
				var publishedContentType = PublishedContentType.Get(itemType, contentType.Alias);

				var publishedPropertyType = publishedContentType.GetPropertyType(propertyType.Alias);

				_resolvedType = publishedPropertyType.ClrType;

				this.CanResolveType = true;
			}
			catch (Exception ex)
			{
				this.CanResolveType = false;
			}
		}
	}
}
