
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class BlogPostService : ServiceBase<BlogPost>
	{
		public override string ContentTypeAlias
		{
			get { return "BlogPost"; }
		}

		public BlogPostService()
			: base()
		{

		}

		public BlogPostService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(BlogPost content, IContent dbContent)
		{
						
			dbContent.SetValue("introduction", content.Introduction);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}