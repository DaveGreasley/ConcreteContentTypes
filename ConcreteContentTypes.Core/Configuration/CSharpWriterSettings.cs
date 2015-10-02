using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Logging;

namespace ConcreteContentTypes.Core.Configuration
{
	public class CSharpWriterSettings : ConfigurationSection
	{
		#region Singleton

		private static CSharpWriterSettings _settings = null;
		public static CSharpWriterSettings Current
		{
			get
			{
				if (_settings == null)
					_settings = LoadSettings();

				return _settings;
			}
		}

		private static CSharpWriterSettings LoadSettings()
		{
			try
			{
				var configPath = string.Format(CultureInfo.CurrentCulture, @"{0}Config\ConcreteContentTypes.config", AppDomain.CurrentDomain.BaseDirectory);
				ExeConfigurationFileMap map = new ExeConfigurationFileMap();
				map.ExeConfigFilename = configPath;

				var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
				return (CSharpWriterSettings)config.GetSection("ConcreteCSharpWriterSettings");
			}
			catch (ConfigurationErrorsException ex)
			{
				LogHelper.Error<CSharpWriterSettings>("Error loading CSharpWriterSettings.", ex);
				return null;
			}
		}

		#endregion

		[ConfigurationProperty("CSharpWriters", IsRequired=true)]
		public CSharpWriterConfigurationCollection Writers
		{
			get
			{
				return (CSharpWriterConfigurationCollection)this["CSharpWriters"];
			}
		}
	}
}
