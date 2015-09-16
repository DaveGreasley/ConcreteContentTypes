using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace ConcreteContentTypes.Tests.DummyObjects.Umbraco
{
	public class DummyMediaType : IMediaType
	{
		public string Alias { get; set; }
		public string Name { get; set; }
		public int ParentId { get; set; }
		public IEnumerable<PropertyType> CompositionPropertyTypes { get; set; }
		public IEnumerable<ContentTypeSort> AllowedContentTypes { get; set; }

		#region Not Implemented

		public bool AddContentType(IContentTypeComposition contentType)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> CompositionAliases()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<int> CompositionIds()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PropertyGroup> CompositionPropertyGroups
		{
			get { throw new NotImplementedException(); }
		}

		public IEnumerable<IContentTypeComposition> ContentTypeComposition
		{
			get { throw new NotImplementedException(); }
		}

		public bool ContentTypeCompositionExists(string alias)
		{
			throw new NotImplementedException();
		}

		public bool RemoveContentType(string alias)
		{
			throw new NotImplementedException();
		}

		public bool AddPropertyGroup(string groupName)
		{
			throw new NotImplementedException();
		}

		public bool AddPropertyType(PropertyType propertyType)
		{
			throw new NotImplementedException();
		}

		public bool AddPropertyType(PropertyType propertyType, string propertyGroupName)
		{
			throw new NotImplementedException();
		}

		public bool AllowedAsRoot
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

		public string Description
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

		public string Icon
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

		public bool IsContainer
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

		public bool MovePropertyType(string propertyTypeAlias, string propertyGroupName)
		{
			throw new NotImplementedException();
		}

		public PropertyGroupCollection PropertyGroups
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

		public bool PropertyTypeExists(string propertyTypeAlias)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PropertyType> PropertyTypes
		{
			get { throw new NotImplementedException(); }
		}

		public void RemovePropertyGroup(string propertyGroupName)
		{
			throw new NotImplementedException();
		}

		public void RemovePropertyType(string propertyTypeAlias)
		{
			throw new NotImplementedException();
		}

		public void SetLazyParentId(Lazy<int> id)
		{
			throw new NotImplementedException();
		}

		public string Thumbnail
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
