using ConcreteContentTypes.Core.PropertyTypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.DataTypeResolution
{
	public class ArchetypeDataTypeResolver : DataTypeResolverBase
	{
		public ArchetypeDataTypeResolver(IDataTypeDefinition dataType, PreValueCollection preValues)
			: base(dataType, preValues)
		{

		}

		public override List<TypeResolverBase> GetTypeResolvers()
		{
			List<TypeResolverBase> typeResolvers = new List<TypeResolverBase>();



			return typeResolvers;
		}
	}
}
