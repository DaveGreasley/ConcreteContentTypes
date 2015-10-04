using ConcreteContentTypes.Core.CodeGeneration;
using ConcreteContentTypes.Core.CodeGeneration;
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
		public void CSharpCodeGeneratorFacade_GenerateBaseClass_CallsBaseClassCodeGenerator()
		{
			var modelClassTemplateFactory = new Mock<ICodeTemplateFactory<IModelClassDefinition>>();
			var baseClassDefinitionMock = new Mock<IBaseClassDefinition>();
			var codeTemplateMock = new Mock<ICodeTemplate>();

			var baseClassTemplateFactory = new Mock<ICodeTemplateFactory<IBaseClassDefinition>>();
			baseClassTemplateFactory.Setup(x => x.GetTemplate(baseClassDefinitionMock.Object)).Returns(codeTemplateMock.Object);
			
			var sut = new CSharpCodeGeneratorFacade(baseClassTemplateFactory.Object, modelClassTemplateFactory.Object);
			sut.GenerateBaseClass(baseClassDefinitionMock.Object);

			baseClassTemplateFactory.Verify(x => x.GetTemplate(baseClassDefinitionMock.Object),
				"Not calling BaseClassCodeGenerator correctly");
		}

		[TestMethod]
		public void CSharpCodeGeneratorFacade_GenerateModelClass_CallsModelClassGeneratorCorrectly()
		{
			var baseClassTemplateFactory = new Mock<ICodeTemplateFactory<IBaseClassDefinition>>();
			var modelClassDefinitionMock = new Mock<IModelClassDefinition>();
			var codeTemplateMock = new Mock<ICodeTemplate>();

			var modelClassTemplateFactory = new Mock<ICodeTemplateFactory<IModelClassDefinition>>();
			modelClassTemplateFactory.Setup(x => x.GetTemplate(modelClassDefinitionMock.Object)).Returns(codeTemplateMock.Object);

			var sut = new CSharpCodeGeneratorFacade(baseClassTemplateFactory.Object, modelClassTemplateFactory.Object);
			sut.GenerateModelClass(modelClassDefinitionMock.Object);

			modelClassTemplateFactory.Verify(x => x.GetTemplate(modelClassDefinitionMock.Object), 
				"Not calling ModelClassCodeGenerator correctly");
		}
	}
}
