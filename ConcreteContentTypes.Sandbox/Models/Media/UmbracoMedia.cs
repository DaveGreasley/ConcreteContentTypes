
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

namespace ConcreteContentTypes.Sandbox.Models.Media
{
		public partial class UmbracoMedia : IUmbracoContent
	{
		[JsonIgnore]
		private IPublishedContent _content = null;
		public IPublishedContent Content
		{
			get
			{
				if (_content == null && this.Id != 0)
					_content = UmbracoContext.Current.MediaCache.GetById(this.Id);

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

 		public UmbracoMedia()
			: base()
 		{
 		}
 
 		public UmbracoMedia(int contentId)
 		{
			Init(contentId);
 		}
 
 		public UmbracoMedia(IPublishedContent content)
 		{
			Init(content);
 		}

		public void Init(int contentId)
		{
			Init(UmbracoContext.Current.MediaCache.GetById(contentId));
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

		#region Public Methods

		/// <summary>
		/// Retrieves the IContent object from the database or creates a new one. In order to create a new object in the DB
		/// ParentId must be set.
		/// </summary>
		public IContent GetOrCreateIContent()
		{
			if (this.Id != -1)
			{
				return GetIContent();
			}

			return CreateIContent();
		}

		/// <summary>
		/// Maps all the properties on this class to the passed IContent object
		/// </summary>
		public virtual IContent SetProperties(IContent dbContent)
		{
			dbContent.Name = this.Name;
			dbContent.CreateDate = this.CreateDate;
			dbContent.UpdateDate = this.UpdateDate;

			return dbContent;
		}

		/// <summary>
		/// Persists the current Concrete object to the DB using Save method on the Umbraco ContentService.
		/// If the current object is a new object it will be created in the database (ParentId and Name must be set for this to work).
		/// </summary>
		public void Save(int userId = 0, bool raiseEvents = true)
		{
			IContent dbContent = SetProperties(GetOrCreateIContent());

			ContentService.Save(dbContent, userId, raiseEvents);
		}

		/// <summary>
		/// Persists the current Concrete object to the DB using SaveAndPublishWithStatus method on the Umbraco ContentService.
		/// If the current object is a new object it will be created in the database (ParentId and Name must be set for this to work).
		/// </summary>
		public Attempt<Umbraco.Core.Publishing.PublishStatus> SaveAndPublishWithStatus(int userId = 0, bool raiseEvents = true)
		{
			IContent dbContent = SetProperties(GetOrCreateIContent());

			return ContentService.SaveAndPublishWithStatus(dbContent, userId, raiseEvents);
		}

		/// <summary>
		/// Deletes the associated content object from the database. 
		/// </summary>
		/// <param name="userId"></param>
		public void Delete(int userId = 0)
		{
			IContent dbContent = GetIContent();

			ContentService.Delete(dbContent, userId);
		}

		#endregion

		private IContent GetIContent()
		{
			var content = ContentService.GetById(this.Id);

			if (content != null)
				return content;

			throw new InvalidOperationException("Content Id " + this.Id + " not found.");
		}

		private IContent CreateIContent()
		{
			if (string.IsNullOrEmpty(this.Name) || this.ParentId < 1)
				throw new InvalidOperationException("Either Name or ParentId is not set. These must be set in order to create a content item.");

			return ContentService.CreateContent(this.Name, this.ParentId, this.GetType().Name);
		}
 	}
} 
