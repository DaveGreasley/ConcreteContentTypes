
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class TextPage 	{
				protected UmbracoHelper _helper;
		
		public IPublishedContent Content { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

		
		
		public TextPage()
		{
			
		}

		public TextPage(int contentId)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = _helper.TypedContent(contentId);

			Init();
		}

		public TextPage(IPublishedContent content)
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

			
		}
	}
}

