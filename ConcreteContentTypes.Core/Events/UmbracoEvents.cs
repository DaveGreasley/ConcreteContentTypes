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
using Umbraco.Web.Routing;
using System.Reflection;
using System.IO;
using ConcreteContentTypes.Core.DynamicLoading;

namespace ConcreteContentTypes.Core.Events
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			LoadModelsDll(applicationContext);

			//Attach to ContentTypeService events for Model creation
			AttachToContentTypeServiceEvents();
		}

		private void LoadModelsDll(ApplicationContext applicationContext)
		{
		}

		

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

					c.BuildAssembly();
				}
			}
			catch (Exception ex)
			{
				LogHelper.Error<UmbracoEvents>("Error generating Concrete models on ContentType save", ex);
			}
		}

		#endregion

	}
}
