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
	public class AttributeDefinitionTests
	{
		[TestMethod]
		public void AttributeDefinition_Construct_WithType()
		{
			var testType = typeof(TestMethodAttribute);

			var sut = new AttributeDefinition(testType);

			Assert.AreEqual("TestMethod", sut.Type, "Type not set properly");
			Assert.IsFalse(sut.Type.ToLower().Contains("attribute"), "Type property should remove the Attribute suffix of the Type name");
			Assert.AreEqual("Microsoft.VisualStudio.TestTools.UnitTesting", sut.Namespace, "Namespace is not set properly");
			Assert.IsNotNull(sut.Params, "Params should be initialised to an empty collection");
			Assert.AreEqual(0, sut.Params.Count(), "Params should be initialised to an empty collection");
		}

		[TestMethod]
		public void AttributeDefinition_Construct_NameAndNamespace()
		{
			var testType = typeof(TestMethodAttribute);

			string testTypeName = testType.Name;
			string testTypeNamespace = testType.Namespace;

			var sut = new AttributeDefinition(testTypeName, testTypeNamespace);

			Assert.AreEqual("TestMethod", sut.Type, "Type not set properly");
			Assert.IsFalse(sut.Type.ToLower().Contains("attribute"), "Type property should remove the Attribute suffix of the Type name");
			Assert.AreEqual("Microsoft.VisualStudio.TestTools.UnitTesting", sut.Namespace, "Namespace is not set properly");
			Assert.IsNotNull(sut.Params, "Params should be initialised to an empty collection");
			Assert.AreEqual(0, sut.Params.Count(), "Params should be initialised to an empty collection");
		}
	}
}
