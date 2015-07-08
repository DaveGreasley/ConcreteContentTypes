using ConcreteContentTypes.Sandbox.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ConcreteContentTypes.Sandbox.Controllers
{
	public class BlogPostController : SurfaceController
	{
		//[ChildActionOnly]
		//public ActionResult RenderSubmitCommentForm(BlogPost blogPost)
		//{
		//	BlogCommentService commentService = new BlogCommentService(Services.ContentService);
		//	var commentModel = commentService.Create(blogPost, "Blog Comment + " + DateTime.Now.ToString());

		//	return PartialView("BlogSubmitComment", commentModel);
		//}
	}
}