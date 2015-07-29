using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConcreteContentTypes.Core.Helpers;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class NamingConventionHelperTests
	{
		/// <summary>
		/// We don't want to allow users to use 'Content' as a property name as this is reserved for us.
		/// </summary>
		[TestMethod]
		public void GetConventionalName_DisallowContent()
		{
			string test = "Content";

			string output = NamingConventionHelper.GetConventionalName(test);

			Assert.AreEqual(output, "content"); //The 'Content' string should be reduced to 'content'
		}

		[TestMethod]
		public void GetConventionalName_OnlyAllowedCharacters()
		{
			string test = "abc123*\";!£$%^&*()+=/\\.,|`¬ DEF";

			string output = NamingConventionHelper.GetConventionalName(test);

			Assert.AreEqual(output, "Abc123Def", false);
		}
	}
}
