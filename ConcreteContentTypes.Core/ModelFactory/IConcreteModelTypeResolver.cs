using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.ModelFactory
{
	public interface IConcreteModelTypeResolver
	{
		Type ResolveType(string contentTypeAlias);
	}
}
