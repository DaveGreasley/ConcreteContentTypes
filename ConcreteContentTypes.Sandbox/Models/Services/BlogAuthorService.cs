
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class BlogAuthorService : ServiceBase<BlogAuthor>
	{
		public override string ContentTypeAlias
		{
			get { return "BlogAuthor"; }
		}

		public BlogAuthorService()
			: base()
		{

		}

		public BlogAuthorService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(BlogAuthor content, IContent dbContent)
		{
						
			dbContent.SetValue("jobTitle", content.JobTitle);
						
			dbContent.SetValue("shortBio", content.ShortBio);
						
			dbContent.SetValue("bioFull", content.BioFull);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}