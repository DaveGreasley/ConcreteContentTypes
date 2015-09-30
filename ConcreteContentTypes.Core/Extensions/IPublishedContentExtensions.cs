using ConcreteContentTypes.Core.Models;
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
		/// <summary>
		/// Converts the given IPublishedContent object to a Concrete Model
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to convert to</typeparam>
		/// <param name="content">The IPublishedContent object to convert</param>
		/// <returns>A strongly typed model representing the IPublishedContent object</returns>
		public static T As<T>(this IPublishedContent content) where T : ConcreteModel
		{
			var model = Activator.CreateInstance<T>();
			model.Init(content);

			return model;
		}

		/// <summary>
		/// Converts the collection of IPublishedContent objects to a collection of Concrete Models
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to convert to</typeparam>
		/// <param name="collection">The collection of IPublishedContent objects</param>
		/// <returns>A collection of strongly typed models representing the collection of IPublishedContent objects</returns>
		public static IEnumerable<T> As<T>(this IEnumerable<IPublishedContent> collection) where T : ConcreteModel
		{
			List<T> contentList = new List<T>();

			foreach (var c in collection)
				contentList.Add(c.As<T>());

			return contentList;
		}
	}
}
