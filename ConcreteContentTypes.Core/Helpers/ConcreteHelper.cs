using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Helpers
{
	/// <summary>
	/// A helper that provides the easiest way to interact with Concrete
	/// </summary>
	public class ConcreteHelper
	{
		ConcreteContext _context;

		/// <summary>
		/// Creates a new instance of <c>ConcreteHelper</c>
		/// </summary>
		public ConcreteHelper(ConcreteContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Checks the current cache for an existing item and returns that if present. If not creates a new instance
		/// of <typeparamref name="T"/> and populates its values.
		/// </summary>
		/// <typeparam name="T">The Type of the model to get</typeparam>
		/// <param name="contentId">The Id of the content item to model</param>
		/// <returns>An instance of <typeparamref name="T"/></returns>
		public T GetModel<T>(int contentId) where T : class, IConcreteModel, new()
		{
			var cacheItem = _context.Cache.GetItem<T>(contentId);

			if (cacheItem != null) return cacheItem;

			var model = _context.ModelFactory.CreateModel<T>(contentId);

			if (model == null) return null;

			_context.Cache.AddOrUpdateItem(model);

			return model;
		}

		/// <summary>
		/// Checks the current cache for an existing item and returns that if present. If not creates a new instance
		/// of <typeparamref name="T"/> and populates its values using the passed <c>IPublishedContent</c> object.
		/// </summary>
		/// <typeparam name="T">The Type of the model to get or create</typeparam>
		/// <param name="content">The <c>IPublishedContent</c> item to use to create the Model</param>
		/// <returns>An instance of <typeparamref name="T"/></returns>
		public T GetModel<T>(IPublishedContent content) where T : class, IConcreteModel, new()
		{
			var cacheItem = _context.Cache.GetItem<T>(content.Id);

			if (cacheItem != null)	return cacheItem;

			var model = _context.ModelFactory.CreateModel<T>(content);

			_context.Cache.AddOrUpdateItem(model);

			return model;
		}
	}
}
