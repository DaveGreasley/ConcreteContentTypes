using ConcreteContentTypes.Core.Factory;
using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using ConcreteContentTypes.Core.Extensions;
using ConcreteContentTypes.Core.Helpers;

namespace ConcreteContentTypes.Core.ViewTemplates
{
	public class ConcreteViewPage<T> : UmbracoTemplatePage where T : class, IConcreteModel, new()
	{
		public new T Model { get; set; }
		public ConcreteHelper Concrete { get; set; }

		/// <summary>
		/// Access to the Umbraco Render Model.
		/// </summary>
		public RenderModel RenderModel { get { return base.Model; } }

		public ConcreteViewPage()
		{
		}

		protected override void InitializePage()
		{
			base.InitializePage();

			this.Model = base.Model.Content.As<T>();
			this.Concrete = ConcreteContext.Current.Helper;
		}


		public override void Execute()
		{
		}
	}
}
