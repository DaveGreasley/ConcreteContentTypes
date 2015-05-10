using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.PropertyTypeResolution
{
	public class ArchetypeTypeResolver : TypeResolverBase
	{
		public ArchetypeTypeResolver(PropertyType propertyType)
			: base(propertyType)
		{

		}

		public override string GetPropertyDefinition()
		{
			throw new NotImplementedException();
		}

		public override string GetValueString()
		{
			throw new NotImplementedException();
		}

		protected override Dictionary<string, string> GetSupportedTypes()
		{
			Dictionary<string, string> supportedTypes = new Dictionary<string, string>();

			supportedTypes.Add("immulus.Archetype", DetermineTypeName());

			return supportedTypes;
		}

		private string DetermineTypeName()
		{
			throw new NotImplementedException();
		}
	}
}
