using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Interfaces
{
	public interface IUmbracoContent
	{
		IPublishedContent Content { get; set; }

		void Init(IPublishedContent content);
		void Init(int id);
	}
}
