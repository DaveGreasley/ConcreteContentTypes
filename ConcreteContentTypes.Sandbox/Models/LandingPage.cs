
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
	public partial class LandingPage : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public bool HideInBottomNavigation { get; set; } 		
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
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.content = new GridContent("content", this.Content);
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", this.HideInBottomNavigation);
			
			return base.SetProperties(dbContent);
		}
	}
}

