using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration.CSharp.Attributes;
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
	public class AttributeTemplateFactoryTests
	{
		[TestMethod]
		public void AttributeTemplateFactory_GetTemplate_ShouldReturnAttributeDefinitionTemplate()
		{
			var errorTrackerMock = new Mock<IErrorTracker>();
			var attribtueDefinitionMock = new Mock<IAttributeDefinition>();

			var sut = new AttributeTemplateFactory(errorTrackerMock.Object);

			var template = sut.GetTemplate(attribtueDefinitionMock.Object);

			Assert.IsNotNull(template, "Returned template is null");
			Assert.IsTrue(template.GetType() == typeof(AttributeTemplate), "Returned Template is wrong Type");
		}
	}
}
