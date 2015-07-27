
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Interfaces;
using Newtonsoft.Json;

using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("Address")]
 	public partial class Address : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Address"; } }

				
		
				
		[Required] 
		[Field("addressLine1")]
		public string AddressLine1 { get; set; } 		
		
				
		[Required] 
		[Field("city")]
		public string City { get; set; } 		
		
				
		[Required] 
		[Field("postCode")]
		public string PostCode { get; set; } 
		
		private IEnumerable<IPublishedContent> _children = null;
		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children;

				return _children;
			}
		}

		public Address()
			: base()
		{
		}

		public Address(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Address(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Address(int contentId)
			: base(contentId)
		{
		}

		public Address(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.AddressLine1 = Content.GetPropertyValue<string>("addressLine1");
						
			this.City = Content.GetPropertyValue<string>("city");
						
			this.PostCode = Content.GetPropertyValue<string>("postCode");
			
		}

	}
}

