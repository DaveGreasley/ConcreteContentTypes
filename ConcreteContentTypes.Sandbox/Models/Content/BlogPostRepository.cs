
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
	 [NodeTypeAlias("BlogPostRepository")]
 	public partial class BlogPostRepository : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogPostRepository"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoNaviHide")]
		public bool HideInBottomNavigation { get; set; } 
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
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
			
		}

	}
}

