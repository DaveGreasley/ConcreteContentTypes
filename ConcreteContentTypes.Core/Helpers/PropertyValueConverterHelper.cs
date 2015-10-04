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
		public PropertyValueConverterHelper()
		{
		}

		public Type AttemptResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType)
		{
			try
			{
				var publishedContentType = PublishedContentType.Get(itemType, contentTypeAlias);

				var publishedPropertyType = publishedContentType.GetPropertyType(propertyTypeAlias);

				return publishedPropertyType.ClrType;
			}
			catch (Exception)
			{
				//TODO: Not sure what to do here
				throw;
			}
		}
	}
}
