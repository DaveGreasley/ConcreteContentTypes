
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

namespace ConcreteContentTypes.Sandbox.Models.Media
{
	public abstract partial class UmbracoMedia : ConcreteModel
	{
		private IPublishedContent _content = null;
		[JsonIgnore]
		public override IPublishedContent Content
		{
			get
			{
				if (_content == null && this.Id != 0)
					_content = UmbracoContext.Current.MediaCache.GetById(this.Id);

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

		public UmbracoMedia()
			: base()
		{
		}

		public UmbracoMedia(int contentId, bool getPropertiesRecursively = false)
		{
			this.GetPropertiesRecursively = getPropertiesRecursively;

			Init(contentId);
		}

		public UmbracoMedia(IPublishedContent content, bool getPropertiesRecursively = false)
		{
			this.GetPropertiesRecursively = getPropertiesRecursively;

			Init(content);
		}

		public override void Init(int contentId)
		{
			IPublishedContent content = UmbracoContext.Current.MediaCache.GetById(contentId);

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

		private int GetParentId(string path)
		{
			//First try and get parent id from the path
			var pathElements = path.Split(',');

			if (pathElements != null && pathElements.Count() >= 2)
			{
				var parentId = pathElements[pathElements.Length - 2];

				if (!string.IsNullOrWhiteSpace(parentId))
					return Convert.ToInt32(parentId);
			}

			//If that doesn't work then get it from the parent content object. 
			return this.Content != null && this.Content.Parent != null ? this.Content.Parent.Id : -1;
		}

		#endregion

	}
}
