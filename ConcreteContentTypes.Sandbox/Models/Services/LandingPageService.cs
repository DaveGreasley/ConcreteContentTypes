
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class LandingPageService : ServiceBase<LandingPage>
	{
		public override string ContentTypeAlias
		{
			get { return "LandingPage"; }
		}

		public LandingPageService()
			: base()
		{

		}

		public LandingPageService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(LandingPage content, IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", content.HideInBottomNavigation);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}