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

namespace ConcreteContentTypes.Core.Extensions
{
	public static class IContentServiceExtensions
	{
		#region CreateContentWithIdentity

		/// <summary>
		/// Creates a Content item in the database
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to return</typeparam>
		/// <param name="name">The name of the item to create</param>
		/// <param name="parentId">The id of the parent content item</param>
		/// <param name="userId">The user id to run the content service as</param>
		/// <returns>A Typed Concrete Model with Id, Name and ParentId set</returns>
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

		/// <summary>
		/// Creates a Content item in the database
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to return</typeparam>
		/// <param name="name">The name of the item to create</param>
		/// <param name="parent">The parent of the new content</param>
		/// <param name="userId">The user id to run the content service as</param>
		/// <returns>A Typed Concrete Model with Id, Name and ParentId set</returns>
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

		/// <summary>
		/// Creates a Content item in the database
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to return</typeparam>
		/// <param name="name">The name of the item to create</param>
		/// <param name="parent">The parent of the new content</param>
		/// <param name="userId">The user id to run the content service as</param>
		/// <returns>A Typed Concrete Model with Id, Name and ParentId set</returns>
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

		/// <summary>
		/// Saves a Concrete Model to the database. If it doesn't exist it will be created.
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to save</typeparam>
		/// <param name="model">The model to save</param>
		/// <param name="userId">Optional Id of the User saving the Content</param>
		/// <param name="raiseEvents">Optional boolean indicating whether to raise events</param>
		public static void Save<T>(this IContentService contentService,
			T model, int userId = 0, bool raiseEvents = true) where T : IConcreteModel, new()
		{
			IContent content = GetOrCreateIContent<T>(contentService, model, userId);

			MapModelToIContent(model, content);

			contentService.Save(content, userId, raiseEvents);
		}

		#endregion

		#region SaveAndPublishWithStatus

		/// <summary>
		/// Saves and Publishes a Concrete Model. It will be created in the database if it doesn't exist.
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to Save and Publish</typeparam>
		/// <param name="model">The Concrete Model to Save and Publish</param>
		/// <param name="userId">Optional Id of the User Saving the Model</param>
		/// <param name="raiseEvents">Optional boolean indicating whether to raise events</param>
		/// <returns>An <c>Attempt</c> object containing the Status of the Publish attempt</returns>
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

		/// <summary>
		/// Deletes a Content item from the Database
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to delete</typeparam>
		/// <param name="model">The Concrete Model object to delete</param>
		/// <param name="userId">Optional Id of the User Deleting the Content</param>
		public static void Delete<T>(this IContentService contentService, T model, int userId = 0) where T : IConcreteModel, new()
		{
			IContent content = contentService.GetById(model.Id);

			contentService.Delete(content, userId);
		}

		#endregion

		#region Mapping

		/// <summary>
		/// Attempts to map properties from a Concrete Model to an IContent object
		/// </summary>
		/// <typeparam name="T">The Type of Concrete Model to map from</typeparam>
		/// <param name="model">The Concrete Model to map from</param>
		/// <param name="content">The IContent object to map to</param>
		public static void MapModelToIContent<T>(T model, IContent content)
		{
			var modelProperties = model.GetType().GetProperties();

			foreach (var property in content.Properties)
			{
				string nicePropertyName = GetNiceNameForProperty(property, content);

				if (!string.IsNullOrEmpty(nicePropertyName))
				{
					var modelProperty = modelProperties.FirstOrDefault(x => x.Name == nicePropertyName);

					if (modelProperty != null)
					{
						var modelPropertyType = modelProperty.PropertyType;

						if (modelPropertyType.IsPrimitive || modelPropertyType.Equals(typeof(string)))
						{
							content.SetValue(property.Alias, modelProperty.GetValue(model));
						}
					}
				}
			}
		}

		private static string GetNiceNameForProperty(Property property, IContent content)
		{
			var propertyType = content.PropertyTypes.FirstOrDefault(x => x.Alias == property.Alias);

			if (propertyType == null)
				return "";

			return NamingConventionHelper.GetConventionalName(propertyType.Name);
		}

		#endregion
	}
}
