
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class BlogAuthor 	{
				protected UmbracoHelper _helper;
		
		public IPublishedContent Content { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

		
				
		public string jobTitle { get; set; }

				
		public string shortBio { get; set; }

				
		public IHtmlString bioFull { get; set; }

		
		public BlogAuthor()
		{
			
		}

		public BlogAuthor(int contentId)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = _helper.TypedContent(contentId);

			Init();
		}

		public BlogAuthor(IPublishedContent content)
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

						
			this.jobTitle = Content.GetPropertyValue<string>("jobTitle");
						
			this.shortBio = Content.GetPropertyValue<string>("shortBio");
						
			this.bioFull = Content.GetPropertyValue<IHtmlString>("bioFull");
			
		}
	}
}

