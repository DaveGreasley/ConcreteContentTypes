using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	[ConfigurationCollection(typeof(PropertyEditorConfiguration), AddItemName="PropertyEditor")]
	public class PropertyEditorConfigurationCollection : ConfigurationElementCollection, IEnumerable<PropertyEditorConfiguration>
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new PropertyEditorConfiguration();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			var l_configElement = element as PropertyEditorConfiguration;
			if (l_configElement != null)
				return l_configElement.Alias;
			else
				return null;
		}

		public PropertyEditorConfiguration this[int index]
		{
			get
			{
				return BaseGet(index) as PropertyEditorConfiguration;
			}
		}

		#region IEnumerable<ConfigSubElement> Members

		IEnumerator<PropertyEditorConfiguration> IEnumerable<PropertyEditorConfiguration>.GetEnumerator()
		{
			return (from i in Enumerable.Range(0, this.Count)
					select this[i])
					.GetEnumerator();
		}

		#endregion
	}
}
