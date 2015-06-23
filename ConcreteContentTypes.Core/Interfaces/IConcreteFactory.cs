using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Interfaces
{
	public interface IConcreteFactory
	{
		T CreateModel<T>(int contentId) where T : class, IConcreteModel, new();
		T CreateModel<T>(IPublishedContent content) where T : class, IConcreteModel, new();
	}
}
