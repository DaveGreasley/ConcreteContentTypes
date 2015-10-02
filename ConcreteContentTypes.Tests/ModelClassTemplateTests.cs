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
			var modelClassDefinitionMock = new Mock<IModelClassDefinition>();
			var attributeTemplateFactoryMock = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();
			var propertyTemplateFactoryMock = new Mock<ICodeTemplateFactory<IModelClassPropertyDefinition>>();
			var errorTrackerMock = new Mock<IErrorTracker>();

			var sut = new ModelClassTemplate(modelClassDefinitionMock.Object,
				attributeTemplateFactoryMock.Object,
				propertyTemplateFactoryMock.Object,
				errorTrackerMock.Object);

			Assert.AreSame(modelClassDefinitionMock.Object, sut.Definition, "Definition not set properly");
			Assert.AreSame(attributeTemplateFactoryMock.Object, sut.AttributeTemplateFactory, "AttributeTemplateFactory not set properly");
			Assert.AreSame(propertyTemplateFactoryMock.Object, sut.PropertyTemplateFactory, "PropertyTemplateFactory not set correctly");
			Assert.AreSame(errorTrackerMock.Object, sut.ErrorTracker, "ErrorTracker not set properly");
		}
	}
}
