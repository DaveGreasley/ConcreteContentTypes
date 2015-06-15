
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
	 [NodeTypeAlias("BlogAuthorRepository")]
 	public partial class BlogAuthorRepository : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogAuthorRepository"; } }

		
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

