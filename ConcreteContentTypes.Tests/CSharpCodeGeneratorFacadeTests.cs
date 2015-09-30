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
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests
{
	[TestClass]
	public class CSharpCodeGeneratorFacadeTests
	{
		[TestMethod]
		public void CSharpCodeGenerator_Construct()
		{
			var baseClassGeneratorMock = new Mock<IBaseClassCodeGenerator>();
			var modelClassGeneratorMock = new Mock<IModelClassCodeGenerator>();

			var sut = new CSharpCodeGeneratorFacade(baseClassGeneratorMock.Object, modelClassGeneratorMock.Object);

			Assert.AreSame(baseClassGeneratorMock.Object, sut.BaseClassGenerator, "BaseClassGenerator not set correctly");
			Assert.AreSame(modelClassGeneratorMock.Object, sut.ModelClassGenerator, "ModelClassGenerator not set correctly");
		}

		[TestMethod]
		public void CSharpCodeGenerator_GenerateBaseClass()
		{
			var baseClassDefinitionMock = new Mock<IBaseClassDefinition>();
			baseClassDefinitionMock.Setup(x => x.PublishedItemType).Returns(PublishedItemType.Content);
			baseClassDefinitionMock.Setup(x => x.Properties).Returns(new List<IBaseClassPropertyDefinition>());

			var baseClassCode = "SomeCode...";

			var baseClassCodeGeneratorMock = new Mock<IBaseClassCodeGenerator>();
			baseClassCodeGeneratorMock.Setup(x => x.GenerateBaseClass(baseClassDefinitionMock.Object)).Returns(baseClassCode);

			var modelClassCodeGeneratorMock = new Mock<IModelClassCodeGenerator>();


			var sut = new CSharpCodeGeneratorFacade(baseClassCodeGeneratorMock.Object, modelClassCodeGeneratorMock.Object);

			var generatedCode = sut.GenerateBaseClass(baseClassDefinitionMock.Object);

			Assert.AreEqual(baseClassCode, generatedCode, "Wrong code generated!");
		}

		//[TestMethod]
		//public void CSharpCodeGenerator_GenerateModelClass()
		//{
		//	var modelClassDefinition = new ModelClassDefinition("ModelClass", "TestNameSpace");

		//	var modelClassCode = "SomeCode...";

		//	var baseClassTemplateMock = new Mock<IBaseClassTemplate>();

		//	var modelClassTemplateMock = new Mock<IModelClassTemplate>();
		//	modelClassTemplateMock.Setup(x => x.TransformText(modelClassDefinition)).Returns(modelClassCode);



		//	var sut = new CSharpCodeGenerator(baseClassTemplateMock.Object, modelClassTemplateMock.Object);

		//	var generatedCode = sut.GenerateModelClass(modelClassDefinition);

		//	Assert.AreEqual(modelClassCode, generatedCode);
		//}
	}
}
