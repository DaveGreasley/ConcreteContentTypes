using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp.Classes
{
	public class ModelClassCodeGenerator : IModelClassCodeGenerator
	{
		public IModelClassTemplate Template { get; private set; }

		public ModelClassCodeGenerator(IModelClassTemplate template)
		{
			this.Template = template;
		}

		public string GenerateModelClass(IModelClassDefinition definition)
		{
			return "";
		}
	}
}
