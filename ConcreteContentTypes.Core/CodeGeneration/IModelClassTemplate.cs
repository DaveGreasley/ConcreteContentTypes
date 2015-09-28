﻿using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	public interface IModelClassTemplate
	{
		UmbracoModelClassDefinition CurrentDefinition { get; }
		string TransformText(UmbracoModelClassDefinition classDefinition);
	}
}
