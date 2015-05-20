
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogComment : UmbracoContent
	{
				
		
		/// <summary>
		/// The full name of the person submitting the comment
		/// </summary>
		[Required]
		public string FullName { get; set; } 		
		
		/// <summary>
		/// A comment about this Blog Post
		/// </summary>
		[Required]
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

		protected override void Init()
		{
			base.Init();
						
			this.FullName = Content.GetPropertyValue<string>("fullName");
						
			this.Comment = Content.GetPropertyValue<string>("comment");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("fullName", this.FullName);
						
			dbContent.SetValue("comment", this.Comment);
			
			return base.SetProperties(dbContent);
		}
	}
}

