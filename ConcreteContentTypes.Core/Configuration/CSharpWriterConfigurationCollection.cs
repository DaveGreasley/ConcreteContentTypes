using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	[ConfigurationCollection(typeof(CSharpWriterConfigurationCollection), AddItemName="CSWriter")]
	public class CSharpWriterConfigurationCollection : ConfigurationElementCollection, IEnumerable<CSharpWriterConfiguration>
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new CSharpWriterConfiguration();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			var l_configElement = element as CSharpWriterConfiguration;
			if (l_configElement != null)
				return l_configElement.Type;
			else
				return null;
		}

		public CSharpWriterConfiguration this[int index]
		{
			get
			{
				return BaseGet(index) as CSharpWriterConfiguration;
			}
		}

		#region IEnumerable<ConfigElement> Members

		IEnumerator<CSharpWriterConfiguration> IEnumerable<CSharpWriterConfiguration>.GetEnumerator()
		{
			return (from i in Enumerable.Range(0, this.Count)
					select this[i])
					.GetEnumerator();
		}

		#endregion
	}
}
