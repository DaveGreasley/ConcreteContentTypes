
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogAuthor : UmbracoContent
	{
				
		public string jobTitle { get; set; } 		
		public string shortBio { get; set; } 		
		public IHtmlString bioFull { get; set; } 

		public BlogAuthor()
			: base()
		{
		}

		public BlogAuthor(int contentId)
			: base(contentId)
		{
		}

		public BlogAuthor(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.jobTitle = Content.GetPropertyValue<string>("jobTitle");
						
			this.shortBio = Content.GetPropertyValue<string>("shortBio");
						
			this.bioFull = Content.GetPropertyValue<IHtmlString>("bioFull");
			
		}
	}
}

