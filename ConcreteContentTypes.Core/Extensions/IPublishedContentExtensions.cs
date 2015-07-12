using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Extensions
{
	public static class IPublishedContentExtensions
	{
		public static T As<T>(this IPublishedContent content) where T : class, IConcreteModel, new()
		{
			T model = new T();
			model.Init(content);

			return model;
		}

		public static IEnumerable<T> As<T>(this IEnumerable<IPublishedContent> content) where T : class, IConcreteModel, new()
		{
			List<T> contentList = new List<T>();

			foreach (var c in content)
			{
				contentList.Add(c.As<T>());
			}

			return contentList;
		}
	}
}
