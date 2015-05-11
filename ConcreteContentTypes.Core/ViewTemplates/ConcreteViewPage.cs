using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;

namespace ConcreteContentTypes.Core.ViewTemplates
{
	public class ConcreteViewPage<T> : UmbracoTemplatePage where T : UmbracoContent, new()
	{
		public T TypedContent { get; set; }

		public ConcreteViewPage()
		{
		}

		protected override void InitializePage()
		{
			base.InitializePage();

			this.TypedContent = new T();
			this.TypedContent.Init(Model.Content);
		}


		public override void Execute()
		{
		}
	}
}
