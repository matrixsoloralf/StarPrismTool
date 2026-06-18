using System.Collections.Generic;

namespace StarPrismTools.Models
{
	public class StarPrismDataSet
	{
		public StarPrismDataSet()
		{
			Manifest = new DataManifest();
			Characters = new List<Character>();
			Skills = new List<Skill>();
			Concepts = new List<Concept>();
		}

		public DataManifest Manifest { get; set; }

		public List<Character> Characters { get; set; }

		public List<Skill> Skills { get; set; }

		public List<Concept> Concepts { get; set; }
	}
}
