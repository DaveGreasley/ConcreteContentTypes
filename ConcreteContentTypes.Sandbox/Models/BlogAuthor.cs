
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
	public partial class BlogAuthor : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public string JobTitle { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public string ShortBio { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public IHtmlString BioFull { get; set; } 
		
		public BlogAuthor()
			: base()
		{
		}

		public BlogAuthor(int contentId)
			: base(contentId)
		{
		}

		public BlogAuthor(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.JobTitle = Content.GetPropertyValue<string>("jobTitle");
						
			this.ShortBio = Content.GetPropertyValue<string>("shortBio");
						
			this.BioFull = Content.GetPropertyValue<IHtmlString>("bioFull");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("jobTitle", this.JobTitle);
						
			dbContent.SetValue("shortBio", this.ShortBio);
						
			dbContent.SetValue("bioFull", this.BioFull);
			
			return base.SetProperties(dbContent);
		}
	}
}

