﻿using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using ConcreteContentTypes.Core.SourceModelMapping;
using ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers;
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
	public class MediaTypesSourceModelMapperTests
	{
		[TestMethod]
		public void UmbracoMediaTypesSourceModelMapper_GetBaseClassDefinition()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var mediaTypes = new List<IMediaType>();
			var eventsMock = new Mock<IConcreteEvents>();
			var propertyTypeResolverFactoryMock = new Mock<IPropertyTypeResolverFactory>();
			var propertyDefaultSettings = new Mock<IPropertyTypeDefaultsSettings>();

			var sut = new MediaTypesSourceModelMapper(
				settings, 
				eventsMock.Object, 
				mediaTypes,
				propertyTypeResolverFactoryMock.Object,
				propertyDefaultSettings.Object);

			var baseClassDefinition = sut.GetBaseClassDefinition();

			Assert.IsNotNull(baseClassDefinition);
			Assert.AreEqual("UmbracoMedia", baseClassDefinition.Name);
			Assert.AreEqual("TestNameSpace.Media", baseClassDefinition.Namespace);

			eventsMock.Verify(x => x.RaiseMediaBaseClassGenerating(It.IsAny<BaseClassDefinition>()),
				Times.Once,
				"The RaiseContentBaseClassGenerating event is supposed to fire once");

			//Ensure all properties declared in the UmbracoBaseClassProperty enum have an instance on our base class
			Assert.AreEqual(Enum.GetValues(typeof(BaseClassProperty)).Length, baseClassDefinition.Properties.Count());
		}

		[TestMethod]
		public void UmbracoMediaTypesSourceModelMapper_Map_SingleContentType_NoProperties()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var testContentType = new Mock<IMediaType>();
			testContentType.Setup(x => x.Name).Returns("Test Media Type");
			testContentType.Setup(x => x.ParentId).Returns(-1);
			testContentType.Setup(x => x.Id).Returns(1234);
			testContentType.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());
			testContentType.Setup(x => x.AllowedContentTypes).Returns(new List<ContentTypeSort>());

			var eventsMock = new Mock<IConcreteEvents>();
			var propertyTypeResolverFactoryMock = new Mock<IPropertyTypeResolverFactory>();
			var propertyDefaultSettings = new Mock<IPropertyTypeDefaultsSettings>();

			var sut = new MediaTypesSourceModelMapper(
				settings, 
				eventsMock.Object, 
				new List<IMediaType>() { testContentType.Object },
				propertyTypeResolverFactoryMock.Object,
				propertyDefaultSettings.Object);

			var definitions = sut.GetModelClassDefinitions();

			Assert.AreEqual(1, definitions.Count(), "Map() Should return 1 class definition");
			Assert.AreEqual("TestMediaType", definitions.First().Name, "Class name is wrong");
			Assert.IsFalse(definitions.Any(x => x.Properties.Count > 0)); //Make sure there are no properties
		}

		[TestMethod]
		public void UmbracoMediaTypesSourceModelMapper_GetModelClassDefinitions_TwoContentTypes_NoProperties()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var testMediaType = new Mock<IMediaType>();
			testMediaType.Setup(x => x.Name).Returns("Test Media Type");
			testMediaType.Setup(x => x.ParentId).Returns(-1);
			testMediaType.Setup(x => x.Id).Returns(1234);
			testMediaType.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());

			var testMediaType2 = new Mock<IMediaType>();
			testMediaType2.Setup(x => x.Name).Returns("Second Test Media Type");
			testMediaType2.Setup(x => x.ParentId).Returns(-1);
			testMediaType2.Setup(x => x.Id).Returns(4321);
			testMediaType2.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());

			var eventsMock = new Mock<IConcreteEvents>();
			var propertyTypeResolverFactoryMock = new Mock<IPropertyTypeResolverFactory>();
			var propertyDefaultSettings = new Mock<IPropertyTypeDefaultsSettings>();

			var sut = new MediaTypesSourceModelMapper(
				settings,
				eventsMock.Object,
				new List<IMediaType>() { testMediaType.Object, testMediaType2.Object },
				propertyTypeResolverFactoryMock.Object,
				propertyDefaultSettings.Object);

			var definitions = sut.GetModelClassDefinitions();

			//Ensure events are fired
			eventsMock.Verify(x => x.RaiseMediaModelClassGenerating(It.IsAny<ModelClassDefinition>()),
				Times.Exactly(definitions.Count()),
				"Failed to call RaiseMediaModelClassGenerating() for every model");

			Assert.AreEqual(2, definitions.Count(), "Should return 2 class definitions");
			Assert.AreEqual("TestMediaType", definitions.First().Name, "First class name is wrong");
			Assert.AreEqual("SecondTestMediaType", definitions.Last().Name, "Second class name is wrong");
			Assert.IsFalse(definitions.Any(x => x.Properties.Count > 0)); //Make sure there are no properties
		}
	}
}
