using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Factory
{
	public interface IConcreteFactory
	{
		T GetModel<T>(int contentId) where T : class, IConcreteContent, new();
		T GetModel<T>(IPublishedContent content) where T : class, IConcreteContent, new();
	}
}
