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
	public class PropertyDefinitionTests
	{
		[TestMethod]
		public void PropertyDefinition_Construct_TypeAsString()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			string type = "PropertyType";

			var sut = new PropertyDefinition(originalName, type);

			Assert.AreEqual(conventionalName, sut.Name, "Name set incorrectly");
			Assert.AreEqual(type, sut.ClrType, "ClrType set incorrectly");
			Assert.IsNotNull(sut.Attributes, "Attributes collection is null");
			Assert.AreEqual(0, sut.Attributes.Count, "Attributes should be initialised to an empty collection");
			Assert.AreEqual(string.Empty, sut.Description, "Description should be initialised to an empty string");
		}

		[TestMethod]
		public void PropertyDefinition_Construct_TypeAsType()
		{
			string originalName = "Property Name";
			string conventionalName = "PropertyName";
			Type type = typeof(string);

			var sut = new PropertyDefinition(originalName, type);

			Assert.AreEqual(conventionalName, sut.Name);
			Assert.AreEqual(type.Name, sut.ClrType);
			Assert.IsNotNull(sut.Attributes, "Attributes collection is null");
			Assert.AreEqual(0, sut.Attributes.Count, "Attributes should be initialised to an empty collection");
			Assert.AreEqual(string.Empty, sut.Description, "Description should be initialised to an empty string");
		}
	}
}
