using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.FileWriters
{
	/// <summary>
	/// A file system writer that enables postponing of one or more file writing operations. 
	/// </summary>
	public interface IFileWriter
	{
		/// <summary>
		/// Queues a write operation. It will not be executed until WriteQueue() is called.
		/// </summary>
		/// <param name="fileName">The file name to create / overwrite</param>
		/// <param name="folder">The folder to write the file to</param>
		/// <param name="contents">The contents of the file</param>
		void QueueWriteOperation(string fileName, string folder, string contents);

		/// <summary>
		/// Completes all write operations that have been queued up and clears the queue.
		/// </summary>
		/// <returns>The number of files sucessfully written. </returns>
		int WriteQueue();
	}
}
