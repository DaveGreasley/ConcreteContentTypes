using ConcreteContentTypes.Core.Interfaces;
using ConcreteContentTypes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using WebBlocks.Utilities.WebBlocks;
using WB = WebBlocks.ViewTemplates;

namespace ConcreteContentTypes.WebBlocks
{
	public class WebBlocksTemplatePage<BlockT> : WB.WebBlocksTemplatePage where BlockT : IUmbracoContent, new()
    {
		public new BlockT CurrentBlock { get; set; }
		public new BlockT Model { get; set; }

		/// <summary>
		/// Access to the Umbraco Render Model.
		/// </summary>
		public RenderModel RenderModel { get { return base.Model; } }

		public WebBlocksTemplatePage()
		{
		}

		protected override void InitializePage()
		{
			base.InitializePage();

			this.Model = new BlockT();
			this.Model.Init(WebBlocksUtility.CurrentBlockContent);
			this.CurrentBlock = this.Model;
		}
    }
}
