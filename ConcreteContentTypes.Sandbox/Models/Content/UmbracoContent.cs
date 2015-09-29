
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;
using ConcreteContentTypes.Core.Models.Enums;
using Umbraco.Core;
using Umbraco.Core.Services;

using ConcreteContentTypes.Core.Extensions;
using Umbraco.Examine.Linq.Attributes;

namespace ConcreteContentTypes.Sandbox.Models.Content
{
	public abstract partial class UmbracoContent : UmbracoContent<SimpleConcreteModel>
	{
		public UmbracoContent()
			: base()
		{
		}

		public UmbracoContent(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public UmbracoContent(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}
	}

	public abstract partial class UmbracoContent<TChild> : ConcreteModel where TChild : ConcreteModel, new()
	{
		private IPublishedContent _content = null;
		[JsonIgnore]
		public override IPublishedContent Content
		{
			get
			{
				if (_content == null && this.Id != 0)
					_content = UmbracoContext.Current.ContentCache.GetById(this.Id);

				return _content;
			}
			set
			{
				_content = value;
			}
		}

		[Field("nodeName")]
		public override string Name { get; set; }

		[Field("id")]
		public override int Id { get; set; }

		public override int ParentId { get; set; }

		public string Path { get; set; }

		[Field("createDate")]
		public DateTime CreateDate { get; set; }

		[Field("updateDate")]
		public DateTime UpdateDate { get; set; }

		public string Url { get; set; }

		#region Constructors and Initalisation

		public UmbracoContent()
			: base()
		{
		}

		public UmbracoContent(int contentId, bool getPropertiesRecursively = false)
		{
			this.GetPropertiesRecursively = getPropertiesRecursively;

			Init(contentId);
		}

		public UmbracoContent(IPublishedContent content, bool getPropertiesRecursively = false)
		{
			this.GetPropertiesRecursively = getPropertiesRecursively;

			Init(content);
		}

		public override void Init(int contentId)
		{
			IPublishedContent content = UmbracoContext.Current.ContentCache.GetById(contentId);

			if (content == null)
				throw new InvalidOperationException(string.Format("Content Id {0} not found in Umbraco Cache", contentId));

			Init(content);
		}

		public override void Init(ConcreteModel model)
		{
			this.Init(model.Content);
		}

		public override void Init(IPublishedContent content)
		{
			this.Content = content;

			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.Path = this.Content.Path;
			this.ParentId = GetParentId(this.Path);
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;
		}

		#endregion

		private IEnumerable<TChild> _children = null;
		public IEnumerable<TChild> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children.As<TChild>();
				else
					_children = new List<TChild>();


				return _children;
			}
		}

	}
}
