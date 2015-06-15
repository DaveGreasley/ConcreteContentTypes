
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class TextPageService : ServiceBase<TextPage>
	{
		public TextPageService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(TextPage content, IContent dbContent)
		{
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}