
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class TextPage : UmbracoContent
	{
		

		public TextPage()
			: base()
		{
		}

		public TextPage(int contentId)
			: base(contentId)
		{
		}

		public TextPage(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}
	}
}

