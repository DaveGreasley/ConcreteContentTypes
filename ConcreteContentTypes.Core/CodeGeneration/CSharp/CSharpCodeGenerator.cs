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
		public IUmbracoBaseClassTemplate BaseClassTemplate { get; private set; }
		public IModelClassTemplate ModelClassTemplate { get; private set; }

		public CSharpCodeGenerator(IUmbracoBaseClassTemplate baseClassTemplate, IModelClassTemplate modelClassTemplate)
		{
			this.BaseClassTemplate = baseClassTemplate;
			this.ModelClassTemplate = modelClassTemplate;
		}

		public string GenerateBaseClass(UmbracoBaseClassDefinition classDefinition)
		{
			return this.BaseClassTemplate.TransformText(classDefinition);
		}

		public string GenerateModelClass(UmbracoModelClassDefinition classDefinition)
		{
			return this.ModelClassTemplate.TransformText(classDefinition);
		}
	}
}
