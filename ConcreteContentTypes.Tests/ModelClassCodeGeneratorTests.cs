using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes;
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
	public class ModelClassCodeGeneratorTests
	{
		[TestMethod]
		public void ModelClassCodeGenerator_Construct()
		{
			var modelClassTemplateMock = new Mock<IModelClassTemplate>();

			var sut = new ModelClassCodeGenerator(modelClassTemplateMock.Object);

			Assert.AreSame(modelClassTemplateMock.Object, sut.Template, "Template is not set correctly");
		}
	}
}
