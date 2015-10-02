using ConcreteContentTypes.Core.Configuration;
using ConcreteContentTypes.Core.Helpers;
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
	public class PVCClrTypeResolverTests
	{
		[TestMethod]
		public void PVCClrTypeResolver_ResolveType_ShouldReturnClrTypeFromConfig()
		{
			var testContentTypeAlias = "TestContentType";
			var testPropertyTypeAlias = "TestPropertyType";
			var testPublishedItemType = PublishedItemType.Content;

			var expectedResult = "TestClrType";
			
			//Setup fake config item
			var testPropertyTypeSettingsMock = new Mock<IPropertyTypeSettings>();
			testPropertyTypeSettingsMock.Setup(x => x.Alias).Returns(testPropertyTypeAlias);
			testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns(expectedResult);

			//Setup fake config and add our fake item
			var propertyDefaultsMock = new Mock<IPropertyTypeDefaultsSettings>();
			propertyDefaultsMock.Setup(x => x.PropertyTypes)
				.Returns(new List<IPropertyTypeSettings>() { testPropertyTypeSettingsMock.Object });

			//Setup PropertyValueConverterHelper fake
			var pvcHelperMock = new Mock<IPropertyValueConverterHelper>();
			pvcHelperMock.Setup(x => x.CanResolveType).Returns(true);
			pvcHelperMock.Setup(x => x.GetTypeName()).Returns("WrongResult");

			var sut = new PVCTypeResolver(propertyDefaultsMock.Object, pvcHelperMock.Object);
			var clrType = sut.ResolveType(testContentTypeAlias, testPropertyTypeAlias, testPublishedItemType);

			Assert.IsFalse(string.IsNullOrWhiteSpace(clrType), "Resolved type is null or empty");
			Assert.AreEqual(expectedResult, clrType, "Did not return Clr type from given config");
		}

		[TestMethod]
		public void PVCClrTypeResolver_ResolveType_ShouldReturnClrTypeFromIPropertyValueConverterHelper()
		{
			var testContentTypeAlias = "TestContentType";
			var testPropertyTypeAlias = "TestPropertyType";
			var testPublishedItemType = PublishedItemType.Content;

			var expectedResult = "ExpectedResult";

			//Setup fake config item
			var testPropertyTypeSettingsMock = new Mock<IPropertyTypeSettings>();
			testPropertyTypeSettingsMock.Setup(x => x.Alias).Returns(testPropertyTypeAlias);
			testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns("");

			//Setup fake config and add our fake item
			var propertyDefaultsMock = new Mock<IPropertyTypeDefaultsSettings>();
			propertyDefaultsMock.Setup(x => x.PropertyTypes)
				.Returns(new List<IPropertyTypeSettings>() { testPropertyTypeSettingsMock.Object });

			//Setup PropertyValueConverterHelper fake
			var pvcHelperMock = new Mock<IPropertyValueConverterHelper>();
			pvcHelperMock.Setup(x => x.CanResolveType).Returns(true);
			pvcHelperMock.Setup(x => x.GetTypeName()).Returns(expectedResult);

			var sut = new PVCTypeResolver(propertyDefaultsMock.Object, pvcHelperMock.Object);
			var clrType = sut.ResolveType(testContentTypeAlias, testPropertyTypeAlias, testPublishedItemType);

			Assert.IsFalse(string.IsNullOrWhiteSpace(clrType), "Resolved type is null or empty");
			Assert.AreEqual(expectedResult, clrType, "Did not return Clr type from given PVC Helper");
		}

		[TestMethod]
		public void PVCClrTypeResolver_ResolveType_ShouldReturnObject()
		{
			var testContentTypeAlias = "TestContentType";
			var testPropertyTypeAlias = "TestPropertyType";
			var testPublishedItemType = PublishedItemType.Content;

			//Setup fake config item
			var testPropertyTypeSettingsMock = new Mock<IPropertyTypeSettings>();
			testPropertyTypeSettingsMock.Setup(x => x.Alias).Returns(testPropertyTypeAlias);
			testPropertyTypeSettingsMock.Setup(x => x.ClrType).Returns("");

			//Setup fake config and add our fake item
			var propertyDefaultsMock = new Mock<IPropertyTypeDefaultsSettings>();
			propertyDefaultsMock.Setup(x => x.PropertyTypes)
				.Returns(new List<IPropertyTypeSettings>() { testPropertyTypeSettingsMock.Object });

			//Setup PropertyValueConverterHelper fake
			var pvcHelperMock = new Mock<IPropertyValueConverterHelper>();
			pvcHelperMock.Setup(x => x.CanResolveType).Returns(false);

			var sut = new PVCTypeResolver(propertyDefaultsMock.Object, pvcHelperMock.Object);
			var clrType = sut.ResolveType(testContentTypeAlias, testPropertyTypeAlias, testPublishedItemType);

			Assert.IsNotNull(clrType, "Resolved type is null");
			Assert.IsTrue(clrType ==  "Object", "Resolved type should be an empty string");
		}
	}
}
