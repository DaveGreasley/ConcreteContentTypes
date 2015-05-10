using ConcreteContentTypes.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.DataTypeResolution
{
	public static class DataTypeResolverFactory
	{
		public static DataTypeResolverBase GetDataTypeResolver(IDataTypeDefinition dataType, PreValueCollection preValues)
		{
			try
			{
				var typeResolverConfig = TypeResolverSettings.Current.DataTypeResolvers
					.FirstOrDefault(x => x.SupportedTypes.Any(p => p.Alias == dataType.PropertyEditorAlias));

				if (typeResolverConfig == null)
					return null;

				string typeName = typeResolverConfig.Type.Split(',')[0];
				string assemblyName = typeResolverConfig.Type.Split(',')[1].Trim();

				var handle = Activator.CreateInstance(assemblyName, typeName, false, 
					BindingFlags.CreateInstance, 
					null, 
					new object[] { dataType, preValues }, 
					Thread.CurrentThread.CurrentCulture, 
					null);

				return handle.Unwrap() as DataTypeResolverBase;
			}
			catch
			{
				return null;
			}
		}
	}
}
