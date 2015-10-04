using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace ConcreteContentTypes.Core.CodeGeneration
{
	public class TemplateTypeResolver : ITemplateTypeResolver
	{
		Dictionary<string, Type> _resolvedTypes = null;

		public TemplateTypeResolver()
		{
			LoadResolvedTypes();
		}

		private void LoadResolvedTypes()
		{
			_resolvedTypes = new Dictionary<string, Type>();

			foreach (var templateType in PluginManager.Current.ResolveTypes<ICodeTemplate>(true))
			{
				_resolvedTypes.Add(templateType.Name, templateType);
			}
		}

		public Type ResolveType(string templateName)
		{
			if (!_resolvedTypes.ContainsKey(templateName))
				throw new ArgumentOutOfRangeException("templateName", templateName, "No template with that name loaded");

			return _resolvedTypes[templateName];
		}
	}
}
