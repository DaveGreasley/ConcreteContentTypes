using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.SourceModelMapping.PropertyTypeResolvers;
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
	public class PropertyTypeResolverFactoryTests
	{
		PropertyTypeResolverFactory _sut = null;
		Mock<IErrorTracker> _errorTrackerMock = null;

		[TestInitialize]
		public void InitialisePropertyTYpeResolverFactory()
		{
			_errorTrackerMock = new Mock<IErrorTracker>();
			_errorTrackerMock.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<ArgumentOutOfRangeException>()));

			//Setup property type defaults
			var propertyDefaults = new List<IPropertyTypeSettings>();
			var contentPickerPropertyDefaultMock = new Mock<IPropertyTypeSettings>();
			contentPickerPropertyDefaultMock.Setup(x => x.TypeResolver).Returns("ContentPickerTypeResolver");
			propertyDefaults.Add(contentPickerPropertyDefaultMock.Object);
			var textboxPropertyDefaultMock = new Mock<IPropertyTypeSettings>();
			textboxPropertyDefaultMock.Setup(x => x.TypeResolver).Returns(string.Empty);
			propertyDefaults.Add(textboxPropertyDefaultMock.Object);

			var settingsMock = new Mock<IPropertyTypeDefaultsSettings>();
			settingsMock.Setup(x => x.PropertyTypes).Returns(propertyDefaults);

			_sut = new PropertyTypeResolverFactory(settingsMock.Object, _errorTrackerMock.Object);
		}

		[TestMethod]
		public void PropertyTypeResolverFactory_ResolveType_ReturnsDefaultResolverWhenResolverNameEmptyString()
		{
			var defaultResolver = _sut.GetTypeResolver(string.Empty);
			Assert.IsNotNull(defaultResolver, "Factory returned null StandardPropertyTypeResolver");
			Assert.IsTrue(defaultResolver.GetType() == typeof(StandardPropertyTypeResolver));
			_errorTrackerMock.Verify(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never, "Type resolver encountered an error");
		}

		[TestMethod]
		public void PropertyTypeResolverFactory_ResolveType_ReturnsCorrectResolverWhenResolverNameIsValid()
		{
			var contentPickerResolver = _sut.GetTypeResolver("ContentPickerTypeResolver");
			Assert.IsNotNull(contentPickerResolver, "Factory returned null ContentPickerTypeResolver");
			Assert.IsTrue(contentPickerResolver.GetType() == typeof(ContentPickerTypeResolver));
			_errorTrackerMock.Verify(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never, "Type resolver encountered an error");
		}

		[TestMethod]
		public void PropertyTypeResolverFactory_ResolveType_ThrowsExceptionWhenResolverNameIsInvalid()
		{
			var unknownResolver = _sut.GetTypeResolver("UnknownTypeResolver");
			_errorTrackerMock.Verify(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>()), Times.AtLeastOnce,"Type resolver didn't throw exception for invalid type name");
		}
	}
}
