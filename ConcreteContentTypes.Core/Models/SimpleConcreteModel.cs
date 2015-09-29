using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Models
{
	public class SimpleConcreteModel : ConcreteModel
	{
		public SimpleConcreteModel()
		{
		}

		private string _contentTypeAlias;
		public override string ContentTypeAlias { get { return _contentTypeAlias; } }
		public override string Name { get; set; }
		public override int Id { get; set; }
		public override int ParentId { get; set; }

		public override IPublishedContent Content { get; set; }

		public override void Init(int id)
		{
			this.Init(UmbracoContext.Current.ContentCache.GetById(id));
		}

		public override void Init(ConcreteModel model)
		{
			this.Init(model.Content);
		}

		public override void Init(Umbraco.Core.Models.IPublishedContent content)
		{
			_contentTypeAlias = content.ContentType.Alias;

			this.Name = content.Name;
			this.Id = content.Id;
			this.ParentId = GetParentId(content.Path);
				
			this.Content = content;
		}
	}
}
