using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class UmbracoBaseClassDefinitionTests
	{
		[TestMethod]
		public void UmbracoBaseClassDefinitionTests_Construct()
		{
			string name = "UmbracoBaseClass";
			string nameSpace = "TestNameSapce";

			var sut = new UmbracoBaseClassDefinition(name, nameSpace);

			Assert.AreEqual(name, sut.Name, "The name is not set correctly");
			Assert.AreEqual(nameSpace, sut.Namespace, "The namespace is not set correctly");
			Assert.IsNotNull(sut.Properties, "Properties collection is null");
			Assert.AreEqual(0, sut.Properties.Count(), "Properties should be initialised to an empty collection");
			Assert.IsNotNull(sut.Attributes, "Attributes collection is null");
			Assert.AreEqual(0, sut.Attributes.Count(), "Attributes should be initialised to an empty collection");

			var usingNamespaces = sut.GetUsingNamespaces();
			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(1, usingNamespaces.Count, "There should only be one namespace configured by default.");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
		}

		[TestMethod]
		public void UmbracoBaseClassDefintionTests_GetUsingNamespaces_OneClassAttribute()
		{
			string name = "UmbracoBaseClass";
			string nameSpace = "TestNameSapce";

			var sut = new UmbracoBaseClassDefinition(name, nameSpace);

			sut.Attributes.Add(new AttributeDefinition("AttributeType", "AttributeNamespace"));

			var usingNamespaces = sut.GetUsingNamespaces();


			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(2, usingNamespaces.Count, "There should be 2 namespaces: ConcreteContentTypes.Core.Extensions and AttributeNamespace");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
		}

		[TestMethod]
		public void UmbracoBaseClassDefintionTests_GetUsingNamespaces_OneClassAttributeOnePropertyAttribute()
		{
			string name = "UmbracoBaseClass";
			string nameSpace = "TestNameSapce";

			var sut = new UmbracoBaseClassDefinition(name, nameSpace);

			sut.Attributes.Add(new AttributeDefinition("AttributeType", "AttributeNamespace"));

			var propertyDefinition = new UmbracoBaseClassPropertyDefinition(UmbracoBaseClassProperty.Name);
			propertyDefinition.Attributes.Add(new AttributeDefinition("PropertyAttributeTest", "PropertyAttributeNamespace"));

			sut.Properties.Add(propertyDefinition);

			var usingNamespaces = sut.GetUsingNamespaces();


			Assert.IsNotNull(usingNamespaces, "UsingNamespaces is null");
			Assert.AreEqual(3, usingNamespaces.Count, "There should be 3 namespaces: ConcreteContentTypes.Core.Extensions, AttributeNamespace, PropertyAttributeTest");
			Assert.IsTrue(usingNamespaces.Contains("ConcreteContentTypes.Core.Extensions"), "ConcreteContentTypes.Core.Extensions are not referenced");
		}
	}
}
