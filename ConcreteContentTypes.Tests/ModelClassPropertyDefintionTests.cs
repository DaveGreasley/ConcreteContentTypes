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
	public class ModelClassPropertyDefintionTests
	{
		[TestMethod]
		public void ModelClassPropertyDefintion_Construct_ClrType_NotSpecified()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			string alias = "PropertyAlias";
			string propertyEditorAlias = "PropertyEditorAlias";

			var sut = new ModelClassPropertyDefinition(originalName, alias, propertyEditorAlias);

			Assert.AreEqual(conventionalName, sut.Name, "Name is not set correctly");
			Assert.AreEqual(alias, sut.Alias, "Alias is not set correctly");
			Assert.AreEqual(propertyEditorAlias, sut.PropertyEditorAlias, "PropertyEditorAlias is not set correctly");
			Assert.AreEqual(string.Empty, sut.ClrType, "ClrType should be initialised to an empty string using this constructor");
		}

		[TestMethod]
		public void ModelClassPropertyDefintion_Construct_ClrType_Specified()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			string alias = "PropertyAlias";
			string propertyEditorAlias = "PropertyEditorAlias";
			string clrType = "PropertyClrType";

			var sut = new ModelClassPropertyDefinition(originalName, alias, propertyEditorAlias, clrType);

			Assert.AreEqual(conventionalName, sut.Name, "Name is not set correctly");
			Assert.AreEqual(alias, sut.Alias, "PropertyAlias is not set correctly");
			Assert.AreEqual(clrType, sut.ClrType, "ClrType is not set correctly");
		}
	}
}
