using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StarPrismTools.Models
{
	[DataContract]
	public class Skill
	{
		public Skill()
		{
			Costs = new List<SkillCost>();
			Effects = new List<SkillEffect>();
			Options = new List<SkillOption>();
			Metadata = new EntityMetadata();
		}

		[DataMember(Order = 1)]
		public string Id { get; set; }

		[DataMember(Order = 2)]
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Type { get; set; }

		[DataMember(Order = 4)]
		public string Trigger { get; set; }

		[DataMember(Order = 5)]
		public List<SkillCost> Costs { get; set; }

		[DataMember(Order = 6)]
		public SkillTargeting Targeting { get; set; }

		[DataMember(Order = 7)]
		public string Description { get; set; }

		[DataMember(Order = 8)]
		public List<SkillEffect> Effects { get; set; }

		[DataMember(Order = 9)]
		public List<SkillOption> Options { get; set; }

		[DataMember(Order = 10)]
		public EntityMetadata Metadata { get; set; }
	}

	[DataContract]
	public class SkillCost
	{
		[DataMember(Order = 1)]
		public string Card { get; set; }

		[DataMember(Order = 2)]
		public int Count { get; set; }
	}

	[DataContract]
	public class SkillTargeting
	{
		[DataMember(Order = 1)]
		public string TargetType { get; set; }

		[DataMember(Order = 2)]
		public int? Range { get; set; }

		[DataMember(Order = 3)]
		public string RangeShape { get; set; }

		[DataMember(Order = 4)]
		public string Movement { get; set; }
	}

	[DataContract]
	public class SkillEffect
	{
		[DataMember(Order = 1)]
		public string Kind { get; set; }

		[DataMember(Order = 2)]
		public string Target { get; set; }

		[DataMember(Order = 3)]
		public int? Amount { get; set; }

		[DataMember(Order = 4)]
		public string DamageType { get; set; }

		[DataMember(Order = 5)]
		public string Condition { get; set; }

		[DataMember(Order = 6)]
		public string Notes { get; set; }
	}

	[DataContract]
	public class SkillOption
	{
		[DataMember(Order = 1)]
		public string Kind { get; set; }

		[DataMember(Order = 2)]
		public int? Amount { get; set; }

		[DataMember(Order = 3)]
		public string Notes { get; set; }
	}
}
