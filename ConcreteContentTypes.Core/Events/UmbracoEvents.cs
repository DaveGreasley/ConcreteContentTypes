using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;
using ConcreteContentTypes.Core.Configuration;
using Umbraco.Core.Logging;

namespace ConcreteContentTypes.Core.Events
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
		}

		void ContentTypeService_SavedContentType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContentType> e)
		{
			try
			{
				if (ConcreteSettings.Current.GenerateOnContentTypeSave)
				{
					Concrete c = new Concrete();
					c.BuildContentTypes();
				}
			}
			catch (Exception ex)
			{
				LogHelper.Error<UmbracoEvents>("Error generating Concrete models on ContentType save", ex);
			}
		}
	}
}
