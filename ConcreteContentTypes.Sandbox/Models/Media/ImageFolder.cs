
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

using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Media
{
	 [NodeTypeAlias("ImageFolder")]
 	public partial class ImageFolder : Folder
	{
		public override string ContentTypeAlias { get { return "ImageFolder"; } }

		
		
		private IEnumerable<Image> _children = null;
		public IEnumerable<Image> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children.Select(x => new Image(x));

				return _children;
			}
		}

		public ImageFolder()
			: base()
		{
		}

		public ImageFolder(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public ImageFolder(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public ImageFolder(int contentId)
			: base(contentId)
		{
		}

		public ImageFolder(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
			
		}

	}
}

