using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public class TypeResolverSettings : ConfigurationSection
	{
		#region Singleton

		public static TypeResolverSettings Current { get; set; }

		static TypeResolverSettings()
		{
			Current = (TypeResolverSettings)ConfigurationManager.GetSection("ConcreteContentTypeResolvers");
		}

		#endregion

		[ConfigurationProperty("TypeResolvers", IsRequired=true)]
		public TypeResolverConfigurationCollection TypeResolvers
		{
			get
			{
				return (TypeResolverConfigurationCollection)this["TypeResolvers"];
			}
		}
	}
}
