
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class BlogCommentService : ServiceBase<BlogComment>
	{
		public override string ContentTypeAlias
		{
			get { return "BlogComment"; }
		}

		public BlogCommentService()
			: base()
		{

		}
		
		public BlogCommentService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(BlogComment content, IContent dbContent)
		{
						
			dbContent.SetValue("fullName", content.FullName);
						
			dbContent.SetValue("comment", content.Comment);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}