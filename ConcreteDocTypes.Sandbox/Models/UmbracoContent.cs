
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using Newtonsoft.Json;

namespace ConcreteContentTypes.Sandbox.Models
{
	public class UmbracoContent
	{
		[JsonIgnore]
		public IPublishedContent Content { get; set; }

		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

		public UmbracoContent()
		{
		}

		public UmbracoContent(int contentId)
		{
			this.Content = UmbracoContext.Current.ContentCache.GetById(contentId);
			Init();
		}

		public UmbracoContent(IPublishedContent content)
		{
			this.Content = content;
			Init();
		}

		protected virtual void Init()
		{
			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;
		}
	}
}