
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogPost 	{
				protected UmbracoHelper _helper;
		
		public IPublishedContent Content { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

		
				
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
					
						_linkedPage = _helper.TypedContent(contentId.Value);
				
						
					}	
				}

				return _linkedPage;
			}
		}

		
		public BlogPost()
		{
			
		}

		public BlogPost(int contentId)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = _helper.TypedContent(contentId);

			Init();
		}

		public BlogPost(IPublishedContent content)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = content;

			Init();
		}

		private void Init()
		{
			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;

						
			this.introduction = Content.GetPropertyValue<string>("introduction");
			
		}
	}
}

