using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ConcreteContentTypes.Core.WebApi
{
	public class ConcreteContentTypesApiController : UmbracoAuthorizedApiController
	{
		[HttpGet]
		public void Compile()
		{
			Compiler.Compiler c = new Compiler.Compiler();
			c.BuildContentTypes();
		}
	}
}