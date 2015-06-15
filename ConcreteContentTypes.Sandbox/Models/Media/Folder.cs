
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using Umbraco.Examine.Linq.Attributes;


namespace ConcreteContentTypes.Sandbox.Models.Media
{
	 [NodeTypeAlias("Folder")]
 	public partial class Folder : UmbracoMedia
	{
		
		
		public Folder()
			: base()
		{
		}

		public Folder(int contentId)
			: base(contentId)
		{
		}

		public Folder(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
			
			return base.SetProperties(dbContent);
		}
	}
}

