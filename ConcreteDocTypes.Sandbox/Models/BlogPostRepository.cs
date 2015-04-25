
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogPostRepository : UmbracoContent
	{
				
		public bool umbracoNaviHide { get; set; } 

		public BlogPostRepository()
			: base()
		{
		}

		public BlogPostRepository(int contentId)
			: base(contentId)
		{
		}

		public BlogPostRepository(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.umbracoNaviHide = Content.GetPropertyValue<bool>("umbracoNaviHide");
			
		}
	}
}

