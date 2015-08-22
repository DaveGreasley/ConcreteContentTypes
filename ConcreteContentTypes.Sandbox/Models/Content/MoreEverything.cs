
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
using RJP.MultiUrlPicker.Models;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("MoreEverything")]
 	public partial class MoreEverything : Everything
	{
		public override string ContentTypeAlias { get { return "MoreEverything"; } }

				
		
				
		
		[Field("umbracoNaviHide")]
		public bool HideInBottomNavigation { get; set; } 		
		
		private List<IPublishedContent> _multipleNodes = null;
		public List<IPublishedContent> MultipleNodes
		{
			get 
			{
				if (_multipleNodes == null)
				{
					_multipleNodes = new List<IPublishedContent>();

					string val = Content.GetPropertyValue<string>("multipleNodes", this.GetPropertiesRecursively);

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

					string val = Content.GetPropertyValue<string>("blogAuthors", this.GetPropertiesRecursively);

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
		
		private IPublishedContent _mediaPicker = null;
		public IPublishedContent MediaPicker
		{
			get 
			{
				if (_mediaPicker == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("mediaPicker", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_mediaPicker = UmbracoContext.Current.MediaCache.GetById(contentId.Value);
				
						
					}	
				}
				return _mediaPicker;
			}
		} 		
		
				
		[Required] 
		[Field("namesCheckBox")]
		public string NamesCheckBox { get; set; } 		
		
		private List<Address> _addresses = null;
		public List<Address> Addresses
		{
			get 
			{
				if (_addresses == null)
				{
									
					_addresses = new List<Address>();

					var content = this.Content.GetPropertyValue<List<IPublishedContent>>("addresses", this.GetPropertiesRecursively);

					if (content != null)
						_addresses = content.As<Address>().ToList();

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

					var content = this.Content.GetPropertyValue<List<IPublishedContent>>("nestedBlogAuthor", this.GetPropertiesRecursively);

					if (content != null)
						_nestedBlogAuthor = content.As<BlogAuthor>().ToList();

				}

				return _nestedBlogAuthor;
			}
		} 		
		
		private List<Image> _multipleMediaPicker = null;
		public List<Image> MultipleMediaPicker
		{
			get 
			{
				if (_multipleMediaPicker == null)
				{
					_multipleMediaPicker = new List<Image>();

					string val = Content.GetPropertyValue<string>("multipleMediaPicker", this.GetPropertiesRecursively);

					if (!string.IsNullOrEmpty(val))
					{
						string[] contentIds = val.Split(',');

						foreach (string id in contentIds)
						{ 
							_multipleMediaPicker.Add(new Image(int.Parse(id))); 
					    }
					}
				}

				return _multipleMediaPicker;
			}
		} 		
		
		/// <summary>
		/// An RJP Multi URL Picker
		/// </summary> 		
		
		[Field("multiUrls")]
		public MultiUrls MultiUrls { get; set; } 
		
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

		public MoreEverything()
			: base()
		{
		}

		public MoreEverything(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public MoreEverything(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public MoreEverything(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public MoreEverything(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.HideInBottomNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide", this.GetPropertiesRecursively);
						
			this.NamesCheckBox = Content.GetPropertyValue<string>("namesCheckBox", this.GetPropertiesRecursively);
						
			this.MultiUrls = Content.GetPropertyValue<MultiUrls>("multiUrls", this.GetPropertiesRecursively);
			
		}

	}
}

