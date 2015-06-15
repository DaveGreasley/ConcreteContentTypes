
using ConcreteContentTypes.Core.Interfaces;
using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using ConcreteContentTypes.Sandbox.Models.Content;

namespace ConcreteContentTypes.Sandbox.Models.Services
{
	public class EverythingService : ServiceBase<Everything>
	{
		public EverythingService(IContentService contentService)
			: base(contentService)
		{
			
		}

		public override IContent SetDbProperties(Everything content, IContent dbContent)
		{
						
			dbContent.SetValue("approvedcolour", content.Approvedcolour);
						
			dbContent.SetValue("checkboxList", content.CheckboxList);
						
			dbContent.SetValue("dateTimePicker", content.DateTimePicker);
						
			dbContent.SetValue("myLabel", content.MyLabel);
						
			dbContent.SetValue("myNumeric", content.MyNumeric);
						
			dbContent.SetValue("myRichtextEditor", content.MyRichtextEditor);
						
			dbContent.SetValue("multipleTextBox", content.MultipleTextBox);
						
			dbContent.SetValue("textString", content.TextString);
						
			dbContent.SetValue("yesOrNo", content.YesOrNo);
			
			return base.SetDbProperties(content, dbContent);
		}
	}
}