
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;


namespace ConcreteContentTypes.Sandbox.Models
{
	public partial class Everything : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		public string Approvedcolour { get; set; } 		
		
		private BlogAuthor _blogAuthor = null;
		public BlogAuthor BlogAuthor
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
		
		/// <summary>
		/// 
		/// </summary>
		
		public string CheckboxList { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public DateTime DateTimePicker { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public string MyLabel { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public int MyNumeric { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public IHtmlString MyRichtextEditor { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public string MultipleTextBox { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public string TextString { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		public bool YesOrNo { get; set; } 
		private IEnumerable<MoreEverything> _children = null;
		public new IEnumerable<MoreEverything> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new MoreEverything(x));
				}

				return _children;
			}
		}
		
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
						
			this.Approvedcolour = Content.GetPropertyValue<string>("approvedcolour");
						
			this.CheckboxList = Content.GetPropertyValue<string>("checkboxList");
						
			this.DateTimePicker = Content.GetPropertyValue<DateTime>("dateTimePicker");
						
			this.MyLabel = Content.GetPropertyValue<string>("myLabel");
						
			this.MyNumeric = Content.GetPropertyValue<int>("myNumeric");
						
			this.MyRichtextEditor = Content.GetPropertyValue<IHtmlString>("myRichtextEditor");
						
			this.MultipleTextBox = Content.GetPropertyValue<string>("multipleTextBox");
						
			this.TextString = Content.GetPropertyValue<string>("textString");
						
			this.YesOrNo = Content.GetPropertyValue<bool>("yesOrNo");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("approvedcolour", this.Approvedcolour);
						
			dbContent.SetValue("checkboxList", this.CheckboxList);
						
			dbContent.SetValue("dateTimePicker", this.DateTimePicker);
						
			dbContent.SetValue("myLabel", this.MyLabel);
						
			dbContent.SetValue("myNumeric", this.MyNumeric);
						
			dbContent.SetValue("myRichtextEditor", this.MyRichtextEditor);
						
			dbContent.SetValue("multipleTextBox", this.MultipleTextBox);
						
			dbContent.SetValue("textString", this.TextString);
						
			dbContent.SetValue("yesOrNo", this.YesOrNo);
			
			return base.SetProperties(dbContent);
		}
	}
}

