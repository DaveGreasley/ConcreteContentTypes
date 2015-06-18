using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Helpers
{
	public static class CacheNameHelper
	{
		public static string GetCacheName(PublishedItemType contentType)
		{
			switch (contentType)
			{
				case PublishedItemType.Content:
					return "ContentCache";
				case PublishedItemType.Media:
					return "MediaCache";
			}

			throw new InvalidOperationException("Cannot create a lazy loaded property template for ContentType " + contentType.ToString());
		}
	}
}
