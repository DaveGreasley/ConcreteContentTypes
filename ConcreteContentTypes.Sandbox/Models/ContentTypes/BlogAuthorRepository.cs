
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
	public partial class BlogAuthorRepository : UmbracoContent
	{
		
		private IEnumerable<BlogAuthor> _children = null;
		public new IEnumerable<BlogAuthor> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new BlogAuthor(x));
				}

				return _children;
			}
		}
		
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

