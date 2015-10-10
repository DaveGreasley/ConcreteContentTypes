using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.SourceModelMapping.TypeResolution;
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
	public class StandardPropertyTypeResolverTests
	{
		string _testContentTypeAlias = "TestContentType";
		string _testPropertyTypeAlias = "TestPropertyType";
		PublishedItemType _testPublishedItemType = PublishedItemType.Content;

		Mock<IPropertyTypeSettings> _testPropertyTypeSettingsMock = null;
		Mock<IPropertyValueConverterHelper> _pvcHelperMock = null;
		StandardPropertyTypeResolver _sut = null;

		[TestInitialize]
		public void Initialise()
		{
			//Setup fake config item
			_testPropertyTypeSettingsMock = new Mock<IPropertyTypeSettings>();
			_testPropertyTypeSettingsMock.Setup(x => x.Alias).Returns(_testPropertyTypeAlias);

			//Setup fake config and add our fake item
			var propertyDefaultsMock = new Mock<IPropertyTypeDefaultsSettings>();
			propertyDefaultsMock.Setup(x => x.PropertyTypes)
				.Returns(new List<IPropertyTypeSettings>() { _testPropertyTypeSettingsMock.Object });

			//Setup PropertyValueConverterHelper fake
			_pvcHelperMock = new Mock<IPropertyValueConverterHelper>();
			_sut = new StandardPropertyTypeResolver(propertyDefaultsMock.Object, _pvcHelperMock.Object);
		}

		[TestMethod]
		public void StandardPropertyTypeResolver_ResolveType_ShouldReturnClrTypeFromConfig()
		{
			var expectedResult = "TestClrType";
			_testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns(expectedResult);

			var clrType = _sut.ResolveType(_testContentTypeAlias, _testPropertyTypeAlias, _testPublishedItemType);

			Assert.IsFalse(string.IsNullOrWhiteSpace(clrType), "Resolved type is null or empty");
			Assert.AreEqual(expectedResult, clrType, "Did not return Clr type from given config");
		}

		[TestMethod]
		public void StandardPropertyTypeResolver_ResolveType_ShouldReturnClrTypeFromIPropertyValueConverterHelper()
		{
			var expectedResult = typeof(StandardPropertyTypeResolver);

			_testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns("");
			_pvcHelperMock.Setup(x => x.AttemptResolveType(_testContentTypeAlias, _testPropertyTypeAlias, _testPublishedItemType))
				.Returns(expectedResult);

			var clrType = _sut.ResolveType(_testContentTypeAlias, _testPropertyTypeAlias, _testPublishedItemType);

			Assert.IsFalse(string.IsNullOrWhiteSpace(clrType), "Resolved type is null or empty");
			Assert.AreEqual(expectedResult.Name, clrType, "Did not return Clr type from given PVC Helper");
		}

		[TestMethod]
		public void StandardPropertyTypeResolver_ResolveType_ShouldReturnObject()
		{
			var expectedResult = typeof(object);

			_testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns("");
			_pvcHelperMock.Setup(x => x.AttemptResolveType(_testContentTypeAlias, _testPropertyTypeAlias, _testPublishedItemType))
				.Returns(expectedResult);

			var clrType = _sut.ResolveType(_testContentTypeAlias, _testPropertyTypeAlias, _testPublishedItemType);

			Assert.IsNotNull(clrType, "Resolved type is null");
			Assert.IsTrue(clrType == expectedResult.Name, "Resolved type should be an empty string");
		}
	}
}
