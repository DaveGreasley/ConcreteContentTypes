
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public abstract partial class ServiceBase<T> where T : IConcreteContent, new()
	{
		protected IContentService _contentService;

		public ServiceBase(IContentService contentService)
		{
			_contentService = contentService;
		}

		public T GetById(int contentId) 
		{
			T result = new T();
			result.Init(contentId);

			return result;
		}

		public T Create(IConcreteContent parent, string name, int userId = 0)
		{
			return Create(parent.Id, name, userId);
		}

		public T Create(int parentId, string name, int userId = 0)
		{
			T result = new T();

			var content = _contentService.CreateContentWithIdentity(name, parentId, result.ContentTypeAlias, userId);

			result.Name = name;
			result.ParentId = parentId;
			result.Id = content.Id;

			return result;
		}

		public IContent GetIContent(T content)
		{
			var dbContent = _contentService.GetById(content.Id);

			if (content != null)
				return dbContent;

			throw new InvalidOperationException("Content Id " + content.Id + " not found.");
		}

		public void Save(T content, int userId = 0, bool raiseEvents = true)
		{
			IContent dbContent = GetIContent(content);

			SetDbProperties(content, dbContent);

			_contentService.Save(dbContent, userId, raiseEvents);
		}

		public Attempt<Umbraco.Core.Publishing.PublishStatus> SaveAndPublishWithStatus(T content, int userId = 0, bool raiseEvents = true)
		{
			var dbContent = GetIContent(content);

			SetDbProperties(content, dbContent);

			return _contentService.SaveAndPublishWithStatus(dbContent, userId, raiseEvents);
		}

		public void Delete(T content, int userId = 0)
		{
			IContent dbContent = GetIContent(content);

			_contentService.Delete(dbContent, userId);
		}

		public virtual IContent SetDbProperties(T content, IContent dbContent)
		{
			dbContent.Name = content.Name;

			return dbContent;
		}
	}
}