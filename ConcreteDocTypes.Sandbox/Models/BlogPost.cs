
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogPost : UmbracoContent
	{
				
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
					
						_author = new BlogAuthor(contentId.Value); 					}	
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
						
			this.introduction = Content.GetPropertyValue<string>("introduction");
			
		}
	}
}

