
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("TextPage")]
 	public partial class TextPage : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "TextPage"; } }

				
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

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.content = new GridContent("content", this.Content);
			
		}

	}
}

