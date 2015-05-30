using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Core.Services;
using Umbraco.Core;
using System.Reflection;

namespace ConcreteContentTypes.Core.Models
{
	public class UmbracoContent
	{
		#region Properties
		[JsonIgnore]
		public IPublishedContent Content { get; set; }

		[JsonIgnore]
		protected IContentService ContentService { get { return UmbracoContext.Current.Application.Services.ContentService; } }

		public string Name { get; set; }
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Path { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

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

		#endregion

		#region Constructors + Init

		public UmbracoContent()
		{
			this.Id = -1;
		}

		public UmbracoContent(int contentId)
		{
			Init(contentId);
		}

		public UmbracoContent(IPublishedContent content)
		{
			Init(content);
		}

		public virtual void Init(int contentId)
		{
			Init(UmbracoContext.Current.ContentCache.GetById(contentId));
		}

		public virtual void Init(IPublishedContent content)
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
		public IContent GetIContent()
		{
			if (this.Id != -1)
			{
				var content = ContentService.GetById(this.Id);

				if (content != null)
					return content;

				throw new Exception("Content Id " + this.Id + " not found.");
			}

			return ContentService.CreateContent(this.Name, this.ParentId, this.GetType().Name);
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
			IContent dbContent = SetProperties(GetIContent());

			ContentService.Save(dbContent, userId, raiseEvents);
		}

		/// <summary>
		/// Persists the current Concrete object to the DB using SaveAndPublishWithStatus method on the Umbraco ContentService.
		/// If the current object is a new object it will be created in the database (ParentId and Name must be set for this to work).
		/// </summary>
		public Attempt<Umbraco.Core.Publishing.PublishStatus> SaveAndPublishWithStatus(int userId = 0, bool raiseEvents = true)
		{
			IContent dbContent = SetProperties(GetIContent());

			return ContentService.SaveAndPublishWithStatus(dbContent, userId, raiseEvents);
		}

		#endregion
	}
}