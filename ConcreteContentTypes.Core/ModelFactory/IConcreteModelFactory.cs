using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.ModelFactory
{
	public interface IConcreteModelFactory
	{
		ConcreteModel CreateModel(IPublishedContent content);
		T CreateModel<T>(IPublishedContent content) where T : ConcreteModel;
	}
}
