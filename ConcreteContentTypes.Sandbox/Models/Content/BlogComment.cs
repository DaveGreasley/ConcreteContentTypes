
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("BlogComment")]
 	public partial class BlogComment : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogComment"; } }

				
		
		/// <summary>
		/// The full name of the person submitting the comment
		/// </summary>
		[Required] 
		[Field("fullName")]
		public string FullName { get; set; } 		
		
		/// <summary>
		/// A comment about this Blog Post
		/// </summary>
		[Required] 
		[Field("comment")]
		public string Comment { get; set; } 
		
		public BlogComment()
			: base()
		{
		}

		public BlogComment(int contentId)
			: base(contentId)
		{
		}

		public BlogComment(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.FullName = Content.GetPropertyValue<string>("fullName");
						
			this.Comment = Content.GetPropertyValue<string>("comment");
			
		}

	}
}

