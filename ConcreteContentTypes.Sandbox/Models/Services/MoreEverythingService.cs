
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class MoreEverythingService : ServiceBase<MoreEverything>
	{
		public override string ContentTypeAlias
		{
			get { return "MoreEverything"; }
		}

		public MoreEverythingService()
			: base()
		{

		}
		
		public MoreEverythingService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(MoreEverything content, IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", content.HideInBottomNavigation);
						
			dbContent.SetValue("namesCheckBox", content.NamesCheckBox);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}