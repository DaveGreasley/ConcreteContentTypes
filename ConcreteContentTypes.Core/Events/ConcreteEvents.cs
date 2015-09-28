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

		public static event Action<UmbracoBaseClassDefinition> ContentBaseClassGenerating;
		public static event Action<UmbracoModelClassDefinition> ContentModelClassGenerating;
		public static event Action<UmbracoBaseClassDefinition> MediaBaseClassGenerating;
		public static event Action<UmbracoModelClassDefinition> MediaModelClassGenerating;

		public ConcreteEvents()
		{

		}

		public void RaiseContentBaseClassGenerating(UmbracoBaseClassDefinition classDefinition)
		{
			if (ContentBaseClassGenerating != null)
				ContentBaseClassGenerating(classDefinition);
		}

		public void RaiseContentModelClassGenerating(UmbracoModelClassDefinition classDefinition)
		{
			if (ContentModelClassGenerating != null)
				ContentModelClassGenerating(classDefinition);
		}

		public void RaiseMediaBaseClassGenerating(UmbracoBaseClassDefinition classDefinition)
		{
			if (MediaBaseClassGenerating != null)
				MediaBaseClassGenerating(classDefinition);
		}

		public void RaiseMediaModelClassGenerating(UmbracoModelClassDefinition classDefinition)
		{
			if (MediaModelClassGenerating != null)
				MediaModelClassGenerating(classDefinition);
		}
	}
}
