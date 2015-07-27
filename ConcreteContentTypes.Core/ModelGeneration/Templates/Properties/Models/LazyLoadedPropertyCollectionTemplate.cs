using ConcreteContentTypes.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Properties
{
	public partial class LazyLoadedPropertyCollectionTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _cacheSource;

		public LazyLoadedPropertyCollectionTemplate(string propertyAlias, string nicePropertyAlias, string typeName, PublishedItemType contentType)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_cacheSource = CacheNameHelper.GetCacheName(contentType);
		}
	}
}
