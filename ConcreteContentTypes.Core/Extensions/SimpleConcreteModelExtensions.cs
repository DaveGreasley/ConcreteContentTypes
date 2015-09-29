using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Extensions
{
	public static class SimpleConcreteModelExtensions
	{
		public static T As<T>(this SimpleConcreteModel item) where T : ConcreteModel, new()
		{
			if (item == null)
				throw new ArgumentNullException("item");

			var concreteItem = new T();
			concreteItem.Init(item);

			return concreteItem;
		}

		public static IEnumerable<T> As<T>(this IEnumerable<SimpleConcreteModel> collection) where T : ConcreteModel, new()
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			return collection.Select(x => x.As<T>());
		}
	}
}
