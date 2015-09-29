using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Events
{
	public class ConcreteEvents : IConcreteEvents
	{
		private static ConcreteEvents _instance = null;
		public static ConcreteEvents Current
		{
			get
			{
				if (_instance == null)
					_instance = new ConcreteEvents();

				return _instance;
			}
		}

		public static event Action<BaseClassDefinition> ContentBaseClassGenerating;
		public static event Action<ModelClassDefinition> ContentModelClassGenerating;
		public static event Action<BaseClassDefinition> MediaBaseClassGenerating;
		public static event Action<ModelClassDefinition> MediaModelClassGenerating;

		public ConcreteEvents()
		{

		}

		public void RaiseContentBaseClassGenerating(BaseClassDefinition classDefinition)
		{
			if (ContentBaseClassGenerating != null)
				ContentBaseClassGenerating(classDefinition);
		}

		public void RaiseContentModelClassGenerating(ModelClassDefinition classDefinition)
		{
			if (ContentModelClassGenerating != null)
				ContentModelClassGenerating(classDefinition);
		}

		public void RaiseMediaBaseClassGenerating(BaseClassDefinition classDefinition)
		{
			if (MediaBaseClassGenerating != null)
				MediaBaseClassGenerating(classDefinition);
		}

		public void RaiseMediaModelClassGenerating(ModelClassDefinition classDefinition)
		{
			if (MediaModelClassGenerating != null)
				MediaModelClassGenerating(classDefinition);
		}
	}
}
