using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Events;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using ConcreteContentTypes.Core.SourceModelMapping;
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
	public class ContentTypesSourceModelMapperTests
	{
		[TestMethod]
		public void UmbracoContentTypesSourceModelMapper_Construct()
		{
			var settings = new ConcreteSettings() 
			{
				Namespace = "TestNameSpace"
			};

			var contentTypes = new List<IContentType>();
			var eventsMock = new Mock<IConcreteEvents>();

			var sut = new ContentTypeSourceModelMapper(settings, eventsMock.Object, contentTypes);

			Assert.AreSame(settings, sut.Settings);
			Assert.AreSame(contentTypes, sut.ContentTypes);
			Assert.AreEqual("TestNameSpace.Content", sut.Namespace);
		}

		[TestMethod]
		public void UmbracoContentTypesSourceModelMapper_GetBaseClassDefinition()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var contentTypes = new List<IContentType>();
			var eventsMock = new Mock<IConcreteEvents>();

			var sut = new ContentTypeSourceModelMapper(settings, eventsMock.Object, contentTypes);

			var baseClassDefinition = sut.GetBaseClassDefinition();

			Assert.IsNotNull(baseClassDefinition);
			Assert.AreEqual("UmbracoContent", baseClassDefinition.Name);
			Assert.AreEqual("TestNameSpace.Content", baseClassDefinition.Namespace);

			eventsMock.Verify(x => x.RaiseContentBaseClassGenerating(It.IsAny<BaseClassDefinition>()),
				Times.Once,
				"The RaiseContentBaseClassGenerating event is supposed to fire once");

			//Ensure all properties declared in the UmbracoBaseClassProperty enum have an instance on our base class
			Assert.AreEqual(Enum.GetValues(typeof(BaseClassProperty)).Length, baseClassDefinition.Properties.Count());
		}

		[TestMethod]
		public void UmbracoContentTypesSourceModelMapper_GetModelClassDefinitions_SingleContentType_NoProperties()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var testContentType = new Mock<IContentType>();
			testContentType.Setup(x => x.Name).Returns("Test Content Type");
			testContentType.Setup(x => x.ParentId).Returns(-1);
			testContentType.Setup(x => x.Id).Returns(1234);
			testContentType.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());

			var eventsMock = new Mock<IConcreteEvents>();

			var sut = new ContentTypeSourceModelMapper(settings, eventsMock.Object, new List<IContentType>() { testContentType.Object });

			Assert.AreEqual(1, sut.ContentTypes.Count(), "Should contain 1 IContentType");

			var definitions = sut.GetModelClassDefinitions();

			Assert.AreEqual(1, definitions.Count(), "Map() Should return 1 class definition");
			Assert.AreEqual("TestContentType", definitions.First().Name, "Class name is wrong");
			Assert.IsFalse(definitions.Any(x => x.Properties.Count > 0)); //Make sure there are no properties
		}

		[TestMethod]
		public void UmbracoContentTypesSourceModelMapper_GetModelClassDefinitions_TwoContentTypes_NoProperties()
		{
			var settings = new ConcreteSettings()
			{
				Namespace = "TestNameSpace"
			};

			var testContentType = new Mock<IContentType>();
			testContentType.Setup(x => x.Name).Returns("Test Content Type");
			testContentType.Setup(x => x.ParentId).Returns(-1);
			testContentType.Setup(x => x.Id).Returns(1234);
			testContentType.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());

			var testContentType2 = new Mock<IContentType>();
			testContentType2.Setup(x => x.Name).Returns("Second Test Content Type");
			testContentType2.Setup(x => x.ParentId).Returns(-1);
			testContentType2.Setup(x => x.Id).Returns(4321);
			testContentType2.Setup(x => x.ContentTypeComposition).Returns(new List<IContentTypeComposition>());

			var eventsMock = new Mock<IConcreteEvents>();

			var sut = new ContentTypeSourceModelMapper(settings, eventsMock.Object, new List<IContentType>() { testContentType.Object, testContentType2.Object });

			Assert.AreEqual(2, sut.ContentTypes.Count(), "Should contain 2 IContentTypes");

			var definitions = sut.GetModelClassDefinitions();

			Assert.AreEqual(2, definitions.Count(), "Map() should return 2 class definitions");
			Assert.AreEqual("TestContentType", definitions.First().Name, "First class name is wrong");
			Assert.AreEqual("SecondTestContentType", definitions.Last().Name, "Second class name is wrong");
			Assert.IsFalse(definitions.Any(x => x.Properties.Count > 0)); //Make sure there are no properties
		}
	}
}
