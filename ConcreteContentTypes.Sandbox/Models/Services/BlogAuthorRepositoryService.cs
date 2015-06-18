
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class BlogAuthorRepositoryService : ServiceBase<BlogAuthorRepository>
	{
		public override string ContentTypeAlias
		{
			get { return "BlogAuthorRepository"; }
		}

		public BlogAuthorRepositoryService()
			: base()
		{

		}

		public BlogAuthorRepositoryService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(BlogAuthorRepository content, IContent dbContent)
		{
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}