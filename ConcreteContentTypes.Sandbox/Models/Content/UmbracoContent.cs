
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;
using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.Models.Enums;
using Umbraco.Core;
using Umbraco.Core.Services;

using Umbraco.Examine.Linq.Attributes;

namespace ConcreteContentTypes.Sandbox.Models.Content
{
		public abstract partial class UmbracoContent : IConcreteModel
	{
		public abstract string ContentTypeAlias { get; }

		[JsonIgnore]
		private IPublishedContent _content = null;
		public IPublishedContent Content
		{
			get
			{
				if (_content == null && this.Id != 0)
					_content = UmbracoContext.Current.ContentCache.GetById(this.Id);

				return _content;
			}
			set
			{
				_content = value;
			}
		}

		[JsonIgnore]
		protected IContentService ContentService { get { return ApplicationContext.Current.Services.ContentService; } }

		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				if (this.Content == null)
					return new List<IPublishedContent>();

				return this.Content.Children;
			}
		}

		[Field("nodeName")]
		public string Name { get; set; }

		[Field("id")]
		public int Id { get; set; }
		
		public int ParentId { get; set; }
		
		public string Path { get; set; }
		
		[Field("createDate")]
		public DateTime CreateDate { get; set; }
		
		[Field("updateDate")]
		public DateTime UpdateDate { get; set; }
		
		public string Url { get; set; }

		#region Constructors and Initalisation

 		public UmbracoContent()
			: base()
 		{
 		}
 
 		public UmbracoContent(int contentId)
 		{
			Init(contentId);
 		}
 
 		public UmbracoContent(IPublishedContent content)
 		{
			Init(content);
 		}

		public void Init(int contentId)
		{
			Init(UmbracoContext.Current.ContentCache.GetById(contentId));
		}

		public void Init(IPublishedContent content)
		{
			this.Content = content;

			Init();
		}

		protected virtual void Init()
		{
			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.ParentId = this.Content != null && this.Content.Parent != null ? this.Content.Parent.Id : -1; //TODO: Not sure about this, means we always grab the parent IPublishedContent too...
			this.Path = this.Content.Path;
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;
		}

		#endregion

 	}
} 
