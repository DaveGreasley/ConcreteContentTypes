using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace ConcreteContentTypes.Core
{
	public static class IContentServiceExtensions
	{
		#region CreateContent

		public static T CreateContent<T>(this IContentService contentService,
			string name, int parentId, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContent(name, parentId, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parentId;

			return model;
		}

		public static T CreateContent<T>(this IContentService contentService,
			string name, IContent parent, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContent(name, parent, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parent.Id;

			return model;
		}

		public static T CreateContent<T>(this IContentService contentService,
			string name, IConcreteModel parent, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContent(name, parent.Id, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parent.Id;

			return model;
		}

		#endregion

		#region CreateContentWithIdentity

		public static T CreateContentWithIdentity<T>(this IContentService contentService,
			string name, int parentId, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContentWithIdentity(name, parentId, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parentId;

			return model;
		}

		public static T CreateContentWithIdentity<T>(this IContentService contentService,
			string name, IContent parent, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContentWithIdentity(name, parent, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parent.Id;

			return model;
		}

		public static T CreateContentWithIdentity<T>(this IContentService contentService,
			string name, IConcreteModel parent, int userId = 0) where T : IConcreteModel, new()
		{
			T model = new T();

			var content = contentService.CreateContentWithIdentity(name, parent.Id, model.ContentTypeAlias, userId);

			model.Id = content.Id;
			model.Name = name;
			model.ParentId = parent.Id;

			return model;
		}

		#endregion

		#region Save

		public static void Save<T>(this IContentService contentService,
			T model, int userId = 0, bool raiseEvents = true) where T : IConcreteModel, new()
		{
			IContent content = GetOrCreateIContent<T>(contentService, model, userId);

			MapModelToIContent(model, content);

			contentService.Save(content, userId, raiseEvents);
		}

		#endregion

		#region SaveAndPublishWithStatus

		public static Attempt<Umbraco.Core.Publishing.PublishStatus> SaveAndPublishWithStatus<T>(this IContentService contentService,
			T model, int userId = 0, bool raiseEvents = true) where T : IConcreteModel, new()
		{
			IContent content = GetOrCreateIContent(contentService, model, userId);

			MapModelToIContent(model, content);

			return contentService.SaveAndPublishWithStatus(content, userId, raiseEvents);
		}

		private static IContent GetOrCreateIContent<T>(IContentService contentService, T model, int userId) where T : IConcreteModel, new()
		{
			IContent content = null;

			if (model.Id > 0)
				return contentService.GetById(model.Id);

			if (content != null)
				return content;

			return contentService.CreateContentWithIdentity(model.Name, model.ParentId, model.ContentTypeAlias, userId);
		}

		#endregion

		#region Delete

		public static void Delete<T>(this IContentService contentService, T model, int userId = 0) where T : IConcreteModel, new()
		{
			IContent content = contentService.GetById(model.Id);

			contentService.Delete(content, userId);
		}

		#endregion

		#region Mapping

		private static void MapModelToIContent<T>(T model, IContent content)
		{
			var modelProperties = model.GetType().GetProperties();

			foreach (var property in content.Properties)
			{
				//TODO: This won't work! need to get the property name!
				string nicePropertyName = NamingConventionHelper.GetConventionalName(property.Alias);

				var modelProperty = modelProperties.FirstOrDefault(x => x.Name == nicePropertyName);

				if (modelProperty != null)
					content.SetValue(property.Alias, modelProperty.GetValue(model));
			}
		}

		#endregion
	}
}
