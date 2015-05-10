using ConcreteContentTypes.Core.PropertyTypeResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.DataTypeResolution
{
	public abstract class DataTypeResolverBase
	{
		protected IDataTypeDefinition _dataType;
		protected PreValueCollection _preValues;

		public DataTypeResolverBase(IDataTypeDefinition dataType, PreValueCollection preValues)
		{
			_dataType = dataType;
			_preValues = preValues;
		}

		public abstract List<TypeResolverBase> GetTypeResolvers();
	}
}
