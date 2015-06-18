
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class AddressService : ServiceBase<Address>
	{
		public override string ContentTypeAlias
		{
			get { return "Address"; }
		}

		public AddressService()
			: base()
		{

		}

		public AddressService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(Address content, IContent dbContent)
		{
						
			dbContent.SetValue("addressLine1", content.AddressLine1);
						
			dbContent.SetValue("city", content.City);
						
			dbContent.SetValue("postCode", content.PostCode);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}