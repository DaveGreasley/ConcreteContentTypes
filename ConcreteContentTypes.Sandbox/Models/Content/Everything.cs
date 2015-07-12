
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

using ConcreteContentTypes.Sandbox.Models.Media;
using Umbraco.Examine.Linq.Attributes;


namespace ConcreteContentTypes.Sandbox.Models.Content
{
	 [NodeTypeAlias("Everything")]
 	public partial class Everything : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Everything"; } }

				
		
				
		
		[Field("approvedcolour")]
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
		
				
		
		[Field("checkboxList")]
		public string CheckboxList { get; set; } 		
		
				
		
		[Field("dateTimePicker")]
		public DateTime DateTimePicker { get; set; } 		
		
				
		
		[Field("myLabel")]
		public string MyLabel { get; set; } 		
		
				
		
		[Field("myNumeric")]
		public int MyNumeric { get; set; } 		
		
				
		
		[Field("myRichtextEditor")]
		public IHtmlString MyRichtextEditor { get; set; } 		
		
				
		
		[Field("multipleTextBox")]
		public string MultipleTextBox { get; set; } 		
		
				
		
		[Field("textString")]
		public string TextString { get; set; } 		
		
				
		
		[Field("yesOrNo")]
		public bool YesOrNo { get; set; } 
		
		private IEnumerable<MoreEverything> _children = null;
		public IEnumerable<MoreEverything> Children
		{
			get
			{
				if (_children == null)
					_children = this.Content.Children.Select(x => new MoreEverything(x));

				return _children;
			}
		}

		public Everything()
			: base()
		{
		}

		public Everything(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Everything(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Everything(int contentId)
			: base(contentId)
		{
		}

		public Everything(IPublishedContent content)
			: base(content)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
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

	}
}

