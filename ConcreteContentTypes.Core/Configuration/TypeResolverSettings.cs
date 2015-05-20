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
			var configPath = string.Format(@"{0}Config\ConcreteContentTypes.config", AppDomain.CurrentDomain.BaseDirectory);
			ExeConfigurationFileMap map = new ExeConfigurationFileMap();
			map.ExeConfigFilename = configPath;

			var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
			Current = (TypeResolverSettings)config.GetSection("ConcreteContentTypeResolvers");
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
