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
			var source = viewData.Model;
			if (source == null)
			{
				base.SetViewData(viewData);
				return;
			}

			if (HttpContext.Current.Items.Contains(RequestModelCache.HttpItemsKey))
			{
				var requestModelCache = (RequestModelCache)HttpContext.Current.Items[RequestModelCache.HttpItemsKey];
				viewData.Model = (TModel)requestModelCache.ConcreteModel;
			}
			else
			{
				var sourceModelType = source.GetType();

				if (typeof(RenderModel).IsAssignableFrom(sourceModelType))
				{
					var requestModelCache = new RequestModelCache((RenderModel)viewData.Model);
					HttpContext.Current.Items.Add(RequestModelCache.HttpItemsKey, requestModelCache);
					viewData.Model = (TModel)requestModelCache.ConcreteModel;
				}
				else if (typeof(ConcreteModel).IsAssignableFrom(sourceModelType))
				{
					var requestModelCache = new RequestModelCache((ConcreteModel)viewData.Model);
					HttpContext.Current.Items.Add(RequestModelCache.HttpItemsKey, requestModelCache);
				}
			}

			//Now we have corrected any type mis-matches, call the base to ensure Model property set.
			base.SetViewData(viewData);
		}
	}
}
