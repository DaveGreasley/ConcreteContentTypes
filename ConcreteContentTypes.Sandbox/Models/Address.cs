
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
	public partial class Address : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public string AddressLine1 { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public string City { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public string PostCode { get; set; } 
		
		public Address()
			: base()
		{
		}

		public Address(int contentId)
			: base(contentId)
		{
		}

		public Address(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.AddressLine1 = Content.GetPropertyValue<string>("addressLine1");
						
			this.City = Content.GetPropertyValue<string>("city");
						
			this.PostCode = Content.GetPropertyValue<string>("postCode");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("addressLine1", this.AddressLine1);
						
			dbContent.SetValue("city", this.City);
						
			dbContent.SetValue("postCode", this.PostCode);
			
			return base.SetProperties(dbContent);
		}
	}
}

