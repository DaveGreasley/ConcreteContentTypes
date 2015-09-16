using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests.DummyObjects.Umbraco
{
	public class DummyDataTypeDefinition : IDataTypeDefinition
	{
		public DummyDataTypeDefinition()
		{

		}

		#region Not Implemented

		public Guid ControlId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public DataTypeDatabaseType DatabaseType
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string PropertyEditorAlias
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IDictionary<string, object> AdditionalData
		{
			get { throw new NotImplementedException(); }
		}

		public int CreatorId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int Level
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string Name
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int ParentId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string Path
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int SortOrder
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool Trashed
		{
			get { throw new NotImplementedException(); }
		}

		public DateTime CreateDate
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool HasIdentity
		{
			get { throw new NotImplementedException(); }
		}

		public int Id
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Guid Key
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public DateTime UpdateDate
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public object DeepClone()
		{
			throw new NotImplementedException();
		}

		public void ForgetPreviouslyDirtyProperties()
		{
			throw new NotImplementedException();
		}

		public void ResetDirtyProperties(bool rememberPreviouslyChangedProperties)
		{
			throw new NotImplementedException();
		}

		public bool WasDirty()
		{
			throw new NotImplementedException();
		}

		public bool WasPropertyDirty(string propertyName)
		{
			throw new NotImplementedException();
		}

		public bool IsDirty()
		{
			throw new NotImplementedException();
		}

		public bool IsPropertyDirty(string propName)
		{
			throw new NotImplementedException();
		}

		public void ResetDirtyProperties()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
