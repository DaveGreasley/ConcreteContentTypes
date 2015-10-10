using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Models;
using ConcreteContentTypes.Core.Extensions;
using ConcreteContentTypes.Core.ModelFactory;
using Umbraco.Web.Routing;

namespace ConcreteContentTypes.Core.Mvc
{
	public class ConcreteModelBinder : IModelBinder
	{
		public ConcreteModelBinder()
		{

		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (controllerContext == null || bindingContext == null)
				return null;

			//if (bindingContext.ModelType.IsAssignableFrom(typeof(ConcreteModel)))
			if (typeof(ConcreteModel).IsAssignableFrom(bindingContext.ModelType))
				return BindConcreteModel(controllerContext, bindingContext);

			return null;
		}

		private object BindConcreteModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			//First lets check if there was a value passed in to the controller
			if (controllerContext.RouteData.Values.ContainsKey(bindingContext.ModelName))
			{
				var paramValue = controllerContext.RouteData.Values[bindingContext.ModelName];

				if (paramValue != null)
					return paramValue;
			}

			if (controllerContext.RouteData.DataTokens.ContainsKey("umbraco-doc-request"))
			{
				var publishedContentRequest = controllerContext.RouteData.DataTokens["umbraco-doc-request"] as PublishedContentRequest;
				if (publishedContentRequest != null)
					return ConcreteModelFactory.Current.CreateModel(publishedContentRequest.PublishedContent);
			}

			// Finally if all else fails, return a new instance of the requested type
			return ConcreteModelFactory.Current.CreateModel(bindingContext.ModelType);
		}
	}
}
