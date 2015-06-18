using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Services
{
	public interface IModelService<T> where T : IConcreteContent
	{
		string ContentTypeAlias { get; }
	}
}
