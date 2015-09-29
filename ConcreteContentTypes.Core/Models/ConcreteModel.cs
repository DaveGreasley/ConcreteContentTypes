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
		public abstract void Init(ConcreteModel model);
		public abstract void Init(int id);

		protected int GetParentId(string path)
		{
			//First try and get parent id from the path
			var pathElements = path.Split(',');

			if (pathElements != null && pathElements.Count() >= 2)
			{
				var parentId = pathElements[pathElements.Length - 2];

				if (!string.IsNullOrWhiteSpace(parentId))
					return Convert.ToInt32(parentId);
			}

			//If that doesn't work then get it from the parent content object. 
			return this.Content != null && this.Content.Parent != null ? this.Content.Parent.Id : -1;
		}
	}
}
