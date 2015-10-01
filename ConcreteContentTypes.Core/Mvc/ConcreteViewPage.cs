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
	public class ConcreteViewPage<TModel> : UmbracoViewPage<TModel> where TModel : ConcreteModel, new()
	{
		public ConcreteViewPage()
		{
		}

		public override void Execute()
		{
		}
	}
}
