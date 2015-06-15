
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


namespace ConcreteContentTypes.Sandbox.Models.Media
{
	 [NodeTypeAlias("ImageFolder")]
 	public partial class ImageFolder : Folder
	{
		
		private IEnumerable<Image> _children = null;
		public new IEnumerable<Image> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new Image(x));
				}

				return _children;
			}
		}
		
		public ImageFolder()
			: base()
		{
		}

		public ImageFolder(int contentId)
			: base(contentId)
		{
		}

		public ImageFolder(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
			
			return base.SetProperties(dbContent);
		}
	}
}

