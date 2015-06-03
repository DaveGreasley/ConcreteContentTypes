using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace ConcreteContentTypes.Core.Models
{
	public class ConcreteRenderModel<T> : RenderModel where T : UmbracoContent, new()
	{
		public new T Model { get; set; }

		public ConcreteRenderModel()
			: base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.Model = new T();
			this.Model.Init(this.Content);
		}

		public ConcreteRenderModel(T content)
			: base (content.Content)
		{
			this.Model = content;
		}
	}
}
