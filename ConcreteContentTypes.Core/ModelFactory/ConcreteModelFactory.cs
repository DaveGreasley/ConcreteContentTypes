using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace ConcreteContentTypes.Core.ModelFactory
{
	public class ConcreteModelFactory : IConcreteModelFactory
	{
		#region Singleton

		private static ConcreteModelFactory _current = null;
		public static ConcreteModelFactory Current
		{
			get { return _current; }
			set
			{
				_current = value;
			}
		}

		#endregion

		public ConcreteModelTypeResolver TypeResolver { get; private set; }

		public ConcreteModelFactory(ConcreteModelTypeResolver typeResolver)
		{
			this.TypeResolver = typeResolver;
		}

		public ConcreteModel CreateModel(IPublishedContent content)
		{
			var modelType = this.TypeResolver.ResolveType(content.ContentType.Alias);

			var model = Activator.CreateInstance(modelType, content) as ConcreteModel;

			return model;
		}

		public T CreateModel<T>(IPublishedContent content) where T : ConcreteModel
		{
			return (T)CreateModel(content);
		}
	}
}
