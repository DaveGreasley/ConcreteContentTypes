
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;


namespace ConcreteContentTypes.Sandbox.Models.ContentTypes
{
	public partial class LandingPage : UmbracoContent
	{
				
		public bool umbracoNaviHide { get; set; } 		
		[JsonIgnore]
		public GridContent content { get; set; } 
		
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
						
			this.content = new GridContent("content", this.Content);
			
		}
	}
}

