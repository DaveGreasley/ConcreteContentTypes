
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using System;
using Newtonsoft.Json.Linq;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("BlogPost")]
 	public partial class BlogPost : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "BlogPost"; } }

				
		
		private Image _image = null;
		public Image Image
		{
			get 
			{
				if (_image == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("image", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_image = new Image(contentId.Value); 
					}	
				}
				return _image;
			}
		} 		
		[JsonIgnore]
		public GridContent content { get; set; } 		
		
				
		
		[Field("introduction")]
		public string Introduction { get; set; } 		
		
		private BlogAuthor _author = null;
		public BlogAuthor Author
		{
			get 
			{
				if (_author == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("author", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_author = new BlogAuthor(contentId.Value); 
					}	
				}
				return _author;
			}
		} 		
		
		private IPublishedContent _linkedPage = null;
		public IPublishedContent LinkedPage
		{
			get 
			{
				if (_linkedPage == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("linkedPage", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_linkedPage = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _linkedPage;
			}
		} 
		
		private IEnumerable<BlogComment> _children = null;
		public IEnumerable<BlogComment> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children.Select(x => new BlogComment(x));

				return _children;
			}
		}

		public BlogPost()
			: base()
		{
		}

		public BlogPost(string name, ConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public BlogPost(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public BlogPost(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public BlogPost(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.content = new GridContent("content", this.Content);
						
			this.Introduction = Content.GetPropertyValue<string>("introduction", this.GetPropertiesRecursively);
			
		}

	}
}

