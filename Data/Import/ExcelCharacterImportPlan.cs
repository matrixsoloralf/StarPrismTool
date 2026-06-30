using System.Collections.Generic;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Import
{
	public class ExcelCharacterImportPlan
	{
		public ExcelCharacterImportPlan()
		{
			Characters = new List<Character>();
			Skills = new List<Skill>();
			ImportedCharacterNames = new List<string>();
			OverwrittenCharacterNames = new List<string>();
			NewCharacterNames = new List<string>();
		}

		public string SourceFilePath { get; set; }

		public List<Character> Characters { get; set; }

		public List<Skill> Skills { get; set; }

		public List<string> ImportedCharacterNames { get; set; }

		public List<string> OverwrittenCharacterNames { get; set; }

		public List<string> NewCharacterNames { get; set; }
	}

	public class ExcelCharacterImportResult
	{
		public int CharacterCount { get; set; }

		public int SkillCount { get; set; }

		public int OverwrittenCharacterCount { get; set; }

		public int NewCharacterCount { get; set; }
	}
}
