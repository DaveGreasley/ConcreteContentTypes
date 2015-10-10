using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Extensions;
using ConcreteContentTypes.Core.ModelFactory;
using System.Web;

namespace ConcreteContentTypes.Core.Mvc
{
	public class ConcreteViewPage<TModel> : UmbracoViewPage<TModel> where TModel : ConcreteModel, new()
	{
		public ConcreteViewPage()
		{
		}

		public override void Execute()
		{
		}

		protected override void SetViewData(System.Web.Mvc.ViewDataDictionary viewData)
		{
			// if view data contains no model, nothing to do
			if (viewData.Model == null)
			{
				base.SetViewData(viewData);
				return;
			}

			if (typeof(RenderModel).IsAssignableFrom(viewData.Model.GetType()))
			{
				var renderModel = (RenderModel)viewData.Model;
				viewData.Model = ConcreteModelFactory.Current.CreateModel(renderModel.Content);
			}

			if (typeof(ConcreteModel).IsAssignableFrom(viewData.Model.GetType()))
			{
				var concreteModel = (ConcreteModel)viewData.Model;

				if (typeof(TModel) != viewData.Model.GetType() && typeof(TModel) != typeof(ConcreteModel))
				{
					//We have a different Type of ConcreteModel to the one requested so try and convert
					var convertedModel = concreteModel.TryConvertTo(typeof(TModel));
					if (convertedModel != null)
						viewData.Model = convertedModel;
				}
			}

			//Now we have corrected any type mis-matches, call the base to ensure Model property set.
			base.SetViewData(viewData);
		}
	}
}
