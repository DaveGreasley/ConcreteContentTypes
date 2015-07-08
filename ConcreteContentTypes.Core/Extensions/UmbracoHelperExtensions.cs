using ConcreteContentTypes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Extensions
{
	public static class UmbracoHelperExtensions
	{
		public static T ConcreteModel<T>(this UmbracoHelper helper, int contentId) where T : class, IConcreteModel, new()
		{
			T model = new T();
			model.Init(contentId);

			return model;
		}
	}
}
