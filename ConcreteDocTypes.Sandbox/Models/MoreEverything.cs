
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class MoreEverything : Everything
	{
				
		public string approvedcolour { get; set; } 		
		
		private BlogAuthor _blogAuthor = null;
		public BlogAuthor blogAuthor
		{
			get 
			{
				if (_blogAuthor == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("blogAuthor");

					if (contentId.HasValue)
					{
					
						_blogAuthor = new BlogAuthor(contentId.Value); 					}	
				}
				return _blogAuthor;
			}
		} 		
		public DateTime dateTimePicker { get; set; } 		
		public string myLabel { get; set; } 		
		public int myNumeric { get; set; } 		
		public IHtmlString myRichtextEditor { get; set; } 		
		public string multipleTextBox { get; set; } 		
		public string textString { get; set; } 		
		public bool yesOrNo { get; set; } 		
		
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
							_multipleNodes.Add(UmbracoContext.Current.ContentCache.GetById(int.Parse(id)));
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
						
			this.approvedcolour = Content.GetPropertyValue<string>("approvedcolour");
						
			this.dateTimePicker = Content.GetPropertyValue<DateTime>("dateTimePicker");
						
			this.myLabel = Content.GetPropertyValue<string>("myLabel");
						
			this.myNumeric = Content.GetPropertyValue<int>("myNumeric");
						
			this.myRichtextEditor = Content.GetPropertyValue<IHtmlString>("myRichtextEditor");
						
			this.multipleTextBox = Content.GetPropertyValue<string>("multipleTextBox");
						
			this.textString = Content.GetPropertyValue<string>("textString");
						
			this.yesOrNo = Content.GetPropertyValue<bool>("yesOrNo");
			
		}
	}
}

