
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Interfaces;
using Newtonsoft.Json;

using System;
using Newtonsoft.Json.Linq;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("Home")]
 	public partial class Home : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Home"; } }

				
		
				
		
		[Field("siteDescription")]
		public string SiteDescription { get; set; } 		
		
				
		
		[Field("siteTitle")]
		public string SiteTitle { get; set; } 		
		
				
		
		[Field("siteLogo")]
		public string SiteLogo { get; set; } 		
		[JsonIgnore]
		public GridContent content { get; set; } 
		
		private IEnumerable<IPublishedContent> _children = null;
		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children;

				return _children;
			}
		}

		public Home()
			: base()
		{
		}

		public Home(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Home(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Home(int contentId)
			: base(contentId)
		{
		}

		public Home(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.SiteDescription = Content.GetPropertyValue<string>("siteDescription");
						
			this.SiteTitle = Content.GetPropertyValue<string>("siteTitle");
						
			this.SiteLogo = Content.GetPropertyValue<string>("siteLogo");
						
			this.content = new GridContent("content", this.Content);
			
		}

	}
}

