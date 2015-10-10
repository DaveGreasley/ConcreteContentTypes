using System;
using Umbraco.Core.Models;
namespace ConcreteContentTypes.Core.SourceModelMapping.TypeResolution
{
	public interface IPropertyValueConverterHelper
	{
		Type AttemptResolveType(string contentTypeAlias, string propertyTypeAlias, PublishedItemType itemType);
	}
}
