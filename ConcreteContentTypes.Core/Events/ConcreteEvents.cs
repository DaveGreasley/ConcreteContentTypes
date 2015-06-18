using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Events
{
	public delegate void ConcreteUmbracoContentModelGeneratingDelegate(UmbracoContentClassDefinition classDefinition, PublishedItemType contentType);
	public delegate void ConcreteModelGeneratingDelegate(ModelClassDefinition classDefintion, PublishedItemType contentType);

	public static class ConcreteEvents
	{
		/// <summary>
		/// occurs when the UmbracoContent and UmbracoMedia base classes is being generated
		/// </summary>
		public static event ConcreteUmbracoContentModelGeneratingDelegate UmbracoContentClassGenerating;

		/// <summary>
		/// Occurs for each Content Type and Media Type that Concrete is writing a class for before the C# is written.
		/// </summary>
		public static event ConcreteModelGeneratingDelegate ModelClassGenerating;

		internal static void RaiseUmbracoContentClassGenerating(UmbracoContentClassDefinition classDefinition, PublishedItemType contentType)
		{
			if (UmbracoContentClassGenerating != null)
				UmbracoContentClassGenerating(classDefinition, contentType);
		}

		internal static void RaiseModelClassGenerating(ModelClassDefinition classDefiniton, PublishedItemType contentType)
		{
			if (ModelClassGenerating != null)
				ModelClassGenerating(classDefiniton, contentType);
		}
	}
}
