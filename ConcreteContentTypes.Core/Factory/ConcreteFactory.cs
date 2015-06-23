using ConcreteContentTypes.Core.Cache;
using ConcreteContentTypes.Core.Interfaces;
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
	/// Factory class for getting new instances of our Concrete Models.
	/// </summary>
	/// <remarks>
	/// Creating our Concrete Models is actually quite simple, create a new instance and call Init.
	/// </remarks>
	public class ConcreteFactory : IConcreteFactory
	{
		public ConcreteFactory()
		{
		}

		/// <summary>
		/// Creates a new instance of <typeparamref name="T"/> and calls its Init method
		/// </summary>
		/// <typeparam name="T">The type of model to create</typeparam>
		/// <param name="contentId">The Id of the content item to model</param>
		/// <returns>A new instance of <typeparamref name="T"/></returns>
		public T CreateModel<T>(int contentId) where T : class, IConcreteModel, new()
		{
			T model = new T();
			model.Init(contentId);

			return model;
		}

		/// <summary>
		/// Creates a new instance of <typeparamref name="T"/> and calls its Init method
		/// </summary>
		/// <typeparam name="T">The type of model to create</typeparam>
		/// <param name="content">The <c>IPublishedContent</c> item to use to create the Model</param>
		/// <returns>A new instance of <typeparamref name="T"/></returns>
		public T CreateModel<T>(IPublishedContent content) where T : class, IConcreteModel, new()
		{
			T model = new T();
			model.Init(content);

			return model;
		}
	}
}
