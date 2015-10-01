using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Models;
using ConcreteContentTypes.Core.Extensions;

namespace ConcreteContentTypes.Core.Mvc
{
	public class ConcreteModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelType.IsAssignableFrom(typeof(ConcreteModel)))
				return BindConcreteModel(controllerContext, bindingContext);

			return null;
		}

		private object BindConcreteModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (!controllerContext.RouteData.DataTokens.ContainsKey("umbraco"))
				return null;

			var renderModel = controllerContext.RouteData.DataTokens["umbraco"] as RenderModel;

			if (renderModel != null)
				return ConcreteModelFactory.CreateModel(renderModel.Content);

			return null;
		}
	}
}
