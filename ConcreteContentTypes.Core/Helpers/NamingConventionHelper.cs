using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Helpers
{
	public static class NamingConventionHelper
	{
		/// <summary>
		/// Turns a string into a nice name we can use for csharp properties
		/// </summary>
		public static string GetConventionalName(string unconventionalName)
		{
			string clean = unconventionalName.ToLower();

			CultureInfo ci = Thread.CurrentThread.CurrentCulture;
			clean = ci.TextInfo.ToTitleCase(clean);

			clean = Regex.Replace(clean, "[^a-zA-Z0-9-]", "");

			//Ensure that noone can use the property name Content as this is reserved for the IPublishedContent property on the UmbracoContent class
			//Should probably do that for other standard properties...
			if (clean == "Content")
			{
				return "content";
			}

			return clean;
		}
	}
}
