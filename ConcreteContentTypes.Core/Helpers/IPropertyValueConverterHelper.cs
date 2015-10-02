using System;
namespace ConcreteContentTypes.Core.Helpers
{
	public interface IPropertyValueConverterHelper
	{
		bool CanResolveType { get; set; }
		string GetNamespace();
		string GetTypeName();
	}
}
