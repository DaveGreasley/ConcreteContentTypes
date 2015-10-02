using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	public interface ICodeTemplateFactory<T>
	{
		ICodeTemplate GetTemplate(T definition);
	}
}
