using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.Configuration
{
	[ConfigurationCollection(typeof(TypeResolverConfigurationCollection), AddItemName="TypeResolver")]
	public class TypeResolverConfigurationCollection : ConfigurationElementCollection, IEnumerable<TypeResolverConfiguration>
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new TypeResolverConfiguration();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			var l_configElement = element as TypeResolverConfiguration;
			if (l_configElement != null)
				return l_configElement.Type;
			else
				return null;
		}

		public TypeResolverConfiguration this[int index]
		{
			get
			{
				return BaseGet(index) as TypeResolverConfiguration;
			}
		}

		#region IEnumerable<ConfigElement> Members

		IEnumerator<TypeResolverConfiguration> IEnumerable<TypeResolverConfiguration>.GetEnumerator()
		{
			return (from i in Enumerable.Range(0, this.Count)
					select this[i])
					.GetEnumerator();
		}

		#endregion
	}
}
