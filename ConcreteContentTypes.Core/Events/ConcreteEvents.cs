using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Events
{
	public delegate void ConcreteModelGeneratingDelegate(ClassDefinition classDefintion);

	public static class ConcreteEvents
	{
		/// <summary>
		/// Occurs for each Content Type that Concrete is writing a class for before the C# is written.
		/// Allows updating of class and property details.
		/// </summary>
		public static event ConcreteModelGeneratingDelegate Generating;

		internal static void RaiseGenerating(ClassDefinition classDefiniton)
		{
			if (Generating != null)
			{
				Generating(classDefiniton);
			}
		}
	}
}
