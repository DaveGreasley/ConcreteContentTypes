
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
using ConcreteContentTypes.Core.Interfaces;

namespace ConcreteContentTypes.Sandbox.Models
{
	 [NodeTypeAlias("UmbracoContent")]
 	public class UmbracoContent : IUmbracoContent
	{
		 [Field("nodeName")]
 		public string Name { get; set; }
		 [Field("id")]
 		public new int Id { get; set; }
		 [Field("createDate")]
 		public DateTime CreateDate { get; set; }
		 [Field("updateDate")]
 		public DateTime UpdateDate { get; set; }
		 [Field("__path")]
 		public new string Path { get; set; }
		
 		public UmbracoContent()
			: base()
 		{
 		}
 
 		public UmbracoContent(int contentId)
 		{
 		}
 
 		public UmbracoContent(IPublishedContent content)
 		{
 		}

		protected virtual void Init()
		{
			 
			this.Name = this.Content.Name;
			 
			this.Id = this.Content.Id;
			 
			this.CreateDate = this.Content.CreateDate;
			 
			this.UpdateDate = this.Content.UpdateDate;
			 
			this.Path = this.Content.Path;
					}

		public virtual IContent SetProperties(IContent dbContent)
		{
			 
			dbContent.Name = this.Name;
			 
			dbContent.Id = this.Id;
			 
			dbContent.CreateDate = this.CreateDate;
			 
			dbContent.UpdateDate = this.UpdateDate;
			 
			dbContent.Path = this.Path;

			return dbContent;
		}

		public IPublishedContent Content
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Init(int contentId)
		{
			throw new NotImplementedException();
		}

		public void Init(IPublishedContent content)
		{
			throw new NotImplementedException();
		}
	}
} 
