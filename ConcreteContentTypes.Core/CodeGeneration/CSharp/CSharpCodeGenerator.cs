using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp
{
	public class CSharpCodeGenerator : ICodeGenerator
	{
		public IBaseClassTemplate BaseClassTemplate { get; private set; }
		public IModelClassTemplate ModelClassTemplate { get; private set; }

		public CSharpCodeGenerator(IBaseClassTemplate baseClassTemplate, IModelClassTemplate modelClassTemplate)
		{
			this.BaseClassTemplate = baseClassTemplate;
			this.ModelClassTemplate = modelClassTemplate;
		}

		public string GenerateBaseClass(BaseClassDefinition classDefinition)
		{
			return this.BaseClassTemplate.TransformText(classDefinition);
		}

		public string GenerateModelClass(ModelClassDefinition classDefinition)
		{
			return this.ModelClassTemplate.TransformText(classDefinition);
		}
	}
}
