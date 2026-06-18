using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarPrismTools.Models
{
	[DataContract]
	public class EntityMetadata
	{
		public EntityMetadata()
		{
			Tags = new List<string>();
		}

		[DataMember(Order = 1)]
		public int Version { get; set; }

		[DataMember(Order = 2)]
		public string CreatedAt { get; set; }

		[DataMember(Order = 3)]
		public string UpdatedAt { get; set; }

		[DataMember(Order = 4)]
		public List<string> Tags { get; set; }
	}
}
