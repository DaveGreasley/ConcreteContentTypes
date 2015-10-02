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
	public class ModelClassDefinitionTests
	{
		[TestMethod]
		public void UmbracoModelClassDefinition_Construct()
		{
			var name = "TestModelClass";
			var nameSpace = "TestNamespace";

			var sut = new ModelClassDefinition(name, nameSpace);

			Assert.AreEqual(name, sut.Name, "The name is not set correctly");
			Assert.AreEqual(nameSpace, sut.Namespace, "The namespace is not set correcty");
			Assert.IsNotNull(sut.Properties, "Properties collection is null");
			Assert.AreEqual(0, sut.Properties.Count, "Properties should be initialised to an empty collection");
			Assert.IsNotNull(sut.Attributes, "Attributes collection is null");
			Assert.AreEqual(0, sut.Attributes.Count, "Attributes should be initialised to an empty collection");
			
			var usingNamespaces = sut.GetUsingNamespaces();
			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(1, usingNamespaces.Count(), "There should only be one namespace configured by default.");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
		}

		[TestMethod]
		public void UmbracoModelClassDefinition_GetUsingNamespaces_OneClassAttribute()
		{
			var name = "TestModelClass";
			var nameSpace = "TestNamespace";

			var sut = new ModelClassDefinition(name, nameSpace);

			sut.Attributes.Add(new AttributeDefinition("AttributeType", "AttributeNamespace"));

			var usingNamespaces = sut.GetUsingNamespaces();


			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(2, usingNamespaces.Count(), "There should be 2 namespaces: ConcreteContentTypes.Core.Extensions and AttributeNamespace");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
			Assert.IsTrue(usingNamespaces.Contains("AttributeNamespace"), "Test class attribute namespace not present in collection");
		}

		[TestMethod]
		public void UmbracoBaseClassDefintionTests_GetUsingNamespaces_OneClassAttributeOnePropertyAttribute()
		{
			var name = "TestModelClass";
			var nameSpace = "TestNamespace";

			var sut = new ModelClassDefinition(name, nameSpace);

			sut.Attributes.Add(new AttributeDefinition("AttributeType", "AttributeNamespace"));

			var propertyDefinition = new ModelClassPropertyDefinition("Test Property", "TestProperty", "TestPropertyEditorAlias");
			propertyDefinition.Attributes.Add(new AttributeDefinition("PropertyAttributeTest", "PropertyAttributeNamespace"));

			sut.Properties.Add(propertyDefinition);

			var usingNamespaces = sut.GetUsingNamespaces();


			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(3, usingNamespaces.Count(), "There should be 3 namespaces: ConcreteContentTypes.Core.Extensions, AttributeNamespace, PropertyAttributeTest");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
			Assert.IsTrue(usingNamespaces.Contains("AttributeNamespace"), "Test class attribute namespace not present in collection");
			Assert.IsTrue(usingNamespaces.Contains("PropertyAttributeNamespace"), "Test property attribute namespace not present in collection");
		}
	}
}
