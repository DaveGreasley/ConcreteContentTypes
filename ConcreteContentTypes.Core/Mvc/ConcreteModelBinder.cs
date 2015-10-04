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
			if (!controllerContext.RouteData.DataTokens.ContainsKey("umbraco"))
				return null;

			var renderModel = controllerContext.RouteData.DataTokens["umbraco"] as RenderModel;
			if (renderModel != null)
				return ConcreteModelFactory.Current.CreateModel(renderModel.Content);

			return null;
		}
	}
}
