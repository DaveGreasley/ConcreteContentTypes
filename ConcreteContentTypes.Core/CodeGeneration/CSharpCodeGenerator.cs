﻿using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	public class CSharpCodeGenerator : ICodeGenerator
	{
		ICodeTemplateFactory<IBaseClassDefinition> BaseClassTemplateFactory { get; set; }
		ICodeTemplateFactory<IModelClassDefinition> ModelClassTemplateFactory { get; set; }

		public CSharpCodeGenerator(ICodeTemplateFactory<IBaseClassDefinition> baseClassTemplateFactory, 
			ICodeTemplateFactory<IModelClassDefinition> modelClassFactory)
		{
			this.BaseClassTemplateFactory = baseClassTemplateFactory;
			this.ModelClassTemplateFactory = modelClassFactory;
		}

		public string GenerateBaseClass(IBaseClassDefinition classDefinition)
		{
			var baseClassTemplate = this.BaseClassTemplateFactory.GetTemplate(classDefinition);

			return baseClassTemplate.GenerateCode();
		}

		public string GenerateModelClass(IModelClassDefinition classDefinition)
		{
			var modelClassTemplate = this.ModelClassTemplateFactory.GetTemplate(classDefinition);

			return modelClassTemplate.GenerateCode();
		}
	}
}
