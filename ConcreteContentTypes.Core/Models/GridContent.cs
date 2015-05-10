using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace ConcreteContentTypes.Core.Models
{
	public class GridContent
	{
		public IPublishedContent Content { get; set; }
		public string PropertyAlias { get; set; }

		public GridContent(string propertyAlias, IPublishedContent content)
		{
			this.PropertyAlias = propertyAlias;
			this.Content = content;
		}

		public MvcHtmlString GetGridHtml()
		{
			return this.Content.GetGridHtml(this.PropertyAlias);
		}

		public MvcHtmlString GetGridHtml(HtmlHelper helper)
		{
			return this.Content.GetGridHtml(helper, this.PropertyAlias);
		}

		public MvcHtmlString GetGridHtml(string framework)
		{
			return this.Content.GetGridHtml(this.PropertyAlias, framework);
		}

		public MvcHtmlString GetGridHtml(HtmlHelper helper, string framework)
		{
			return this.Content.GetGridHtml(helper, this.PropertyAlias, framework);
		}

		public override string ToString()
		{
			return this.Content.GetGridHtml(this.PropertyAlias).ToHtmlString();
		}
	}
}
