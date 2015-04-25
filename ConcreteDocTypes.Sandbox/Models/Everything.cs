
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class Everything : UmbracoContent
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

		public Everything()
			: base()
		{
		}

		public Everything(int contentId)
			: base(contentId)
		{
		}

		public Everything(IPublishedContent content)
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

