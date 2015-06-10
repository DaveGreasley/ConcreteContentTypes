using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using System.CodeDom.Compiler;
using ConcreteContentTypes.Core.Configuration;
using Umbraco.Core.Services;
using Umbraco.Web;
using System.Web;
using ConcreteContentTypes.Core.PropertyCSharpWriters;
using ConcreteContentTypes.Core.Templates;
using System.IO;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.CSharpWriters;

namespace ConcreteContentTypes.Core
{
	public class Concrete
	{
		#region Private Variables

		IContentTypeService _contentTypeService;

		string _contentTypeNameSpace;
		string _contentTypeCSharpOutputFolder;

		#endregion

		#region Constructor

		public Concrete()
		{
			_contentTypeService = UmbracoContext.Current.Application.Services.ContentTypeService;

			_contentTypeNameSpace = ConcreteSettings.Current.Namespace;
			_contentTypeCSharpOutputFolder = AppDomain.CurrentDomain.BaseDirectory + ConcreteSettings.Current.CSharpOutputFolder;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Updates or creates C# files for all ContentTypes
		/// </summary>
		public void BuildContentTypes()
		{
			IEnumerable<IContentType> typesToBuild = _contentTypeService.GetAllContentTypes();

			BuildContentTypes(typesToBuild);
		}

		/// <summary>
		/// Updates or creates C# files for the passed ContentTypes
		/// </summary>
		public void BuildContentTypes(IEnumerable<IContentType> contentTypes)
		{
			if (ConcreteSettings.Current.Enabled)
			{
				CreateCSharp(contentTypes);
			}
		}

		#endregion

		#region Private Methods

		private void CreateCSharp(IEnumerable<IContentType> contentTypes)
		{
			UmbracoContentClassDefinition baseClassDefintion = new UmbracoContentClassDefinition("UmbracoContent", ConcreteSettings.Current.Namespace);

			ConcreteEvents.RaiseUmbracoContentClassGenerating(baseClassDefintion);

			CSharpBaseClassFileWriter baseClassWriter = new CSharpBaseClassFileWriter(baseClassDefintion);
			baseClassWriter.WriteBaseClass(_contentTypeCSharpOutputFolder);

			foreach (IContentType contentType in contentTypes)
			{
				var parent = contentTypes.FirstOrDefault(x => x.Id == contentType.ParentId);

				ModelClassDefinition classDefinition = new ModelClassDefinition(contentType, parent, _contentTypeNameSpace, "UmbracoContent");
				
				ConcreteEvents.RaiseModelClassGenerating(classDefinition);
				
				CSharpFileWriter writer = new CSharpFileWriter(classDefinition);
				writer.WriteMainClass(_contentTypeCSharpOutputFolder);
			}
		}
		#endregion
	}
}
