using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace ConcreteContentTypes.Core.ViewTemplates
{
	public class ConcreteViewPage<T> : UmbracoTemplatePage where T : UmbracoContent, new()
	{
		public new T Model { get; set; }

		/// <summary>
		/// Don't allow access to Dynamic object!
		/// </summary>
		public new T CurrentPage { get; set; }

		/// <summary>
		/// Access the the Umbraco Render Model.
		/// </summary>
		public RenderModel RenderModel { get { return base.Model; } }

		public ConcreteViewPage()
		{
		}

		protected override void InitializePage()
		{
			base.InitializePage();

			this.Model = new T();
			this.Model.Init(base.Model.Content);

			this.CurrentPage = Model;
		}


		public override void Execute()
		{
		}
	}
}
