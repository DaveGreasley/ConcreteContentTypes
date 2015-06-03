
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
	public partial class MoreEverything : Everything
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public bool HideInBottomNavigation { get; set; } 		
		
		private List<IPublishedContent> _multipleNodes = null;
		public List<IPublishedContent> MultipleNodes
		{
			get 
			{
				if (_multipleNodes == null)
				{
					_multipleNodes = new List<IPublishedContent>();

					string val = Content.GetPropertyValue<string>("multipleNodes");

					if (!string.IsNullOrEmpty(val))
					{
						string[] contentIds = val.Split(',');

						foreach (string id in contentIds)
						{ 
							_multipleNodes.Add(UmbracoContext.Current.ContentCache.GetById(int.Parse(id)));
					    }
					}
				}

				return _multipleNodes;
			}
		} 		
		
		private List<BlogAuthor> _blogAuthors = null;
		public List<BlogAuthor> BlogAuthors
		{
			get 
			{
				if (_blogAuthors == null)
				{
					_blogAuthors = new List<BlogAuthor>();

					string val = Content.GetPropertyValue<string>("blogAuthors");

					if (!string.IsNullOrEmpty(val))
					{
						string[] contentIds = val.Split(',');

						foreach (string id in contentIds)
						{ 
							_blogAuthors.Add(new BlogAuthor(int.Parse(id))); 
					    }
					}
				}

				return _blogAuthors;
			}
		} 		
		
		/// <summary>
		/// 
		/// </summary>
		[Required]
		public string NamesCheckBox { get; set; } 		
		
		private List<Address> _addresses = null;
		public List<Address> Addresses
		{
			get 
			{
				if (_addresses == null)
				{
									
					_addresses = new List<Address>();

					var content = this.Content.GetPropertyValue<List<IPublishedContent>>("addresses");

					if (content != null)
					{
						foreach (var item in content)
						{
							_addresses.Add(new Address(item));
						}
					}

				}

				return _addresses;
			}
		} 		
		
		private List<BlogAuthor> _nestedBlogAuthor = null;
		public List<BlogAuthor> NestedBlogAuthor
		{
			get 
			{
				if (_nestedBlogAuthor == null)
				{
									
					_nestedBlogAuthor = new List<BlogAuthor>();

					var content = this.Content.GetPropertyValue<List<IPublishedContent>>("nestedBlogAuthor");

					if (content != null)
					{
						foreach (var item in content)
						{
							_nestedBlogAuthor.Add(new BlogAuthor(item));
						}
					}

				}

				return _nestedBlogAuthor;
			}
		} 
		
		public MoreEverything()
			: base()
		{
		}

		public MoreEverything(int contentId)
			: base(contentId)
		{
		}

		public MoreEverything(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.NamesCheckBox = Content.GetPropertyValue<string>("namesCheckBox");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("umbracoNaviHide", this.HideInBottomNavigation);
						
			dbContent.SetValue("namesCheckBox", this.NamesCheckBox);
			
			return base.SetProperties(dbContent);
		}
	}
}

