
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
	 [NodeTypeAlias("Address")]
 	public partial class Address : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Address"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		[Required] 
		[Field("addressLine1")]
		public string AddressLine1 { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required] 
		[Field("city")]
		public string City { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required] 
		[Field("postCode")]
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

	}
}

