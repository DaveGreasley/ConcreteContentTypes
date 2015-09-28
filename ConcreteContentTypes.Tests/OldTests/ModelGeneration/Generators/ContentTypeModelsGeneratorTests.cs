using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.ModelGeneration.Generators;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Tests.DummyObjects.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Tests.ModelGeneration.Generators
{
	[TestClass]
	public class ContentTypeModelsGeneratorTests
	{
		[TestMethod]
		public void ContentTypeModelsGenerator_SingleClassNoProperties()
		{
			IConcreteSettings settings = new DummyConcreteSettings()
			{
				CSharpOutputFolder = "DummyModels",
				Enabled = true,
				GenerateOnContentTypeSave = true,
				GenerateOnMediaTypeSave = false,
				Namespace = "TestNameSpace"
			};
			
			DummyContentTypeClassDefinition classDefinition = new DummyContentTypeClassDefinition(new List<Core.Models.Definitions.PropertyDefinition>(),
				"DummyClass", settings.Namespace, Umbraco.Core.Models.PublishedItemType.Content);

			

			ContentTypeModelsGenerator sut = new ContentTypeModelsGenerator(new List<ClassDefinitionBase>() { classDefinition }, )
		}
	}
}
