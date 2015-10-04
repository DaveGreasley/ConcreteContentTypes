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
	public class AttributeTemplateTests
	{
		//[TestMethod]
		//public void AttributeTemplate_TransformText_NullDefinition()
		//{
		//	var sut = new AttributeTemplate();
		//	try
		//	{
		//		sut.GenerateCode(null);
		//	}
		//	catch (ArgumentNullException argnEx)
		//	{
		//		Assert.AreEqual("attributeDefinition", argnEx.ParamName, "Exception ParamName should be attributeDefinition");
		//		return;
		//	}

		//	Assert.Fail("Did not throw ArgumentNullException");
		//}

		//[TestMethod]
		//public void AttributeTemplate_TransformText_ParametersIsEmptyString()
		//{
		//	var attributeDefinitionMock = new Mock<IAttributeDefinition>();
		//	attributeDefinitionMock.Setup(x => x.Type).Returns("TestAttribute");
		//	attributeDefinitionMock.Setup(x => x.Namespace).Returns("TestNamespace");
		//	attributeDefinitionMock.Setup(x => x.ConstructorParameters).Returns(new List<object>());

		//	var sut = new AttributeTemplate();
		//	string generatedCode = sut.GenerateCode(attributeDefinitionMock.Object);

		//	Assert.AreSame(attributeDefinitionMock.Object, sut.Definition, "Definition property not set properly");
		//	Assert.AreEqual(string.Empty, sut.Parameters, "Parameters should be empty string when none specified on Definition");
		//	Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		//}

		//[TestMethod]
		//public void AttributeTemplate_TransformText_SingleNonStringParam()
		//{
		//	var attributeDefinitionMock = new Mock<IAttributeDefinition>();
		//	attributeDefinitionMock.Setup(x => x.Type).Returns("TestAttribute");
		//	attributeDefinitionMock.Setup(x => x.Namespace).Returns("TestNamespace");
		//	attributeDefinitionMock.Setup(x => x.ConstructorParameters).Returns(new List<object>() { 1 });

		//	var sut = new AttributeTemplate();
		//	string generatedCode = sut.GenerateCode(attributeDefinitionMock.Object);

		//	Assert.AreSame(attributeDefinitionMock.Object, sut.Definition, "Definition property not set properly");
		//	Assert.AreEqual("1", sut.Parameters, "Parameters property not set properly");
		//	Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		//}

		//[TestMethod]
		//public void AttributeTemplate_TransformText_MultiNonStringParam()
		//{
		//	var attributeDefinitionMock = new Mock<IAttributeDefinition>();
		//	attributeDefinitionMock.Setup(x => x.Type).Returns("TestAttribute");
		//	attributeDefinitionMock.Setup(x => x.Namespace).Returns("TestNamespace");
		//	attributeDefinitionMock.Setup(x => x.ConstructorParameters).Returns(new List<object>() { 1, true, 0.0D });

		//	var sut = new AttributeTemplate();
		//	string generatedCode = sut.GenerateCode(attributeDefinitionMock.Object);

		//	Assert.AreSame(attributeDefinitionMock.Object, sut.Definition, "Definition property not set properly");
		//	Assert.AreEqual("1, True, 0", sut.Parameters, "Parameters property not set properly");
		//	Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		//}

		//[TestMethod]
		//public void AttributeTemplate_TransformText_SingleStringParam()
		//{
		//	var attributeDefinitionMock = new Mock<IAttributeDefinition>();
		//	attributeDefinitionMock.Setup(x => x.Type).Returns("TestAttribute");
		//	attributeDefinitionMock.Setup(x => x.Namespace).Returns("TestNamespace");
		//	attributeDefinitionMock.Setup(x => x.ConstructorParameters).Returns(new List<object>() { "\"StringValue\"" });

		//	var sut = new AttributeTemplate();
		//	string generatedCode = sut.GenerateCode(attributeDefinitionMock.Object);

		//	Assert.AreSame(attributeDefinitionMock.Object, sut.Definition, "Definition property not set properly");
		//	Assert.AreEqual("\"StringValue\"", sut.Parameters, "Parameters property not set properly");
		//	Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		//}

		//[TestMethod]
		//public void AttributeTemplate_TransformText_MultipleStringParam()
		//{
		//	var attributeDefinitionMock = new Mock<IAttributeDefinition>();
		//	attributeDefinitionMock.Setup(x => x.Type).Returns("TestAttribute");
		//	attributeDefinitionMock.Setup(x => x.Namespace).Returns("TestNamespace");
		//	attributeDefinitionMock.Setup(x => x.ConstructorParameters).Returns(new List<object>() { "\"StringValue\"", "\"AnotherString\"" });

		//	var sut = new AttributeTemplate();
		//	string generatedCode = sut.GenerateCode(attributeDefinitionMock.Object);

		//	Assert.AreSame(attributeDefinitionMock.Object, sut.Definition, "Definition property not set properly");
		//	Assert.AreEqual("\"StringValue\", \"AnotherString\"", sut.Parameters, "Parameters property not set properly");
		//	Assert.AreNotEqual(string.Empty, generatedCode, "Template should probably generate some code!");
		//}
	}
}
