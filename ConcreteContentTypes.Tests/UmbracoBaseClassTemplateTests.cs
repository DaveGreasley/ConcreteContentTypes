using ConcreteContentTypes.Core.CodeGeneration.CSharp.Templates.Classes;
using ConcreteContentTypes.Core.Models.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class UmbracoBaseClassTemplateTests
	{
		[TestMethod]
		public void UmbracoBaseClassTemplate_Construct()
		{
			var sut = new UmbracoBaseClassTemplate();

			Assert.IsNull(sut.CurrentDefinition, "CurrentDefinition should be initialised to null");
			Assert.IsNotNull(sut.ClassAttributeTemplates, "ClassAttributeTemplates should be initialised to an empty collection");
			Assert.AreEqual(0, sut.ClassAttributeTemplates.Count(), "ClassAttributeTemplates should be initialised to an empty collection");
			Assert.IsNotNull(sut.UsingNamespaces, "UsingNamespaces should be initialised to an empty collection");
			Assert.AreEqual(0, sut.UsingNamespaces.Count(), "UsingNamespaces should be initialised to an empty collection");
			Assert.AreEqual(string.Empty, sut.CacheName, "CacheName should be initialised to an empty string");
		}

		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_NullDefinition()
		{
			var sut = new UmbracoBaseClassTemplate();

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
		public void UmbracoBaseClassTemplate_TransformText_CurrentDefinitionSet()
		{
			var baseClassDefinition = new UmbracoBaseClassDefinition("UmbracoBaseClass", "TestNameSpace", PublishedItemType.Content);

			var sut = new UmbracoBaseClassTemplate();
			sut.TransformText(baseClassDefinition);

			Assert.AreSame(baseClassDefinition, sut.CurrentDefinition);
			Assert.AreEqual(baseClassDefinition.UsingNamespaces.Count(), sut.UsingNamespaces.Count(), "Using namespaces aren't being set correctly");
			Assert.AreEqual("ContentCache", sut.CacheName, "CacheName is being incorrectly set. Check PublishedItemType of ClassDefinition");
		}

		[TestMethod]
		public void UmbracoBaseClassTemplate_TransformText_SingleClassAttribute()
		{
			var baseClassDefinition = new UmbracoBaseClassDefinition("UmbracoBaseClass", "TestNameSpace", PublishedItemType.Content);
			baseClassDefinition.Attributes.Add(new AttributeDefinition("TestAttributeType", "TestAttributeNamespace"));

			var sut = new UmbracoBaseClassTemplate();
			sut.TransformText(baseClassDefinition);

			Assert.IsNotNull(sut.ClassAttributeTemplates, "ClassAttributesTemplates not be set correctly");
			Assert.AreEqual(1, sut.ClassAttributeTemplates.Count(), "There should only be 1 Class Attribute in this scenario");
		}
	}
}
