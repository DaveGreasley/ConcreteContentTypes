
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
	public partial class BlogPostRepository : UmbracoContent
	{
				
		public bool umbracoNaviHide { get; set; } 
		private IEnumerable<BlogPost> _children = null;
		public new IEnumerable<BlogPost> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new BlogPost(x));
				}

				return _children;
			}
		}
		
		public BlogPostRepository()
			: base()
		{
		}

		public BlogPostRepository(int contentId)
			: base(contentId)
		{
		}

		public BlogPostRepository(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.umbracoNaviHide = Content.GetPropertyValue<bool>("umbracoNaviHide");
			
		}
	}
}

