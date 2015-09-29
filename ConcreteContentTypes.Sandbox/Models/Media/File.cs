
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
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Media
{
	 [NodeTypeAlias("File")]
 	public partial class File : UmbracoMedia
	{
		public override string ContentTypeAlias { get { return "File"; } }

				
		
				
		
		[Field("umbracoFile")]
		public string UploadFile { get; set; } 		
		
				
		
		[Field("umbracoExtension")]
		public string Type { get; set; } 		
		
				
		
		[Field("umbracoBytes")]
		public string Size { get; set; } 
		
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

		public File()
			: base()
		{
		}

		public File(string name, ConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public File(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public File(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public File(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.UploadFile = Content.GetPropertyValue<string>("umbracoFile", this.GetPropertiesRecursively);
						
			this.Type = Content.GetPropertyValue<string>("umbracoExtension", this.GetPropertiesRecursively);
						
			this.Size = Content.GetPropertyValue<string>("umbracoBytes", this.GetPropertiesRecursively);
			
		}

	}
}

