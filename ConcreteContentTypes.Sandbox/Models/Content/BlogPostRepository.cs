
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using System;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	public partial class BlogPostRepository : BlogPostRepository<BlogPost>
	{
		public BlogPostRepository()
			: base()
		{
		}

		public BlogPostRepository(string name, ConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public BlogPostRepository(string name, int parentId)
			: base(name, parentId)
		{ }

		public BlogPostRepository(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{ }
	}

	[NodeTypeAlias("BlogPostRepository")]
	public partial class BlogPostRepository<TChild> : UmbracoContent<TChild> where TChild : ConcreteModel, new()
	{
		public override string ContentTypeAlias { get { return "BlogPostRepository"; } }





		[Field("umbracoNaviHide")]
		public bool HideInBottomNavigation { get; set; }

		public BlogPostRepository()
			: base()
		{
		}

		public BlogPostRepository(string name, ConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public BlogPostRepository(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public BlogPostRepository(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public BlogPostRepository(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);

			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide", this.GetPropertiesRecursively);

		}

	}
}

