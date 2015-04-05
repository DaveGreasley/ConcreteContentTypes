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
				base["alis"] = value;
			}
		}
	}
}
