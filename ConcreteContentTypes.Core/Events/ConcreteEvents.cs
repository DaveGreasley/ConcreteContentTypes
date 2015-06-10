using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Events
{
	public delegate void ConcreteUmbracoContentModelGeneratingDelegate(UmbracoContentClassDefinition classDefinition);
	public delegate void ConcreteModelGeneratingDelegate(ModelClassDefinition classDefintion);

	public static class ConcreteEvents
	{
		/// <summary>
		/// occurs when the UmbracoContent base class is being generated
		/// </summary>
		public static event ConcreteUmbracoContentModelGeneratingDelegate UmbracoContentClassGenerating;

		/// <summary>
		/// Occurs for each Content Type that Concrete is writing a class for before the C# is written.
		/// Allows updating of class and property details.
		/// </summary>
		public static event ConcreteModelGeneratingDelegate ModelClassGenerating;

		internal static void RaiseUmbracoContentClassGenerating(UmbracoContentClassDefinition classDefinition)
		{
			if (UmbracoContentClassGenerating != null)
				UmbracoContentClassGenerating(classDefinition);
		}

		internal static void RaiseModelClassGenerating(ModelClassDefinition classDefiniton)
		{
			if (ModelClassGenerating != null)
				ModelClassGenerating(classDefiniton);
		}
	}
}
