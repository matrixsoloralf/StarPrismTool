using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Export
{
	public class MarkdownCharacterExportService
	{
		private static readonly Dictionary<string, string> CardTokenMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{ "A", "ATK" },
			{ "ATK", "ATK" },
			{ "D", "DEF" },
			{ "DEF", "DEF" },
			{ "M", "MOB" },
			{ "MOB", "MOB" },
			{ "S", "SEN" },
			{ "SEN", "SEN" },
			{ "R", "REC" },
			{ "REC", "REC" },
			{ "T", "TAC" },
			{ "TAC", "TAC" },
			{ "?", "?" }
		};

		private static readonly Regex CardTokenRegex = new Regex(
			@"(?<![A-Za-z\[])(ATK|DEF|MOB|SEN|REC|TAC|A|D|M|S|R|T|\?)(?![A-Za-z\]])",
			RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public string Export(IEnumerable<Character> characters, IEnumerable<Skill> skills)
		{
			Dictionary<string, Skill> skillMap = (skills ?? Enumerable.Empty<Skill>())
				.Where(skill => skill != null && !string.IsNullOrWhiteSpace(skill.Id))
				.GroupBy(skill => skill.Id)
				.ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

			List<Character> orderedCharacters = (characters ?? Enumerable.Empty<Character>())
				.Where(character => character != null)
				.ToList();

			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < orderedCharacters.Count; i++)
			{
				AppendCharacter(builder, i + 1, orderedCharacters[i], skillMap);
				if (i < orderedCharacters.Count - 1)
				{
					builder.AppendLine("---");
					builder.AppendLine();
				}
			}

			return builder.ToString();
		}

		private static void AppendCharacter(StringBuilder builder, int index, Character character, IDictionary<string, Skill> skillMap)
		{
			CharacterProfile profile = character.Profile ?? new CharacterProfile();
			builder.AppendLine("# " + index + ". " + CleanText(GetCharacterDisplayName(character)));
			builder.AppendLine();
			builder.AppendLine("## 人物信息");
			builder.AppendLine();
			builder.AppendLine(string.Format("{0} | {1} | {2}", CleanText(character.Name), CleanText(profile.Sex), FormatAge(profile.Age)));
			builder.AppendLine();
			AppendParagraph(builder, profile.Story);
			builder.AppendLine("## 台词");
			builder.AppendLine();
			AppendParagraph(builder, FormatQuote(profile.Quote));
			builder.AppendLine("## 技能");
			builder.AppendLine();
			AppendSkills(builder, character, skillMap);
		}

		private static void AppendSkills(StringBuilder builder, Character character, IDictionary<string, Skill> skillMap)
		{
			List<CharacterSkillLink> links = (character.SkillLinks ?? new List<CharacterSkillLink>())
				.Where(link => link != null)
				.OrderBy(link => link.Order)
				.ToList();

			for (int i = 0; i < links.Count; i++)
			{
				CharacterSkillLink link = links[i];
				Skill skill = null;
				if (!string.IsNullOrWhiteSpace(link.SkillId))
				{
					skillMap.TryGetValue(link.SkillId, out skill);
				}

				string name = FirstNonEmpty(link.OverrideName, skill == null ? null : skill.Name, "未命名技能");
				string description = FirstNonEmpty(link.OverrideDescription, skill == null ? null : skill.Description, string.Empty);
				builder.AppendLine(string.Format("{0}. {1}：{2}", i + 1, CleanText(name), NormalizeCardTokens(CleanText(description))));
			}

			builder.AppendLine();
		}

		private static void AppendParagraph(StringBuilder builder, string value)
		{
			string text = CleanText(value);
			if (!string.IsNullOrWhiteSpace(text))
			{
				builder.AppendLine(text);
			}

			builder.AppendLine();
		}

		private static string FormatAge(int? age)
		{
			return age.HasValue ? age.Value + "岁" : "??岁";
		}

		private static string FormatQuote(string quote)
		{
			string text = CleanText(quote).Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}

			text = text.Trim(' ', '\t', '"', '\'', '“', '”');
			return "“" + text + "”";
		}

		private static string GetCharacterDisplayName(Character character)
		{
			return FirstNonEmpty(
				character.DisplayName,
				JoinNonEmpty(" ", character.Title, character.Name),
				character.Name,
				character.Id,
				"未命名角色");
		}

		private static string NormalizeCardTokens(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return string.Empty;
			}

			return CardTokenRegex.Replace(value, match =>
			{
				string normalized;
				return CardTokenMap.TryGetValue(match.Value, out normalized) ? "[" + normalized + "]" : match.Value;
			});
		}

		private static string CleanText(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return string.Empty;
			}

			return value.Replace("\r\n", "\n").Replace('\r', '\n').Trim();
		}

		private static string FirstNonEmpty(params string[] values)
		{
			foreach (string value in values)
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					return value.Trim();
				}
			}

			return string.Empty;
		}

		private static string JoinNonEmpty(string separator, params string[] values)
		{
			return string.Join(separator, values.Where(value => !string.IsNullOrWhiteSpace(value)).Select(value => value.Trim()));
		}
	}
}
