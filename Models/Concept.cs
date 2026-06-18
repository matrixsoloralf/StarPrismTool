using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarPrismTools.Models
{
	[DataContract]
	public class Concept
	{
		public Concept()
		{
			Aliases = new List<string>();
			Images = new List<ConceptImage>();
			RelatedConceptIds = new List<string>();
			Source = new ConceptSource();
			Metadata = new EntityMetadata();
		}

		[DataMember(Order = 1)]
		public string Id { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Summary { get; set; }

		[DataMember(Order = 4)]
		public string Description { get; set; }

		[DataMember(Order = 5)]
		public string Category { get; set; }

		[DataMember(Order = 6)]
		public string CategoryName { get; set; }

		[DataMember(Order = 7)]
		public int Order { get; set; }

		[DataMember(Order = 8)]
		public string Status { get; set; }

		[DataMember(Order = 9)]
		public List<string> Aliases { get; set; }

		[DataMember(Order = 10)]
		public List<ConceptImage> Images { get; set; }

		[DataMember(Order = 11)]
		public List<string> RelatedConceptIds { get; set; }

		[DataMember(Order = 12)]
		public ConceptSource Source { get; set; }

		[DataMember(Order = 13)]
		public EntityMetadata Metadata { get; set; }
	}

	[DataContract]
	public class ConceptImage
	{
		[DataMember(Order = 1)]
		public string Path { get; set; }

		[DataMember(Order = 2)]
		public string Caption { get; set; }
	}

	[DataContract]
	public class ConceptSource
	{
		[DataMember(Order = 1)]
		public string Document { get; set; }

		[DataMember(Order = 2)]
		public string Version { get; set; }

		[DataMember(Order = 3)]
		public string Section { get; set; }
	}
}
