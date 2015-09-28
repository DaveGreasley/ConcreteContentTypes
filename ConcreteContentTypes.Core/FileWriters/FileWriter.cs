using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core.FileWriters
{
	public class FileWriter : IFileWriter
	{
		public List<WriteOperation> QueuedOperations { get; set; }

		public FileWriter()
		{
			this.QueuedOperations = new List<WriteOperation>();
		}

		public void QueueWriteOperation(string fileName, string folder, string contents)
		{
			if (string.IsNullOrWhiteSpace(fileName))
				throw new ArgumentException("You must set a filename to write a file!", "fileName");

			if (string.IsNullOrWhiteSpace(folder))
				throw new ArgumentException("You must set a folder to write the file to!", "folder");

			if (string.IsNullOrWhiteSpace(contents))
				throw new ArgumentException("Shouldn't be trying to write an empty file!", "contents");


			if (this.QueuedOperations.Any(x => x.FileName.ToLower().Trim() == fileName.ToLower().Trim()
				&& x.Folder.ToLower().Trim() == folder.ToLower().Trim()))
				throw new InvalidOperationException("A WriteOperation has already been queued for the same file in the same folder.");


			this.QueuedOperations.Add(new WriteOperation(fileName, folder, contents));
		}

		public int WriteQueue()
		{
			int numFilesWritten = 0;

			foreach (var operation in this.QueuedOperations)
			{
				try
				{
					//Ensure the directory we are writing to exists
					if (!Directory.Exists(operation.Folder))
						Directory.CreateDirectory(operation.Folder);

					string filePath = string.Format("{0}\\{1}", operation.Folder.TrimEnd('\\'), operation.FileName);

					//Write to the file, either creating a new file or overwriting an existing one
					File.WriteAllText(filePath, operation.Contents);

					numFilesWritten++;
				}
				catch (Exception ex)
				{
					//TODO: Work out what to do here!
				}
			}

			//Might want to do something better than this, but it will do for now.
			this.QueuedOperations.Clear();

			return numFilesWritten;
		}
	}
}
