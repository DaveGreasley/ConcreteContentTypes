
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
	public partial class BlogPost : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public string Introduction { get; set; } 		
		
		private BlogAuthor _author = null;
		public BlogAuthor Author
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
		public IPublishedContent LinkedPage
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
		private IEnumerable<BlogComment> _children = null;
		public new IEnumerable<BlogComment> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new BlogComment(x));
				}

				return _children;
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
						
			this.Introduction = Content.GetPropertyValue<string>("introduction");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("introduction", this.Introduction);
			
			return base.SetProperties(dbContent);
		}
	}
}

