using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.ModelGeneration.Templates.Properties
{
	public partial class LazyLoadedPropertyTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _cacheSource;

		public LazyLoadedPropertyTemplate(string propertyAlias, string nicePropertyAlias, string typeName, PublishedItemType contentType = PublishedItemType.Content)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_cacheSource = CacheNameHelper.GetCacheName(contentType);
		}
	}
}
