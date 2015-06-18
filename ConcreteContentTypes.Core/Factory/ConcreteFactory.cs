using ConcreteContentTypes.Core.Cache;
using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Factory
{
	/// <summary>
	/// Factory class for getting new instances of our Concrete Models. It uses an <c>IConcreteCache</c> object
	/// to cache Models it creates. When a Model is requested we first check the cache to see if we have already have one and 
	/// return that if present. If not then a new one will be created, cached and returned.
	/// </summary>
	public class ConcreteFactory : IConcreteFactory
	{
		IConcreteCache _cache;
		IModelServiceResolver _serviceResolver;

		public ConcreteFactory(IConcreteCache cache, IModelServiceResolver serviceResolver)
		{
			_cache = cache;
			_serviceResolver = serviceResolver;
		}

		/// <summary>
		/// Checks the current cache for an existing item and returns that if present. If not creates a new instance
		/// of <typeparamref name="T"/> and populates its values.
		/// </summary>
		/// <typeparam name="T">The Type of the model to get or create</typeparam>
		/// <param name="contentId">The Id of the model</param>
		/// <returns>An instance of <typeparamref name="T"/></returns>
		public T GetModel<T>(int contentId) where T : class, IConcreteContent, new()
		{
			var cacheItem = GetFromCache<T>(contentId);

			if (cacheItem != null)
				return cacheItem;

			return CreateModel<T>(contentId);
		}

		/// <summary>
		/// Checks the current cache for an existing item and returns that if present. If not creates a new instance
		/// of <typeparamref name="T"/> and populates its values using the passed <c>IPublishedContent</c> object.
		/// </summary>
		/// <typeparam name="T">The Type of the model to get or create</typeparam>
		/// <param name="content">The <c>IPublishedContent</c> item to use to create the Model</param>
		/// <returns>An instance of <typeparamref name="T"/></returns>
		public T GetModel<T>(IPublishedContent content) where T : class, IConcreteContent, new()
		{
			var cacheItem = GetFromCache<T>(content.Id);

			if (cacheItem != null)
				return cacheItem;

			return CreateModel<T>(content);
		}

		private T GetFromCache<T>(int contentId) where T : class, IConcreteContent
		{
			if (_cache == null)
				return null;

			if (_cache.ContainsKey(contentId))
				return _cache.Get<T>(contentId);

			return null;
		}

		private T CreateModel<T>(int contentId) where T : class, IConcreteContent, new()
		{
			T model = new T();
			model.Init(contentId);

			AddToCache(model);

			return model;
		}

		private T CreateModel<T>(IPublishedContent content) where T : class, IConcreteContent, new()
		{
			T model = new T();
			model.Init(content);

			AddToCache(model);

			return model;
		}

		private void AddToCache<T>(T model) where T : class, IConcreteContent, new()
		{
			if (_cache != null)
			{
				_cache.AddOrUpdate(model);
			}
		}
	}
}
