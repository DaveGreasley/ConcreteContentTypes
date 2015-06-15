using ConcreteContentTypes.Sandbox.Models;
using ConcreteContentTypes.Sandbox.Models.Content;
using ConcreteContentTypes.Sandbox.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ConcreteContentTypes.Sandbox.WebApi
{
	public class BlogCommentApiController : UmbracoApiController
	{
		[HttpPost]
		public bool SubmitBlogComment(BlogComment comment)
		{
			BlogCommentService commentService = new BlogCommentService(Services.ContentService);
			var result = commentService.SaveAndPublishWithStatus(comment);

			return result.Success;
		}

		[HttpGet]
		public List<BlogComment> GetComments(int blogPostId)
		{
			BlogPost post = new BlogPost(blogPostId);

			return post.Children.ToList();
		}
	}
}