﻿using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Sandbox.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace ConcreteContentTypes.Sandbox.Controllers
{
	public class EverythingController : RenderMvcController
	{
		public ActionResult Index(Everything model)
		{
			return View("Everything", model);
		}
	}
}