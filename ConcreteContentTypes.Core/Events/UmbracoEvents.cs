using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;
using ConcreteContentTypes.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using ConcreteContentTypes.Core.Factory;
using ConcreteContentTypes.Core.Context;
using Umbraco.Web.Routing;

namespace ConcreteContentTypes.Core.Events
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			//Create the ConcreteContext
			InitialiseConcrete();

			//Attach to ContentTypeService events for Model creation
			AttachToContentTypeServiceEvents();

			//Attach to ContentService events for controlling our cache
			AttachToContentServiceEvents();
		}

		#region Initialise Concrete

		private void InitialiseConcrete()
		{
			ConcreteContextFactory factory = new ConcreteContextFactory();
			ConcreteContext.Current = factory.CreateContext();
		}

		#endregion

		#region Content Type Service Events

		private void AttachToContentTypeServiceEvents()
		{
			ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
			ContentTypeService.SavedMediaType += ContentTypeService_SavedMediaType;
		}

		void ContentTypeService_SavedMediaType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IMediaType> e)
		{
			try
			{
				if (ConcreteSettings.Current.GenerateOnContentTypeSave)
				{
					Concrete c = new Concrete();
					c.BuildMediaTypes();
				}
			}
			catch (Exception ex)
			{
				LogHelper.Error<UmbracoEvents>("Error generating Concrete models on ContentType save", ex);
			}
		}

		void ContentTypeService_SavedContentType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContentType> e)
		{
			try
			{
				if (ConcreteSettings.Current.GenerateOnContentTypeSave)
				{
					Concrete c = new Concrete();
					c.BuildMediaTypes();
					var contentClasses = c.BuildContentTypes();

					if (ConcreteSettings.Current.GenerateContentServices)
						c.BuildServiceClasses(contentClasses);
				}
			}
			catch (Exception ex)
			{
				LogHelper.Error<UmbracoEvents>("Error generating Concrete models on ContentType save", ex);
			}
		}

		#endregion

		#region

		private void AttachToContentServiceEvents()
		{
			ContentService.Published += ContentService_Published;
			ContentService.UnPublished += ContentService_UnPublished;
			ContentService.Trashed += ContentService_Trashed;
			ContentService.Deleted += ContentService_Deleted;
			ContentService.Moved += ContentService_Moved;
			ContentService.RolledBack += ContentService_RolledBack;
		}

		void ContentService_Published(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
		{
			e.PublishedEntities.ForEach(x => ConcreteContext.Current.Cache.RemoveItem(x.Id));
		}

		void ContentService_UnPublished(Umbraco.Core.Publishing.IPublishingStrategy sender, Umbraco.Core.Events.PublishEventArgs<Umbraco.Core.Models.IContent> e)
		{
			e.PublishedEntities.ForEach(x => ConcreteContext.Current.Cache.RemoveItem(x.Id));
		}

		void ContentService_Trashed(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
		{
			e.MoveInfoCollection.ForEach(x => ConcreteContext.Current.Cache.RemoveItem(x.Entity.Id));
		}

		void ContentService_Deleted(IContentService sender, Umbraco.Core.Events.DeleteEventArgs<Umbraco.Core.Models.IContent> e)
		{
			e.DeletedEntities.ForEach(x => ConcreteContext.Current.Cache.RemoveItem(x.Id));
		}

		void ContentService_Moved(IContentService sender, Umbraco.Core.Events.MoveEventArgs<Umbraco.Core.Models.IContent> e)
		{
			e.MoveInfoCollection.ForEach(x => ConcreteContext.Current.Cache.RemoveItem(x.Entity.Id));
		}

		void ContentService_RolledBack(IContentService sender, Umbraco.Core.Events.RollbackEventArgs<Umbraco.Core.Models.IContent> e)
		{
			ConcreteContext.Current.Cache.RemoveItem(e.Entity.Id);
		}

		#endregion

	}
}
