using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes;
using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class BaseClassTemplateTests
	{
		[TestMethod]
		public void UmbracoBaseClassTemplate_Construct()
		{
			var attributeTemplateMock = new Mock<IAttributeTemplate>();

			var sut = new BaseClassTemplate(attributeTemplateMock.Object);

			Assert.IsNull(sut.Definition, "Defintion should be initialised to null");
			Assert.AreSame(attributeTemplateMock.Object, sut.AttributeTemplate, "AttributeTemplate not set properly");
			Assert.IsNotNull(sut.UsingNamespaces, "UsingNamespaces should be initialised to an empty collection");
			Assert.AreEqual(0, sut.UsingNamespaces.Count(), "UsingNamespaces should be initialised to an empty collection");
			Assert.AreEqual(string.Empty, sut.CacheName, "CacheName should be initialised to an empty string");
		}

		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_NullDefinition()
		{
			var attributeTemplateMock = new Mock<IAttributeTemplate>();

			var sut = new BaseClassTemplate(attributeTemplateMock.Object);

			try
			{
				sut.TransformText(null);
			}
			catch (ArgumentNullException argnEx)
			{
				Assert.AreEqual("classDefinition", argnEx.ParamName);
				return;
			}

			Assert.Fail("ArgumentNullException not thrown for classDefinition param.");
		}

		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_SingleClassAttribute()
		{
			var baseClassDefinition = new BaseClassDefinition("UmbracoBaseClass", "TestNameSpace", PublishedItemType.Content);
			baseClassDefinition.Attributes.Add(new AttributeDefinition("TestAttributeType", "TestAttributeNamespace"));

			var attributeTemplateMock = new Mock<IAttributeTemplate>();
			attributeTemplateMock.Setup(x => x.TransformText(It.IsAny<IAttributeDefinition>())).Returns("attribute code");

			var sut = new BaseClassTemplate(attributeTemplateMock.Object);
			string generatedCode = sut.TransformText(baseClassDefinition);

			Assert.AreSame(baseClassDefinition, sut.Definition, "Definition not set correctly");
			Assert.AreSame(baseClassDefinition.GetUsingNamespaces(), sut.UsingNamespaces, "UsingNamespaces not set correctly");
			Assert.AreEqual("ContentCache", sut.CacheName, "CacheName not set correctly");
			Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		}
	}
}
