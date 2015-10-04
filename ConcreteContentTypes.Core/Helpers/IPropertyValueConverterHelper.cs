using System;
using Umbraco.Core.Models;
namespace ConcreteContentTypes.Core.Helpers
{
	public interface IPropertyValueConverterHelper
	{
		Type AttemptResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType);
	}
}
