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
		public void CSharpCodeGeneratorFacade_Construct()
		{
			var baseClassGeneratorMock = new Mock<IBaseClassCodeGenerator>();
			var modelClassGeneratorMock = new Mock<IModelClassCodeGenerator>();

			var sut = new CSharpCodeGeneratorFacade(baseClassGeneratorMock.Object, modelClassGeneratorMock.Object);

			Assert.AreSame(baseClassGeneratorMock.Object, sut.BaseClassGenerator, "BaseClassGenerator not set correctly");
			Assert.AreSame(modelClassGeneratorMock.Object, sut.ModelClassGenerator, "ModelClassGenerator not set correctly");
		}

		[TestMethod]
		public void CSharpCodeGeneratorFacade_GenerateBaseClass_CallsBaseClassCodeGenerator()
		{
			var modelClassCodeGeneratorMock = new Mock<IModelClassCodeGenerator>();
			var baseClassCodeGeneratorMock = new Mock<IBaseClassCodeGenerator>();
			var baseClassDefinitionMock = new Mock<IBaseClassDefinition>();

			var sut = new CSharpCodeGeneratorFacade(baseClassCodeGeneratorMock.Object, modelClassCodeGeneratorMock.Object);
			sut.GenerateBaseClass(baseClassDefinitionMock.Object);

			baseClassCodeGeneratorMock.Verify(x => x.GenerateBaseClass(baseClassDefinitionMock.Object),
				"Not calling BaseClassCodeGenerator correctly");
		}

		[TestMethod]
		public void CSharpCodeGeneratorFacade_GenerateModelClass_CallsModelClassGeneratorCorrectly()
		{
			var baseClassCodeGenerator = new Mock<IBaseClassCodeGenerator>();
			var modelClassCodeGeneratorMock = new Mock<IModelClassCodeGenerator>();
			var modelClassDefintionMock = new Mock<IModelClassDefinition>();

			var sut = new CSharpCodeGeneratorFacade(baseClassCodeGenerator.Object, modelClassCodeGeneratorMock.Object);
			sut.GenerateModelClass(modelClassDefintionMock.Object);

			modelClassCodeGeneratorMock.Verify(x => x.GenerateModelClass(modelClassDefintionMock.Object), 
				"Not calling ModelClassCodeGenerator correctly");
		}
	}
}
