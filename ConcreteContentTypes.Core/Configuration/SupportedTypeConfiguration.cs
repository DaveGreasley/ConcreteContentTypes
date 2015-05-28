using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	public class PropertyEditorConfiguration : ConfigurationElement
	{
		[ConfigurationProperty("alias", IsKey = true, IsRequired = true)]
		public string Alias
		{
			get
			{
				return base["alias"] as string;
			}
			set
			{
				base["alias"] = value;
			}
		}

		[ConfigurationProperty("clrType", IsKey = true, IsRequired = false)]
		public string ClrType
		{
			get
			{
				return base["clrType"] as string;
			}
			set
			{
				base["clrType"] = value;
			}
		}
	}
}
