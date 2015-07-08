using ConcreteContentTypes.Sandbox.Models.Content;
using ConcreteContentTypes.Core;
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
		[ChildActionOnly]
		public ActionResult RenderSubmitCommentForm(BlogPost blogPost)
		{
			var blogComment = new BlogComment("Blog Comment " + DateTime.Now.ToString(), blogPost);

			return PartialView("BlogSubmitComment", blogComment);
		}
	}
}