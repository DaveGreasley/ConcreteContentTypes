
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class LandingPage : UmbracoContent
	{
				
		public bool umbracoNaviHide { get; set; } 

		public LandingPage()
			: base()
		{
		}

		public LandingPage(int contentId)
			: base(contentId)
		{
		}

		public LandingPage(IPublishedContent content)
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

