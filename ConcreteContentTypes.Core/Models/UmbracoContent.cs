
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using Newtonsoft.Json;
using Umbraco.Core.Models.PublishedContent;

namespace ConcreteContentTypes.Core.Models
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

		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				return this.Content.Children;
			}
		 }

		public UmbracoContent()
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
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;
		}

		//[JsonIgnore]
		//public IEnumerable<IPublishedContent> ContentSet
		//{
		//	get { return this.Content.ContentSet; }
		//}

		//[JsonIgnore]
		//public Umbraco.Core.Models.PublishedContent.PublishedContentType ContentType
		//{
		//	get { return this.Content.ContentType; }
		//}

		//[JsonIgnore]
		//public int CreatorId
		//{
		//	get { return this.Content.CreatorId; }
		//}

		//[JsonIgnore]
		//public string CreatorName
		//{
		//	get { return this.Content.CreatorName; }
		//}

		//[JsonIgnore]
		//public string DocumentTypeAlias
		//{
		//	get { return this.Content.DocumentTypeAlias; }
		//}

		//[JsonIgnore]
		//public int DocumentTypeId
		//{
		//	get { return this.Content.DocumentTypeId; }
		//}

		//public int GetIndex()
		//{
		//	return this.Content.GetIndex();
		//}

		//public IPublishedProperty GetProperty(string alias, bool recurse)
		//{
		//	return this.Content.GetProperty(alias, recurse);
		//}

		//public IPublishedProperty GetProperty(string alias)
		//{
		//	return this.Content.GetProperty(alias);
		//}

		//[JsonIgnore]
		//public bool IsDraft
		//{
		//	get { return this.Content.IsDraft; }
		//}

		//[JsonIgnore]
		//public PublishedItemType ItemType
		//{
		//	get { return this.Content.ItemType; }
		//}

		//[JsonIgnore]
		//public int Level
		//{
		//	get { return this.Content.Level; }
		//}

		//[JsonIgnore]
		//public IPublishedContent Parent
		//{
		//	get { return this.Content.Parent; }
		//}

		//[JsonIgnore]
		//public string Path
		//{
		//	get { return this.Content.Path; }
		//}

		//[JsonIgnore]
		//public ICollection<IPublishedProperty> Properties
		//{
		//	get { return this.Content.Properties; }
		//}

		//[JsonIgnore]
		//public int SortOrder
		//{
		//	get { return this.Content.SortOrder; }
		//}

		//[JsonIgnore]
		//public int TemplateId
		//{
		//	get { return this.Content.TemplateId; }
		//}

		//[JsonIgnore]
		//public string UrlName
		//{
		//	get { return this.Content.UrlName; }
		//}

		//[JsonIgnore]
		//public Guid Version
		//{
		//	get { return this.Content.Version; }
		//}

		//[JsonIgnore]
		//public int WriterId
		//{
		//	get { return this.Content.WriterId; }
		//}

		//[JsonIgnore]
		//public string WriterName
		//{
		//	get { return this.Content.WriterName; }
		//}

		//[JsonIgnore]
		//public object this[string alias]
		//{
		//	get { return this.Content[alias]; }
		//}
	}
}