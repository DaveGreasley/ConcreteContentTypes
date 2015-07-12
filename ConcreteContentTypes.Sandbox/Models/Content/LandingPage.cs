
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

using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("LandingPage")]
 	public partial class LandingPage : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "LandingPage"; } }

				
		
				
		
		[Field("umbracoNaviHide")]
		public bool HideInBottomNavigation { get; set; } 		
		[JsonIgnore]
		public GridContent content { get; set; } 
		
		private IEnumerable<IPublishedContent> _children = null;
		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				if (_children == null)
					_children = this.Content.Children;

				return _children;
			}
		}

		public LandingPage()
			: base()
		{
		}

		public LandingPage(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public LandingPage(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public LandingPage(int contentId)
			: base(contentId)
		{
		}

		public LandingPage(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.content = new GridContent("content", this.Content);
			
		}

	}
}

