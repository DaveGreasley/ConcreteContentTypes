using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class UmbracoModelClassPropertyDefintionTests
	{
		[TestMethod]
		public void UmbracoModelClassPropertyDefinition_Construct_ClrType_NotSpecified()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			string alias = "PropertyAlias";

			var sut = new UmbracoModelClassPropertyDefinition(originalName, alias);

			Assert.AreEqual(conventionalName, sut.Name, "Name is not set correctly");
			Assert.AreEqual(alias, sut.PropertyAlias, "PropertyAlias is not set correctly");
			Assert.AreEqual(string.Empty, sut.ClrType, "ClrType should be initialised to an empty string using this constructor");
		}

		[TestMethod]
		public void UmbracoModelClassPropertyDefinition_Construct_ClrType_Specified()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			string alias = "PropertyAlias";
			string clrType = "PropertyClrType";

			var sut = new UmbracoModelClassPropertyDefinition(originalName, alias, clrType);

			Assert.AreEqual(conventionalName, sut.Name, "Name is not set correctly");
			Assert.AreEqual(alias, sut.PropertyAlias, "PropertyAlias is not set correctly");
			Assert.AreEqual(clrType, sut.ClrType, "ClrType is not set correctly");
		}
	}
}
