
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
	public partial class BlogPost : UmbracoContent
	{
				
		[JsonIgnore]
		public GridContent content { get; set; } 		
		public string introduction { get; set; } 		
		
		private BlogAuthor _author = null;
		public BlogAuthor author
		{
			get 
			{
				if (_author == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("author");

					if (contentId.HasValue)
					{
					
						_author = new BlogAuthor(contentId.Value); 
					}	
				}
				return _author;
			}
		} 		
		
		private IPublishedContent _linkedPage = null;
		public IPublishedContent linkedPage
		{
			get 
			{
				if (_linkedPage == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("linkedPage");

					if (contentId.HasValue)
					{
					
						_linkedPage = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _linkedPage;
			}
		} 
		
		public BlogPost()
			: base()
		{
		}

		public BlogPost(int contentId)
			: base(contentId)
		{
		}

		public BlogPost(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.content = new GridContent("content", this.Content);
						
			this.introduction = Content.GetPropertyValue<string>("introduction");
			
		}
	}
}
