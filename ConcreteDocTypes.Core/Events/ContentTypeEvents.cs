using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;
using ConcreteContentTypes.Core.Compiler;
using ConcreteContentTypes.Core.Configuration;

namespace ConcreteContentTypes.Core.Events
{
	public class ContentTypeEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
		}

		void ContentTypeService_SavedContentType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContentType> e)
		{
			if (Settings.Current.GenerateOnContentTypeSave)
			{
				Compiler.Compiler c = new Compiler.Compiler();
				c.Build();
			}
		}
	}
}
