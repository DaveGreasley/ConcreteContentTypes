using ConcreteContentTypes.Core.ModelFactory;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;

namespace ConcreteContentTypes.Core.Mvc
{
	public class RequestModelCache
	{
		public const string HttpItemsKey = "ConcreteRequestModelCache";

		public bool IsRenderMvcRequest { get; set; }
		public RenderModel RenderModel { get; set; }
		public ConcreteModel ConcreteModel { get; set; }

		public RequestModelCache(RenderModel renderModel)
		{
			this.IsRenderMvcRequest = false;
			this.RenderModel = renderModel;
			this.ConcreteModel = ConcreteModelFactory.Current.CreateModel(renderModel.Content);
		}

		public RequestModelCache(ConcreteModel concreteModel)
		{
			this.IsRenderMvcRequest = true;
			this.RenderModel = new RenderModel(concreteModel.Content);
			this.ConcreteModel = concreteModel;
		}
	}
}
