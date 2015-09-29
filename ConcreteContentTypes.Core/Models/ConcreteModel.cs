using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models
{
	public abstract class ConcreteModel
	{
		public bool GetPropertiesRecursively { get; set; }
		
		public abstract string ContentTypeAlias { get; }

		public abstract string Name { get; set; }
		public abstract int Id { get; set; }
		public abstract int ParentId { get; set; }

		public abstract IPublishedContent Content { get; set; }

		public abstract void Init(IPublishedContent content);
		public abstract void Init(int id);

	}
}
