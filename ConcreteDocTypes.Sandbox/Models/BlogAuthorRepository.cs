
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogAuthorRepository : UmbracoContent
	{
		

		public BlogAuthorRepository()
			: base()
		{
		}

		public BlogAuthorRepository(int contentId)
			: base(contentId)
		{
		}

		public BlogAuthorRepository(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}
	}
}

