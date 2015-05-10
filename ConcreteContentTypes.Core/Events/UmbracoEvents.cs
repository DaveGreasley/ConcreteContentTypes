using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Services;
using ConcreteContentTypes.Core.Compiler;
using ConcreteContentTypes.Core.Configuration;

namespace ConcreteContentTypes.Core.Events
{
	public class UmbracoEvents : ApplicationEventHandler
	{
		protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			base.ApplicationStarted(umbracoApplication, applicationContext);

			ContentTypeService.SavedContentType += ContentTypeService_SavedContentType;
			DataTypeService.Saved += DataTypeService_Saved;
		}

		void DataTypeService_Saved(IDataTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IDataTypeDefinition> e)
		{
			if (Settings.Current.GenerateOnDataTypeSave)
			{
				Compiler.Compiler c = new Compiler.Compiler();
				c.BuildDataTypes();
			}
		}

		void ContentTypeService_SavedContentType(IContentTypeService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContentType> e)
		{
			if (Settings.Current.GenerateOnContentTypeSave)
			{
				Compiler.Compiler c = new Compiler.Compiler();
				c.BuildDataTypes();
				c.BuildContentTypes();
			}
		}
	}
}
