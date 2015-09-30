using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp
{
	public class CSharpCodeGeneratorFacade : ICodeGeneratorFacade
	{
		public IBaseClassCodeGenerator BaseClassGenerator { get; private set; }
		public IModelClassCodeGenerator ModelClassGenerator { get; private set; }

		public CSharpCodeGeneratorFacade(IBaseClassCodeGenerator baseClassGenerator, IModelClassCodeGenerator modelClassGenerator)
		{
			this.BaseClassGenerator = baseClassGenerator;
			this.ModelClassGenerator = modelClassGenerator;
		}

		public string GenerateBaseClass(IBaseClassDefinition classDefinition)
		{
			return this.BaseClassGenerator.GenerateBaseClass(classDefinition);
		}

		public string GenerateModelClass(IModelClassDefinition classDefinition)
		{
			return this.ModelClassGenerator.GenerateModelClass(classDefinition);
		}
	}
}
