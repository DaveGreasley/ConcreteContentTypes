using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes;
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
	public class ModelClassTemplateTests
	{
		[TestMethod]
		public void UmbracoModelClassTemplate_Construct()
		{
			var attributeTemplateMock = new Mock<IAttributeTemplate>();
			var ptfMock = new Mock<IPropertyTemplateFactory>();
			var errorTrackerMock = new Mock<IErrorTracker>();

			var sut = new ModelClassTemplate(attributeTemplateMock.Object, ptfMock.Object, errorTrackerMock.Object);

			Assert.IsNull(sut.Definition, "ClassDefinition should be initialised to null");
			Assert.AreSame(attributeTemplateMock.Object, sut.AttributeTemplate, "AttributeTemplate not set properly");
			Assert.AreSame(errorTrackerMock.Object, sut.ErrorTracker, "ErrorTracker not properly set");
		}
	}
}
