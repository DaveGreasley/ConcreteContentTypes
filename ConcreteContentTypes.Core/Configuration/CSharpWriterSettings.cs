using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public class CSharpWriterSettings : ConfigurationSection
	{
		#region Singleton

		public static CSharpWriterSettings Current { get; set; }

		static CSharpWriterSettings()
		{
			var configPath = string.Format(@"{0}Config\ConcreteContentTypes.config", AppDomain.CurrentDomain.BaseDirectory);
			ExeConfigurationFileMap map = new ExeConfigurationFileMap();
			map.ExeConfigFilename = configPath;

			var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
			Current = (CSharpWriterSettings)config.GetSection("ConcreteContentTypeCSharpWriterSettings");
		}

		#endregion

		[ConfigurationProperty("CSharpWriters", IsRequired=true)]
		public CSharpWriterConfigurationCollection TypeResolvers
		{
			get
			{
				return (CSharpWriterConfigurationCollection)this["CSharpWriters"];
			}
		}
	}
}
