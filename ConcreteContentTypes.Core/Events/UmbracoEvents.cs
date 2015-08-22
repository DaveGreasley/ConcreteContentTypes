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
using ConcreteContentTypes.Core.ModelGeneration.Generators;
using System.Web.Configuration;

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
			if (IsInDebugMode())
			{
				ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
				ContentTypeService.SavedMediaType += ContentTypeService_SavedMediaType;
			}
		}

		private bool IsInDebugMode()
		{
			CompilationSection compilationSection = (CompilationSection)System.Configuration.ConfigurationManager.GetSection(@"system.web/compilation");
			return compilationSection.Debug;
		}

		void ContentTypeService_SavedMediaType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IMediaType> e)
		{
			try
			{
				if (ConcreteSettings.Current.GenerateOnMediaTypeSave)
					RegenerateAllModels();
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
					RegenerateAllModels();
			}
			catch (Exception ex)
			{
				LogHelper.Error<UmbracoEvents>("Error generating Concrete models on ContentType save", ex);
			}
		}

		//Currently we regenerate all Media and all Content models every time we save either.
		void RegenerateAllModels()
		{
			//Generate Media models first as they are used by Content models
			MediaTypeModelsGenerator mediaModelsGenerator = new MediaTypeModelsGenerator();
			mediaModelsGenerator.GenerateModels();

			ContentTypeModelsGenerator contentModelsGenerator = new ContentTypeModelsGenerator();
			contentModelsGenerator.GenerateModels();
		}

		#endregion

	}
}
