
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
	 [NodeTypeAlias("BlogAuthor")]
 	public partial class BlogAuthor : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogAuthor"; } }

				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("jobTitle")]
		public string JobTitle { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("shortBio")]
		public string ShortBio { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("bioFull")]
		public IHtmlString BioFull { get; set; } 		
		
		private Address _address = null;
		public Address Address
		{
			get 
			{
				if (_address == null)
				{
								
					var content = this.Content.GetPropertyValue<IPublishedContent>("address");

					if (content == null)
						return new Address();

					_address = new Address(content);
				}

				return _address;
			}
		} 
		
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

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.JobTitle = Content.GetPropertyValue<string>("jobTitle");
						
			this.ShortBio = Content.GetPropertyValue<string>("shortBio");
						
			this.BioFull = Content.GetPropertyValue<IHtmlString>("bioFull");
			
		}

	}
}

