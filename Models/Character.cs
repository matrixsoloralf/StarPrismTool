using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarPrismTools.Models
{
	[DataContract]
	public class Character
	{
		public Character()
		{
			Profile = new CharacterProfile();
			Assets = new CharacterAssets();
			SkillLinks = new List<CharacterSkillLink>();
			Metadata = new EntityMetadata();
		}

		[DataMember(Order = 1)]
		public string Id { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Title { get; set; }

		[DataMember(Order = 4)]
		public string DisplayName { get; set; }

		[DataMember(Order = 5)]
		public CharacterProfile Profile { get; set; }

		[DataMember(Order = 6)]
		public CharacterAssets Assets { get; set; }

		[DataMember(Order = 7)]
		public List<CharacterSkillLink> SkillLinks { get; set; }

		[DataMember(Order = 8)]
		public EntityMetadata Metadata { get; set; }
	}

	[DataContract]
	public class CharacterProfile
	{
		[DataMember(Order = 1)]
		public string Sex { get; set; }

		[DataMember(Order = 2)]
		public int? Age { get; set; }

		[DataMember(Order = 3)]
		public string Story { get; set; }

		[DataMember(Order = 4)]
		public string Quote { get; set; }
	}

	[DataContract]
	public class CharacterAssets
	{
		public CharacterAssets()
		{
			CardFronts = new List<string>();
		}

		[DataMember(Order = 1)]
		public string PortraitPath { get; set; }

		[DataMember(Order = 2)]
		public string IllustrationPath { get; set; }

		[DataMember(Order = 3)]
		public List<string> CardFronts { get; set; }
	}

	[DataContract]
	public class CharacterSkillLink
	{
		[DataMember(Order = 1)]
		public string SkillId { get; set; }

		[DataMember(Order = 2)]
		public int Order { get; set; }

		[DataMember(Order = 3)]
		public string OverrideName { get; set; }

		[DataMember(Order = 4)]
		public string OverrideDescription { get; set; }
	}
}
