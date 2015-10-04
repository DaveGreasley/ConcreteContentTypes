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
using System.Web.Configuration;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Mvc;
using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.ModelFactory;
using ConcreteContentTypes.Core.SourceModelMapping;
using ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers;
using ConcreteContentTypes.Core.CodeGeneration.Classes.Factories;
using ConcreteContentTypes.Core.CodeGeneration.Attributes;
using ConcreteContentTypes.Core.CodeGeneration.Properties;
using ConcreteContentTypes.Core.FileWriters;
using log4net;
using System.Web.Mvc;

namespace ConcreteContentTypes.Core.Events
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		ApplicationContext ApplicationContext { get; set; }

		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			this.ApplicationContext = applicationContext;

			//Setup our ModelBinder
			var modelBinderProvider = new ConcreteModelBinderProvider() { { typeof(ConcreteModel), new ConcreteModelBinder() } };
			ModelBinderProviders.BinderProviders.Add(modelBinderProvider);

			//Create singleton model factory instance
			InitialiseConcreteFactory();

			//Attach to ContentTypeService events for Model creation
			AttachToContentTypeServiceEvents();
		}

		private void InitialiseConcreteFactory()
		{
			var concreteTypes = PluginManager.Current.ResolveTypes<ConcreteModel>(false);
			var modelTypeResolver = new ConcreteModelTypeResolver(concreteTypes);
			ConcreteModelFactory.Current = new ConcreteModelFactory(modelTypeResolver);
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

		private static bool IsInDebugMode()
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
			var contentTypes = ApplicationContext.Services.ContentTypeService.GetAllContentTypes();
			var mediaTypes = ApplicationContext.Services.ContentTypeService.GetAllMediaTypes();

			var concreteSettings = ConcreteSettings.Current;
			var errorTracker = new ErrorTracker(); 
			var propertyTypeDefaultsSettings = (IPropertyTypeDefaultsSettings)null; //TODO: Implement property default settings
			var concreteEvents = new ConcreteEvents();

			var propertyTypeResolverFactory = new PropertyTypeResolverFactory(propertyTypeDefaultsSettings, errorTracker);
			var contentTypeSourceModelMapper = new ContentTypeSourceModelMapper(
				concreteSettings,
				concreteEvents,
				contentTypes,
				propertyTypeResolverFactory,
				propertyTypeDefaultsSettings
				);

			var mediaSourceModelMapper = new MediaTypesSourceModelMapper(
				concreteSettings, 
				concreteEvents, 
				mediaTypes, 
				propertyTypeResolverFactory,
				propertyTypeDefaultsSettings
				);

			var templateTypeResolver = new TemplateTypeResolver();

			var attributeTemplateFactory = new AttributeTemplateFactory(errorTracker);
			var propertyTemplateFactory = new PropertyTemplateFactory(
				errorTracker, 
				concreteSettings, 
				propertyTypeDefaultsSettings,
				templateTypeResolver);

			var baseClassTemplateFactory = new BaseClassTemplateFactory(errorTracker, attributeTemplateFactory);
			var modelClassTemplateFactory = new ModelClassTemplateFactory(errorTracker, attributeTemplateFactory, propertyTemplateFactory);

			var contentTypeCodeGenerator = new CSharpCodeGeneratorFacade(baseClassTemplateFactory, modelClassTemplateFactory);
			var mediaTypeCodeGenerator = new CSharpCodeGeneratorFacade(baseClassTemplateFactory, modelClassTemplateFactory);

			var fileWriter = new FileWriter();

			//Create Concrete app class
			Concrete concrete = new Concrete(
				concreteSettings,
				contentTypeSourceModelMapper,
				mediaSourceModelMapper,
				contentTypeCodeGenerator,
				mediaTypeCodeGenerator,
				fileWriter,
				errorTracker);

			//Regenerate all models
			concrete.Generate();

			if (errorTracker.FatalErrorHasOccurred)
			{
				//aah! how do we display the error to the users!?
			}
		}

		#endregion

	}
}
