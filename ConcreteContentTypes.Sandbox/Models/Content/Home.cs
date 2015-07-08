
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
	 [NodeTypeAlias("Home")]
 	public partial class Home : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Home"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("siteDescription")]
		public string SiteDescription { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("siteTitle")]
		public string SiteTitle { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("siteLogo")]
		public string SiteLogo { get; set; } 		
		[JsonIgnore]
		public GridContent content { get; set; } 
		
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

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.SiteDescription = Content.GetPropertyValue<string>("siteDescription");
						
			this.SiteTitle = Content.GetPropertyValue<string>("siteTitle");
						
			this.SiteLogo = Content.GetPropertyValue<string>("siteLogo");
						
			this.content = new GridContent("content", this.Content);
			
		}

	}
}

