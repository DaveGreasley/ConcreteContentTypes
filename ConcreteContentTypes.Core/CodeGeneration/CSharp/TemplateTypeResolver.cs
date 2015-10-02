using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.CodeGeneration.CSharp
{
	public class TemplateTypeResolver : ITemplateTypeResolver
	{
		Dictionary<string, Type> _resolvedTypes;

		public TemplateTypeResolver()
		{
			_resolvedTypes = new Dictionary<string, Type>();

			LoadResolvedTypes();
		}

		private void LoadResolvedTypes()
		{
			//use reflection to load all ICodeTemplate instances and cache them here.
			//class will have to be assigned to a static somewhere on Appstart
			//Perhaps we need the ConcreteContext after all?
		}

		public Type ResolveType(string templateName)
		{
			if (!_resolvedTypes.ContainsKey(templateName))
				throw new ArgumentOutOfRangeException("templateName", templateName, "No template with that name loaded");

			return _resolvedTypes[templateName];
		}
	}
}
