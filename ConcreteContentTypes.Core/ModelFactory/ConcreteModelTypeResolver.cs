using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.ObjectResolution;

namespace ConcreteContentTypes.Core.ModelFactory
{
	public class ConcreteModelTypeResolver : IConcreteModelTypeResolver
	{
		public Dictionary<string, Type> ModelTypes { get; private set; }

		public ConcreteModelTypeResolver(IEnumerable<Type> modelTypes)
		{
			this.ModelTypes = new Dictionary<string, Type>();

			foreach (var type in modelTypes)
			{
				this.ModelTypes.Add(type.Name, type);
			}
		}

		public Type ResolveType(string contentTypeAlias)
		{
			if (!this.ModelTypes.ContainsKey(contentTypeAlias))
				throw new ArgumentOutOfRangeException("contentTypeAlias", contentTypeAlias, "That does not appear to be a Concrete Type");

			return this.ModelTypes[contentTypeAlias];
		}
	}
}
