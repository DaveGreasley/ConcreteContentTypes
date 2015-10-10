using ConcreteContentTypes.Core;
using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.Attributes;
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
	public class AttributeWriterTests
	{
		[TestMethod]
		public void AttributeWriter_WriteAtribute_ShouldReturnNonEmptyString()
		{
			var attributeDefinitionMock = new Mock<IAttributeDefinition>();
			attributeDefinitionMock.Setup(x => x.Type).Returns("TestMethod");
			attributeDefinitionMock.Setup(x => x.Namespace).Returns("Microsoft.VisualStudio.TestTools.UnitTesting");

			var expectedResult = "TestCode";
			
			var attributeTemplateMock = new Mock<ICodeTemplate>();
			attributeTemplateMock.Setup(x => x.GenerateCode()).Returns(expectedResult);

			var attributeTemplateFactoryMock = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();
			attributeTemplateFactoryMock.Setup(x => x.GetTemplate(attributeDefinitionMock.Object)).Returns(attributeTemplateMock.Object);

			var errorTrackerMock = new Mock<IErrorTracker>();
			errorTrackerMock.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>())).Throws<InvalidOperationException>();

			var sut = new AttributeWriter(attributeTemplateFactoryMock.Object, errorTrackerMock.Object);
			var result = sut.WriteAttribute(attributeDefinitionMock.Object);

			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual(expectedResult, result);
		}
	}
}
