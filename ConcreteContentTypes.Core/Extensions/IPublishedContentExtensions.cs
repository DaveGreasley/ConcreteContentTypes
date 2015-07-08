using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core
{
	public static class IPublishedContentExtensions
	{
		public static T As<T>(this IPublishedContent content) where T : class, IConcreteModel, new()
		{
			T model = new T();
			model.Init(content);

			return model;
		}
	}
}
