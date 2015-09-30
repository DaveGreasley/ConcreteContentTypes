using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
			Assert.AreEqual("Microsoft.VisualStudio.TestTools.UnitTesting", sut.Namespace, "Namespace is not set properly");
			Assert.IsNotNull(sut.ConstructorParameters, "Params should be initialised to an empty collection");
			Assert.AreEqual(0, sut.ConstructorParameters.Count(), "Params should be initialised to an empty collection");
		}

		[TestMethod]
		public void AttributeDefinition_Construct_NameAndNamespace()
		{
			var testType = typeof(TestMethodAttribute);

			string testTypeName = testType.Name;
			string testTypeNamespace = testType.Namespace;

			var sut = new AttributeDefinition(testTypeName, testTypeNamespace);

			Assert.AreEqual("TestMethod", sut.Type, "Type not set properly");
			Assert.AreEqual("Microsoft.VisualStudio.TestTools.UnitTesting", sut.Namespace, "Namespace is not set properly");
			Assert.IsNotNull(sut.ConstructorParameters, "Params should be initialised to an empty collection");
			Assert.AreEqual(0, sut.ConstructorParameters.Count(), "Params should be initialised to an empty collection");
		}

		[TestMethod]
		public void AttributeDefinition_AddConstructorParameter_DoesNotAllowNull()
		{
			var sut = new AttributeDefinition(typeof(TestMethodAttribute));

			try
			{
				sut.AddConstructorParameter(null);
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail("Did not throw ArgumentNullExcpetion");
		}

		[TestMethod]
		public void AttributeDefinition_AddConstructorParameter_OnlyAcceptsValueTypeObjects()
		{
			var sut = new AttributeDefinition("TestType", "TestNamespace");

			Assert.AreEqual(0, sut.ConstructorParameters.Count(), "Should start with 0 params after initialisation");

			var primInt = 0;
			var primDouble = 0.0D;
			var primDecimal = 0.0M;
			var primBool = true;
			var primChar = 'a';

			sut.AddConstructorParameter(primInt);
			sut.AddConstructorParameter(primDouble);
			sut.AddConstructorParameter(primDecimal);
			sut.AddConstructorParameter(primBool);
			sut.AddConstructorParameter(primChar);

			Assert.AreEqual(5, sut.ConstructorParameters.Count(), "Should have added 5 objects to Params collection");

			try
			{
				var complex = new List<string>();
				sut.AddConstructorParameter(complex);
			}
			catch (ArgumentException)
			{
				Assert.AreEqual(5, sut.ConstructorParameters.Count(), "Threw InvalidOperationException BUT Params count changed");
				return;
			}

			Assert.Fail("Failed to throw ArgumentException when passed reference type");
		}

		[TestMethod]
		public void AttributeDefinition_AddConstructorParameter_ParamsOrderedCorrectly()
		{
			var sut = new AttributeDefinition(typeof(TestMethodAttribute));

			sut.AddConstructorParameter(1);
			sut.AddConstructorParameter("two");
			sut.AddConstructorParameter(3d);
			sut.AddConstructorParameter(false);
			
			Assert.AreEqual(4, sut.ConstructorParameters.Count());
			Assert.AreEqual(1, sut.ConstructorParameters.ElementAt(0), "Constructor Parameters are in the wrong order");
			Assert.AreEqual("\"two\"", sut.ConstructorParameters.ElementAt(1), "Constructor Parameters are in the wrong order");
			Assert.AreEqual(3d, sut.ConstructorParameters.ElementAt(2), "Constructor Parameters are in the wrong order");
			Assert.AreEqual(false, sut.ConstructorParameters.ElementAt(3), "Constructor Parameters are in the wrong order");
		}
	}
}
