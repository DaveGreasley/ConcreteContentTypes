using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Templates.Properties
{
	public partial class LazyLoadedPropertyTemplate
	{
		protected string _propertyAlias;
		protected string _typeName;
		protected string _nicePropertyAlias;
		protected string _cacheSource;

		public LazyLoadedPropertyTemplate(string propertyAlias, string nicePropertyAlias, string typeName, ContentType contentType = ContentType.Content)
		{
			_propertyAlias = propertyAlias;
			_typeName = typeName;
			_nicePropertyAlias = nicePropertyAlias;
			_cacheSource = CacheNameHelper.GetCacheName(contentType);
		}
	}
}
