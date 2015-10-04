using System;
namespace ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers
{
	public interface ITypeResolver
	{
		string ResolveType(string contentTypeAlias, string propertyTypeAlias, Umbraco.Core.Models.PublishedItemType itemType);
	}
}
