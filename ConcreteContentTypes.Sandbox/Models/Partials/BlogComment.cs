using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConcreteContentTypes.Sandbox.Models
{
	[MetadataType(typeof(BlogCommentMetaData))]
	public partial class BlogComment
	{
	}

	public class BlogCommentMetaData
	{
		[Phone]
		public string FullName { get; set; }

		[EmailAddress]
		public string Comment { get; set; } 
	}
}