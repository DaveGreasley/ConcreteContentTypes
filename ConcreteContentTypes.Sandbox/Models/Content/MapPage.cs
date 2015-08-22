
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

using AngularGoogleMaps;
using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("MapPage")]
 	public partial class MapPage : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "MapPage"; } }

				
		
				
		
		[Field("map")]
		public Model Map { get; set; } 
		
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

		public MapPage()
			: base()
		{
		}

		public MapPage(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public MapPage(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public MapPage(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public MapPage(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.Map = Content.GetPropertyValue<Model>("map", this.GetPropertiesRecursively);
			
		}

	}
}

