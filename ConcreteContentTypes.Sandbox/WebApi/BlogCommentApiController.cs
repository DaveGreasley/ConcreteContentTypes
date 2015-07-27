using ConcreteContentTypes.Sandbox.Models;
using ConcreteContentTypes.Sandbox.Models.Content;
using ConcreteContentTypes.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Web.WebApi;
using ConcreteContentTypes.Core.Extensions;

namespace ConcreteContentTypes.Sandbox.WebApi
{
	public class BlogCommentApiController : UmbracoApiController
	{
		[HttpPost]
		public int SubmitBlogComment(BlogComment comment)
		{
			var result = Services.ContentService.SaveAndPublishWithStatus(comment);

			return result.Success ? result.Result.ContentItem.Id : -1;
		}

		[HttpGet]
		public BlogComment GetComment([FromUri]int commentId)
		{
			return new BlogComment(commentId);
		}

		[HttpGet]
		public List<BlogComment> GetComments(int blogPostId)
		{
			BlogPost post = new BlogPost(blogPostId);

			return post.Children.ToList();
		}
	}
}