
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class TextPage : UmbracoContent
	{
				
		[JsonIgnore]
		public GridContent content { get; set; } 
		
		public TextPage()
			: base()
		{
		}

		public TextPage(int contentId)
			: base(contentId)
		{
		}

		public TextPage(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.content = new GridContent("content", this.Content);
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
			
			return base.SetProperties(dbContent);
		}
	}
}

