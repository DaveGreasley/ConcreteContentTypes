﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace ConcreteContentTypes.Core.Extensions
{
	internal static class ContentTypeServiceExtensions
	{
		//Borrowed from NestedContent 
		public static string GetAliasByGuid(this IContentTypeService contentTypeService, Guid id)
		{
			return (string)ApplicationContext.Current.ApplicationCache.RuntimeCache.GetCacheItem(
				string.Concat("ConcreteContentTypes.GetContentTypeAliasByGuid_", id),
				() => ApplicationContext.Current.DatabaseContext.Database
					.ExecuteScalar<string>("SELECT [cmsContentType].[alias] FROM [cmsContentType] INNER JOIN [umbracoNode] ON [cmsContentType].[nodeId] = [umbracoNode].[id] WHERE [umbracoNode].[uniqueID] = @0", id));
		}
	}
}
