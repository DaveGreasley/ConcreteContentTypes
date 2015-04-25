
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class Home : UmbracoContent
	{
				
		public string siteDescription { get; set; } 		
		public string siteTitle { get; set; } 

		public Home()
			: base()
		{
		}

		public Home(int contentId)
			: base(contentId)
		{
		}

		public Home(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.siteDescription = Content.GetPropertyValue<string>("siteDescription");
						
			this.siteTitle = Content.GetPropertyValue<string>("siteTitle");
			
		}
	}
}

