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
	public class BaseClassTemplateFactoryTests
	{
		[TestMethod]
		public void BaseClassTemplateFactory_Construct()
		{
			var errorTrackerMock = new Mock<IErrorTracker>();
			var attributeTemplateFactory = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();

			var sut = new BaseClassTemplateFactory(errorTrackerMock.Object, attributeTemplateFactory.Object);

			Assert.AreSame(errorTrackerMock.Object, sut.ErrorTracker, "ErrorTracker not set properly");
			Assert.AreSame(attributeTemplateFactory.Object, sut.AttributeTemplateFactory, "AttributeTemplateFactory not set properly");
		}

		[TestMethod]
		public void BaseClassTemplateFactory_GetTemplate_ShouldReturnBaseClassTemplate()
		{
			var errorTrackerMock = new Mock<IErrorTracker>();
			var attributeTemplateFactoryMock = new Mock<ICodeTemplateFactory<IAttributeDefinition>>();
			var baseClassDefinitionMock = new Mock<IBaseClassDefinition>();

			var sut = new BaseClassTemplateFactory(errorTrackerMock.Object, attributeTemplateFactoryMock.Object);
			var template = sut.GetTemplate(baseClassDefinitionMock.Object);

			Assert.IsNotNull(template, "Returned template is null");
			Assert.IsTrue(template.GetType() == typeof(BaseClassTemplate), "Returned template is the wrong type");
		}
	}
}
