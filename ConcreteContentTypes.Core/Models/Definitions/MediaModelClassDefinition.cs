using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Models.Definitions
{
	public class MediaModelClassDefinition : ModelClassDefinitionBase
	{
		public MediaModelClassDefinition(IMediaType mediaType, IMediaType parent, string nameSpace, string defaultBaseClass = "")
			: base(mediaType.Alias, nameSpace, PublishedItemType.Media)
		{
			this.BaseClass = GetBaseClass(mediaType, parent, defaultBaseClass);
			this.Properties = new List<PropertyDefinition>();
			this.Attributes = new List<AttributeDefinition>();
			this.ChildType = GetChildType(mediaType);

			CreateDefinition(mediaType, parent);
		}
	}
}
