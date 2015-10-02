
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using System;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	public partial class Address : Address<ConcreteModel>
	{
		public Address()
			: base()
		{
		}

		public Address(string name, ConcreteModel parent)
			: base(name, parent.Id)
		{
		}

		public Address(string name, int parentId)
			: base()
		{
		}

		public Address(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}
	}

	[NodeTypeAlias("Address")]
	public partial class Address<TChild> : UmbracoContent<TChild> where TChild : ConcreteModel
	{
		public override string ContentTypeAlias { get { return "Address"; } }


		public void bob()
		{
		}

		[Required]
		[Field("addressLine1")]
		public string AddressLine1 { get; set; }


		[Required]
		[Field("city")]
		public string City { get; set; }


		[Required]
		[Field("postCode")]
		public string PostCode { get; set; }

		public Address()
			: base()
		{
		}

		public Address(string name, ConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Address(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Address(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Address(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);

			this.AddressLine1 = Content.GetPropertyValue<string>("addressLine1", this.GetPropertiesRecursively);

			this.City = Content.GetPropertyValue<string>("city", this.GetPropertiesRecursively);

			this.PostCode = Content.GetPropertyValue<string>("postCode", this.GetPropertiesRecursively);

		}

	}
}

