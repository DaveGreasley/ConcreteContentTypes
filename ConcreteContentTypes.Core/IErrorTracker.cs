using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteContentTypes.Core
{
	public interface IErrorTracker
	{
		void Debug(string message);
		void Info(string message);
		void Warning(string message);
		void Error(string message, Exception ex = null);
		void Fatal(string message, Exception ex = null);

		bool FatalErrorHasOccurred { get; }
	}
}
