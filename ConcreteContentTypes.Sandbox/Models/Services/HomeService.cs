
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class HomeService : ServiceBase<Home>
	{
		public HomeService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(Home content, IContent dbContent)
		{
						
			dbContent.SetValue("siteDescription", content.SiteDescription);
						
			dbContent.SetValue("siteTitle", content.SiteTitle);
						
			dbContent.SetValue("siteLogo", content.SiteLogo);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}