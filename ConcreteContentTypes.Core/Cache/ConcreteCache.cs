using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ConcreteContentTypes.Core.Interfaces;

namespace ConcreteContentTypes.Core.Cache
{
	/// <summary>
	/// A simple implementation of <c>IConcreteCache</c> that uses a <c>ConcurrentDictionary</c> to store items.
	/// </summary>
	public class ConcreteCache : IConcreteCache
	{
		//Using ConcurrentDictionary but maybe we could use the new MemoryCache object? 
		//Should try both and compare speed!
		ConcurrentDictionary<int, IConcreteModel> _cache;

		public ConcreteCache()
		{
			_cache = new ConcurrentDictionary<int, IConcreteModel>();
		}

		/// <summary>
		/// Adds an item to the Cache using its Id as the key. If there is already an item in the cache
		/// with this Id then it will be replaced by this new item.
		/// </summary>
		/// <param name="content">The Concrete Model to cache.</param>
		public void AddOrUpdateItem(IConcreteModel content)
		{
			if (!_cache.ContainsKey(content.Id))
			{
				_cache.GetOrAdd(content.Id, content);
			}
			else
			{
				_cache[content.Id] = content;
			}
		}

		/// <summary>
		/// Attempts to get a Concrete model from the cache. Must pass the correct type for the given contentId
		/// otherwise method will return null.
		/// </summary>
		/// <typeparam name="T">The Type of the Concrete Model to return</typeparam>
		/// <param name="contentId">The Id of the Content item to retrieve from the cache.</param>
		/// <returns>Returns Concrete model if present, otherwise null.</returns>
		public T GetItem<T>(int contentId) where T : class, IConcreteModel
		{
			if (_cache.ContainsKey(contentId))
				return _cache[contentId] as T;

			return null;
		}

		/// <summary>
		/// Checks if the cache contains an entry for a given key.
		/// </summary>
		/// <param name="contentId">The Id of the Content item.</param>
		/// <returns>True if present, otherwise false.</returns>
		public bool ContainsKey(int contentId)
		{
			return _cache.ContainsKey(contentId);
		}

		/// <summary>
		/// Removes an item from the cache.
		/// </summary>
		/// <param name="contentId">The Id of the Content item to remove.</param>
		public void RemoveItem(int contentId)
		{
			IConcreteModel removedValue;

			if (_cache.ContainsKey(contentId))
				_cache.TryRemove(contentId, out removedValue);
		}
	}
}
