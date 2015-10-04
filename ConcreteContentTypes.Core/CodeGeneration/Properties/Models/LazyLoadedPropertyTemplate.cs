using ConcreteContentTypes.Core.Helpers;
using ConcreteContentTypes.Core.Models.Definitions;
using ConcreteContentTypes.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.CodeGeneration.Properties
{
	public partial class LazyLoadedPropertyTemplate : ICodeTemplate
	{
		protected IModelClassPropertyDefinition Definition { get; set; }
		protected string _cacheSource;

		public LazyLoadedPropertyTemplate(IModelClassPropertyDefinition definition)
		{
			this.Definition = definition;
			_cacheSource = CacheNameHelper.GetCacheName(definition.ItemType);
		}

		public string GenerateCode()
		{
			return this.TransformText();
		}
	}
}
