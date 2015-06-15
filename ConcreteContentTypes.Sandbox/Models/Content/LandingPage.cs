
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
	 [NodeTypeAlias("LandingPage")]
 	public partial class LandingPage : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "LandingPage"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoNaviHide")]
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

	}
}

