using System;
namespace ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers
{
	public interface IPropertyTypeResolverFactory
	{
		ITypeResolver GetTypeResolver(string name);
	}
}
