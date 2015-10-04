using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcreteContentTypes.Core.Configuration
{
	public interface IPropertyTypeSettings
	{
		string Alias { get; }
		string ClrType { get; }
		string TypeResolver { get; }
		string Template { get; }
	}
}
