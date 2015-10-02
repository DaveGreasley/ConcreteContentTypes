using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes.Factories;
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
	public class ModelClassTemplateFactoryTests
	{
		[TestMethod]
		public void ModelClassTemplateFactory_Construct()
		{
			var errorTrackerMock = new Mock<IErrorTracker>();
			var attributeTemplateFactoryMock = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();
			var propertyTemplateFactoryMock = new Mock<ICodeTemplateFactory<IModelClassPropertyDefinition>>();

			var sut = new ModelClassTemplateFactory(errorTrackerMock.Object, attributeTemplateFactoryMock.Object, propertyTemplateFactoryMock.Object);

			Assert.AreSame(errorTrackerMock.Object, sut.ErrorTracker, "ErrorTracker is not set properly");
			Assert.AreSame(attributeTemplateFactoryMock.Object, sut.AttributeTemplateFactory, "AttributeTemplateFactory not set properly");
			Assert.AreSame(propertyTemplateFactoryMock.Object, sut.PropertyTemplateFactory, "PropertyTemplateFactory not set properly");
		}

		[TestMethod]
		public void ModelClassTemplateFactory_GetTemplate_ShouldReturnModelClassTemplate()
		{
			var errorTrackerMock = new Mock<IErrorTracker>();
			var attributeTemplateFactoryMock = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();
			var propertyTemplateFactoryMock = new Mock<ICodeTemplateFactory<IModelClassPropertyDefinition>>();
			var modelClassDefinitionMock = new Mock<IModelClassDefinition>();

			var sut = new ModelClassTemplateFactory(errorTrackerMock.Object, attributeTemplateFactoryMock.Object, propertyTemplateFactoryMock.Object);
			var template = sut.GetTemplate(modelClassDefinitionMock.Object);

			Assert.IsNotNull(template, "Returned template is null");
			Assert.IsTrue(template.GetType() == typeof(ModelClassTemplate), "Returned template is wrong Type");
		}
	}
}
