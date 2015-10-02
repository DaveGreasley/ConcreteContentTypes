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
	public class PropertyValueConverterHelper : IPropertyValueConverterHelper
	{
		Type _resolvedType = null;

		public bool CanResolveType { get; set; }

		public PropertyValueConverterHelper(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType)
		{
			AttemptResolveType(contentTypeAlias, propertyTypeAlias, itemType);
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

		private void AttemptResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType)
		{
			try
			{
				var publishedContentType = PublishedContentType.Get(itemType, contentTypeAlias);

				var publishedPropertyType = publishedContentType.GetPropertyType(propertyTypeAlias);

				_resolvedType = publishedPropertyType.ClrType;

				this.CanResolveType = true;
			}
			catch (Exception)
			{
				this.CanResolveType = false;
			}
		}

	}
}
