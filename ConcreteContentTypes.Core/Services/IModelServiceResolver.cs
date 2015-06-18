using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Services
{
	public interface IModelServiceResolver
	{
		IModelService<IConcreteContent> GetService(string contentTypeAlias);
	}
}
