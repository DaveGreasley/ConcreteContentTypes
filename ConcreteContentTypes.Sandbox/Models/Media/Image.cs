
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
	 [NodeTypeAlias("Image")]
 	public partial class Image : UmbracoMedia
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoFile")]
		public string UploadImage { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoWidth")]
		public string Width { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoHeight")]
		public string Height { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoBytes")]
		public string Size { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoExtension")]
		public string Type { get; set; } 
		
		public Image()
			: base()
		{
		}

		public Image(int contentId)
			: base(contentId)
		{
		}

		public Image(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.UploadImage = Content.GetPropertyValue<string>("umbracoFile");
						
			this.Width = Content.GetPropertyValue<string>("umbracoWidth");
						
			this.Height = Content.GetPropertyValue<string>("umbracoHeight");
						
			this.Size = Content.GetPropertyValue<string>("umbracoBytes");
						
			this.Type = Content.GetPropertyValue<string>("umbracoExtension");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("umbracoFile", this.UploadImage);
						
			dbContent.SetValue("umbracoWidth", this.Width);
						
			dbContent.SetValue("umbracoHeight", this.Height);
						
			dbContent.SetValue("umbracoBytes", this.Size);
						
			dbContent.SetValue("umbracoExtension", this.Type);
			
			return base.SetProperties(dbContent);
		}
	}
}

