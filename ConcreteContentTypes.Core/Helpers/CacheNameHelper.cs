using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Helpers
{
	public static class CacheNameHelper
	{
		public static string GetCacheName(ContentType contentType)
		{
			switch (contentType)
			{
				case ContentType.Content:
					return "ContentCache";
				case ContentType.Media:
					return "MediaCache";
			}

			throw new InvalidOperationException("Cannot create a lazy loaded property template for ContentType " + contentType.ToString());
		}
	}
}
