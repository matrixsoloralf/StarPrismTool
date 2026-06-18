using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarPrismTools.Models
{
	[DataContract]
	public class DataManifest
	{
		public DataManifest()
		{
			Characters = new List<EntityIndexItem>();
			Skills = new List<EntityIndexItem>();
		}

		[DataMember(Order = 1)]
		public int SchemaVersion { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public List<EntityIndexItem> Characters { get; set; }

		[DataMember(Order = 4)]
		public List<EntityIndexItem> Skills { get; set; }
	}

	[DataContract]
	public class EntityIndexItem
	{
		[DataMember(Order = 1)]
		public string Id { get; set; }

		[DataMember(Order = 2)]
		public string DisplayName { get; set; }

		[DataMember(Order = 3)]
		public string Path { get; set; }
	}
}
