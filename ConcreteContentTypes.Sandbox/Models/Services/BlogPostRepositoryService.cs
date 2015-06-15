
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class BlogPostRepositoryService : ServiceBase<BlogPostRepository>
	{
		public BlogPostRepositoryService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(BlogPostRepository content, IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", content.HideInBottomNavigation);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}