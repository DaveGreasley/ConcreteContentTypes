
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class Everything 	{
				protected UmbracoHelper _helper;
		
		public IPublishedContent Content { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string Url { get; set; }

		
				
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
					
						_blogAuthor = new BlogAuthor(contentId.Value);

					
					}	
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

		
		public Everything()
		{
			
		}

		public Everything(int contentId)
		{
			_helper = new UmbracoHelper(UmbracoContext.Current);
			this.Content = _helper.TypedContent(contentId);

			Init();
		}

		public Everything(IPublishedContent content)
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

