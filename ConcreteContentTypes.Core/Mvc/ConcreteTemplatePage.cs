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

namespace ConcreteContentTypes.Core.ViewTemplates
{
	public class ConcreteTemplatePage<TModel> : UmbracoTemplatePage where TModel : ConcreteModel, new()
	{
		/// <summary>
		/// The <typeparam name="T">Concrete Model</typeparam> that represents the Current Page
		/// </summary>
		public new TModel Model { get; set; }

		/// <summary>
		/// Access to the Umbraco Render Model.
		/// </summary>
		public RenderModel RenderModel { get { return base.Model; } }

		public ConcreteTemplatePage()
		{
		}

		protected override void InitializePage()
		{
			base.InitializePage();

			if (base.Model is ConcreteRenderModel<TModel>)
			{
				ConcreteRenderModel<TModel> renderModel = (ConcreteRenderModel<TModel>)base.Model;

				this.Model = renderModel.Model;
			}
			else
			{
				this.Model = base.Model.Content.As<TModel>();
			}
		}

		public override void Execute()
		{
		}
	}
}
