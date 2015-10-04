using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models
{
	public class ConcreteModel
	{
		public bool GetPropertiesRecursively { get; set; }

		public virtual string ContentTypeAlias { get; protected set; }

		public virtual string Name { get; set; }
		public virtual int Id { get; set; }
		public virtual int ParentId { get; set; }

		public virtual IPublishedContent Content { get; set; }

		public virtual void Init(IPublishedContent content)
		{

		}

		public virtual void Init(ConcreteModel model)
		{

		}

		public virtual void Init(int id)
		{

		}

		protected int GetParentIdFromPath(string path)
		{
			if (!string.IsNullOrWhiteSpace(path))
			{
				//First try and get parent id from the path
				var pathElements = path.Split(',');

				if (pathElements != null && pathElements.Count() >= 2)
				{
					var parentId = pathElements[pathElements.Length - 2];

					if (!string.IsNullOrWhiteSpace(parentId))
						return Convert.ToInt32(parentId, CultureInfo.InvariantCulture);
				}
			}
			//If that doesn't work then get it from the parent content object. 
			return this.Content != null && this.Content.Parent != null ? this.Content.Parent.Id : -1;
		}
	}
}
