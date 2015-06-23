using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace ConcreteContentTypes.ModelFactory
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			ConcreteCache cache = new ConcreteCache();

			var factory = new ConcretePublishedContentModelFactory(cache);
			
			PublishedContentModelFactoryResolver.Current.SetFactory(factory);
			
			base.ApplicationStarted(umbracoApplication, applicationContext);
		}
	}
}
