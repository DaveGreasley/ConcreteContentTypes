using ConcreteContentTypes.Core.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Events
{
	public interface IConcreteEvents
	{
		//event Action<UmbracoBaseClassDefinition> ContentBaseClassGenerating;
		//event Action<ModelClassDefinition> ContentModelClassGenerating;
		//event Action<UmbracoBaseClassDefinition> MediaBaseClassGenerating;
		//event Action<ModelClassDefinition> MediaModelClassGenerating;

		void RaiseContentBaseClassGenerating(UmbracoBaseClassDefinition classDefinition);
		void RaiseContentModelClassGenerating(UmbracoModelClassDefinition classDefinition);
		void RaiseMediaBaseClassGenerating(UmbracoBaseClassDefinition classDefinition);
		void RaiseMediaModelClassGenerating(UmbracoModelClassDefinition classDefinition);
	}
}
