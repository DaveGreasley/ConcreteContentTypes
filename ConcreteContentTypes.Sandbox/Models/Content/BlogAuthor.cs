
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

using System;
using System.Web;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("BlogAuthor")]
 	public partial class BlogAuthor : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogAuthor"; } }

				
		
				
		
		[Field("jobTitle")]
		public string JobTitle { get; set; } 		
		
				
		
		[Field("shortBio")]
		public string ShortBio { get; set; } 		
		
				
		
		[Field("bioFull")]
		public IHtmlString BioFull { get; set; } 		
		
		private Address _address = null;
		public Address Address
		{
			get 
			{
				if (_address == null)
				{
								
					var content = this.Content.GetPropertyValue<IPublishedContent>("address", this.GetPropertiesRecursively);

					if (content == null)
						return new Address();

					_address = new Address(content);
				}

				return _address;
			}
		} 		
		
		private List<IPublishedContent> _authorImage = null;
		public List<IPublishedContent> AuthorImage
		{
			get 
			{
				if (_authorImage == null)
				{
					_authorImage = new List<IPublishedContent>();

					string val = Content.GetPropertyValue<string>("authorImage", this.GetPropertiesRecursively);

					if (!string.IsNullOrEmpty(val))
					{
						string[] contentIds = val.Split(',');

						foreach (string id in contentIds)
						{ 
							_authorImage.Add(UmbracoContext.Current.MediaCache.GetById(int.Parse(id)));
					    }
					}
				}

				return _authorImage;
			}
		} 
		
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

		public BlogAuthor()
			: base()
		{
		}

		public BlogAuthor(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public BlogAuthor(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public BlogAuthor(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public BlogAuthor(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.JobTitle = Content.GetPropertyValue<string>("jobTitle", this.GetPropertiesRecursively);
						
			this.ShortBio = Content.GetPropertyValue<string>("shortBio", this.GetPropertiesRecursively);
						
			this.BioFull = Content.GetPropertyValue<IHtmlString>("bioFull", this.GetPropertiesRecursively);
			
		}

	}
}

