using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace ConcreteContentTypes.ModelFactory
{
    public class ConcretePublishedContentModelFactory : IPublishedContentModelFactory
    {
		ConcreteCache _cache;

		public ConcretePublishedContentModelFactory(ConcreteCache cache, IPublishedContentModelFactory factory)
		{
			_cache = new ConcreteCache();
		}

		public Umbraco.Core.Models.IPublishedContent CreateModel(Umbraco.Core.Models.IPublishedContent content)
		{
			return content;
		}
	}
}
