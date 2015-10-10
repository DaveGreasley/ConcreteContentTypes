using System;
namespace ConcreteContentTypes.Core.SourceModelMapping.TypeResolution
{
	public interface IPropertyTypeResolverFactory
	{
		ITypeResolver GetTypeResolver(string name);
	}
}
