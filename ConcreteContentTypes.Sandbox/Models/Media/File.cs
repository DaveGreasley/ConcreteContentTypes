
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
	 [NodeTypeAlias("File")]
 	public partial class File : UmbracoMedia
	{
		public override string ContentTypeAlias { get { return "File"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoFile")]
		public string UploadFile { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoExtension")]
		public string Type { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoBytes")]
		public string Size { get; set; } 
		
		public File()
			: base()
		{
		}

		public File(int contentId)
			: base(contentId)
		{
		}

		public File(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.UploadFile = Content.GetPropertyValue<string>("umbracoFile");
						
			this.Type = Content.GetPropertyValue<string>("umbracoExtension");
						
			this.Size = Content.GetPropertyValue<string>("umbracoBytes");
			
		}

	}
}

