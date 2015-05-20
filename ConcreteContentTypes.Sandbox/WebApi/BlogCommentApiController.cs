using ConcreteContentTypes.Sandbox.Models;
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
			comment.Name = "Comment " + DateTime.Now.ToString();

			var result = comment.SaveAndPublishWithStatus();

			if (result.Success)
			{
				return true;
			}

			return false;
		}

		[HttpGet]
		public List<BlogComment> GetComments(int blogPostId)
		{
			BlogPost post = new BlogPost(blogPostId);

			return post.Children.ToList();
		}
	}
}