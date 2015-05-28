
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class MoreEverything : Everything
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public bool HideInBottomNavigation { get; set; } 		
		
		private List<IPublishedContent> _multipleNodes = null;
		public List<IPublishedContent> MultipleNodes
		{
			get 
			{
				if (_multipleNodes == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("multipleNodes");

					if (contentId.HasValue)
					{
					
						_multipleNodes = new List<IPublishedContent>(contentId.Value); 
					}	
				}
				return _multipleNodes;
			}
		} 		
		
		private List<BlogAuthor> _blogAuthors = null;
		public List<BlogAuthor> BlogAuthors
		{
			get 
			{
				if (_blogAuthors == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("blogAuthors");

					if (contentId.HasValue)
					{
					
						_blogAuthors = new List<BlogAuthor>(contentId.Value); 
					}	
				}
				return _blogAuthors;
			}
		} 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public string NamesCheckBox { get; set; } 
		
		public MoreEverything()
			: base()
		{
		}

		public MoreEverything(int contentId)
			: base(contentId)
		{
		}

		public MoreEverything(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.NamesCheckBox = Content.GetPropertyValue<string>("namesCheckBox");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", this.HideInBottomNavigation);
						
			dbContent.SetValue("namesCheckBox", this.NamesCheckBox);
			
			return base.SetProperties(dbContent);
		}
	}
}

