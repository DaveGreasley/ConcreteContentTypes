using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class ContentModelClassDefinition : ModelClassDefinitionBase
	{
		public ContentModelClassDefinition(IContentType contentType, IContentType parent, string nameSpace, string defaultBaseClass = "")
			: base(contentType.Alias, nameSpace, PublishedItemType.Content)
		{
			this.BaseClass = GetBaseClass(contentType, parent, defaultBaseClass);
			this.Properties = new List<UmbracoPropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();
			this.ChildType = GetChildType(contentType);

			CreateDefinition(contentType, parent);
		}
	}
}
