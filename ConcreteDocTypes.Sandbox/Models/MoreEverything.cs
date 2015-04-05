
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class MoreEverything  : Everything 	{
		
				
		
		private List<IPublishedContent> _multipleNodes = null;
		public List<IPublishedContent> multipleNodes
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
							
								_multipleNodes.Add(_helper.TypedContent(id));
				
								
						}
					}	
				}

				return _multipleNodes;
			}
		}

				
		
		private List<BlogAuthor> _blogAuthors = null;
		public List<BlogAuthor> blogAuthors
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

		
		public MoreEverything()
		{
			
		}

		public MoreEverything(int contentId)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = _helper.TypedContent(contentId);

			Init();
		}

		public MoreEverything(IPublishedContent content)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = content;

			Init();
		}

		private void Init()
		{
			this.Name = this.Content.Name;
			this.Id = this.Content.Id;
			this.CreateDate = this.Content.CreateDate;
			this.UpdateDate = this.Content.UpdateDate;
			this.Url = this.Content.Url;

			
		}
	}
}

