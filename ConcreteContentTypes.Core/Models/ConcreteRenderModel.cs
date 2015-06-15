using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace ConcreteContentTypes.Core.Models
{
	public class ConcreteRenderModel<T> : RenderModel where T : IConcreteContent, new()
	{
		public T Model { get; set; }

		public ConcreteRenderModel()
			: base(UmbracoContext.Current.PublishedContentRequest.PublishedContent)
		{
			this.Model = new T();
			this.Model.Init(this.Content);
		}

		public ConcreteRenderModel(IPublishedContent content)
			: base(content)
		{
			this.Model = new T();
			this.Model.Init(content);
		}

		public ConcreteRenderModel(T content)
			: base (content.Content)
		{
			this.Model = content;
		}
	}
}
