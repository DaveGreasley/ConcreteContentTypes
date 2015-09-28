using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp;
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
	public class CSharpCodeGeneratorTests
	{
		[TestMethod]
		public void CSharpCodeGenerator_Construct()
		{
			var baseClassTemplate = new Mock<IUmbracoBaseClassTemplate>();
			var modelClassTemplate = new Mock<IModelClassTemplate>();

			var sut = new CSharpCodeGenerator(baseClassTemplate.Object, modelClassTemplate.Object);

			Assert.AreSame(baseClassTemplate.Object, sut.BaseClassTemplate, "BaseClassTemplate not set correctly");
			Assert.AreSame(modelClassTemplate.Object, sut.ModelClassTemplate, "ModelClassTemplate not set correctly");
		}

		[TestMethod]
		public void CSharpCodeGenerator_GenerateBaseClass()
		{
			var baseClassDefinition = new UmbracoBaseClassDefinition("BaseClass", "TestNameSpace");

			var baseClassCode = "SomeCode...";

			var baseClassTemplateMock = new Mock<IUmbracoBaseClassTemplate>();
			baseClassTemplateMock.Setup(x => x.TransformText(baseClassDefinition)).Returns(baseClassCode);

			var modelClassTemplateMock = new Mock<IModelClassTemplate>();



			var sut = new CSharpCodeGenerator(baseClassTemplateMock.Object, modelClassTemplateMock.Object);

			var generatedCode = sut.GenerateBaseClass(baseClassDefinition);

			Assert.AreEqual(baseClassCode, generatedCode, "Code generated return wrong code");
		}

		[TestMethod]
		public void CSharpCodeGenerator_GenerateModelClass()
		{
			var modelClassDefinition = new UmbracoModelClassDefinition("ModelClass", "TestNameSpace");

			var modelClassCode = "SomeCode...";

			var baseClassTemplateMock = new Mock<IUmbracoBaseClassTemplate>();

			var modelClassTemplateMock = new Mock<IModelClassTemplate>();
			modelClassTemplateMock.Setup(x => x.TransformText(modelClassDefinition)).Returns(modelClassCode);



			var sut = new CSharpCodeGenerator(baseClassTemplateMock.Object, modelClassTemplateMock.Object);

			var generatedCode = sut.GenerateModelClass(modelClassDefinition);

			Assert.AreEqual(modelClassCode, generatedCode);
		}
	}
}
