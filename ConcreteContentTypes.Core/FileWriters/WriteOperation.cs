using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.FileWriters
{
	public class WriteOperation
	{
		public string FileName { get; set; }
		public string Folder { get; set; }
		public string Contents { get; set; }

		public WriteOperation(string fileName, string folder, string contents)
		{
			this.FileName = fileName;
			this.Folder = folder;
			this.Contents = contents;
		}
	}
}
