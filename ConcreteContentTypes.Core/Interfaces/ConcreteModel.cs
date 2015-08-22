﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Core.Interfaces
{
	public interface IConcreteModel
	{
		string ContentTypeAlias { get; }
		bool GetPropertiesRecursively { get; set; }

		string Name { get; set; }
		int Id { get; set; }
		int ParentId { get; set; }

		IPublishedContent Content { get; set; }

		void Init(IPublishedContent content);
		void Init(int id);
	}
}
