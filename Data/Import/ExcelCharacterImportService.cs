using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using StarPrismTools.Data.Json;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Import
{
	public class ExcelCharacterImportService
	{
		private const string MainNamespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
		private const string RelationshipNamespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
		private readonly IJsonFileStore jsonFileStore;

		public ExcelCharacterImportService(IJsonFileStore jsonFileStore)
		{
			this.jsonFileStore = jsonFileStore;
		}

		public OperationResult<ExcelCharacterImportPlan> CreatePlan(string excelFilePath, StarPrismDataSet currentDataSet)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(excelFilePath) || !File.Exists(excelFilePath))
				{
					return OperationResult<ExcelCharacterImportPlan>.Fail("Excel file does not exist: " + excelFilePath);
				}

				WorkbookData workbook = ReadWorkbook(excelFilePath);
				if (!workbook.Sheets.ContainsKey("info") || !workbook.Sheets.ContainsKey("base"))
				{
					return OperationResult<ExcelCharacterImportPlan>.Fail("Unsupported Excel format. Required sheets: info, base.");
				}

				string advancedSheetName = workbook.Sheets.ContainsKey("advanved") ? "advanved" : "advanced";
				if (!workbook.Sheets.ContainsKey(advancedSheetName))
				{
					return OperationResult<ExcelCharacterImportPlan>.Fail("Unsupported Excel format. Required sheet: advanved or advanced.");
				}

				Dictionary<string, Dictionary<string, string>> infoRows = IndexRowsByNickname(workbook.Sheets["info"]);
				Dictionary<string, Dictionary<string, string>> baseRows = IndexRowsByNickname(workbook.Sheets["base"]);
				Dictionary<string, Dictionary<string, string>> advancedRows = IndexRowsByNickname(workbook.Sheets[advancedSheetName]);
				Dictionary<string, Character> currentById = (currentDataSet == null ? Enumerable.Empty<Character>() : currentDataSet.Characters)
					.Where(character => character != null && !string.IsNullOrWhiteSpace(character.Id))
					.GroupBy(character => NormalizeKey(character.Id))
					.ToDictionary(group => group.Key, group => group.First());

				ExcelCharacterImportPlan plan = new ExcelCharacterImportPlan
				{
					SourceFilePath = excelFilePath
				};

				foreach (string nickname in infoRows.Keys)
				{
					if (!advancedRows.ContainsKey(nickname))
					{
						continue;
					}

					Dictionary<string, string> info = infoRows[nickname];
					Dictionary<string, string> baseData = baseRows.ContainsKey(nickname) ? baseRows[nickname] : new Dictionary<string, string>();
					Dictionary<string, string> advanced = advancedRows[nickname];
					ImportedCharacter imported = BuildImportedCharacter(nickname, info, baseData, advanced, currentById);
					if (imported == null)
					{
						continue;
					}

					plan.Characters.Add(imported.Character);
					plan.Skills.AddRange(imported.Skills);
					plan.ImportedCharacterNames.Add(imported.Character.Name);

					if (imported.IsOverwrite)
					{
						plan.OverwrittenCharacterNames.Add(imported.Character.Name);
					}
					else
					{
						plan.NewCharacterNames.Add(imported.Character.Name);
					}
				}

				if (plan.Characters.Count == 0)
				{
					return OperationResult<ExcelCharacterImportPlan>.Fail("No character data was found in the Excel file.");
				}

				return OperationResult<ExcelCharacterImportPlan>.Ok(plan);
			}
			catch (Exception ex)
			{
				return OperationResult<ExcelCharacterImportPlan>.Fail("Failed to parse Excel character data.", ex);
			}
		}

		public OperationResult<ExcelCharacterImportResult> ApplyPlan(string repositoryRoot, StarPrismDataSet currentDataSet, ExcelCharacterImportPlan plan)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(repositoryRoot) || !Directory.Exists(repositoryRoot))
				{
					return OperationResult<ExcelCharacterImportResult>.Fail("Data repository does not exist: " + repositoryRoot);
				}

				if (plan == null || plan.Characters.Count == 0)
				{
					return OperationResult<ExcelCharacterImportResult>.Fail("Import plan is empty.");
				}

				StarPrismDataSet merged = currentDataSet ?? new StarPrismDataSet();
				if (merged.Manifest == null)
				{
					merged.Manifest = new DataManifest();
				}

				List<Character> importedCharacters = plan.Characters
					.Where(character => character != null && !string.IsNullOrWhiteSpace(character.Id))
					.GroupBy(character => NormalizeKey(character.Id))
					.Select(group => group.Last())
					.ToList();
				HashSet<string> importedSkillIds = new HashSet<string>(plan.Skills.Select(skill => skill.Id));
				HashSet<string> replacedOldSkillIds = new HashSet<string>();

			foreach (Character existing in merged.Characters ?? Enumerable.Empty<Character>())
			{
				if (existing == null || string.IsNullOrWhiteSpace(existing.Id))
				{
					continue;
				}

					if (FindMatchingImportedCharacter(existing, importedCharacters) != null && existing.SkillLinks != null)
					{
						foreach (CharacterSkillLink link in existing.SkillLinks)
						{
							if (!string.IsNullOrWhiteSpace(link.SkillId))
							{
								replacedOldSkillIds.Add(link.SkillId);
							}
						}
					}
				}

				List<Character> characters = new List<Character>();
				HashSet<string> usedImportedIds = new HashSet<string>();
			foreach (Character existing in merged.Characters ?? Enumerable.Empty<Character>())
			{
				if (existing == null || string.IsNullOrWhiteSpace(existing.Id))
				{
					continue;
				}

					Character imported = FindMatchingImportedCharacter(existing, importedCharacters);
					if (imported != null)
					{
						string importedId = NormalizeKey(imported.Id);
						if (!usedImportedIds.Contains(importedId))
						{
							characters.Add(imported);
							usedImportedIds.Add(importedId);
						}
					}
					else
					{
						characters.Add(existing);
					}
				}

				characters.AddRange(importedCharacters.Where(character => !usedImportedIds.Contains(NormalizeKey(character.Id))));
				merged.Characters = characters;
				merged.Skills = (merged.Skills ?? new List<Skill>())
					.Where(skill => skill != null && !replacedOldSkillIds.Contains(skill.Id) && !importedSkillIds.Contains(skill.Id))
					.Concat(plan.Skills)
					.ToList();

				SaveCharacters(repositoryRoot, plan.Characters);
				SaveSkills(repositoryRoot, plan.Skills);
				SaveManifest(repositoryRoot, merged);

				ExcelCharacterImportResult result = new ExcelCharacterImportResult
				{
					CharacterCount = plan.Characters.Count,
					SkillCount = plan.Skills.Count,
					OverwrittenCharacterCount = plan.OverwrittenCharacterNames.Count,
					NewCharacterCount = plan.NewCharacterNames.Count
				};
				return OperationResult<ExcelCharacterImportResult>.Ok(result);
			}
			catch (Exception ex)
			{
				return OperationResult<ExcelCharacterImportResult>.Fail("Failed to import Excel character data.", ex);
			}
		}

		private void SaveCharacters(string repositoryRoot, IEnumerable<Character> characters)
		{
			foreach (Character character in characters)
			{
				string path = Path.Combine(repositoryRoot, "characters", NormalizeFileName(character.Id) + ".json");
				OperationResult saveResult = jsonFileStore.Save(path, character, true);
				if (!saveResult.Success)
				{
					throw saveResult.Exception ?? new InvalidOperationException(saveResult.Message);
				}
			}
		}

		private void SaveSkills(string repositoryRoot, IEnumerable<Skill> skills)
		{
			foreach (Skill skill in skills)
			{
				string path = Path.Combine(repositoryRoot, "skills", NormalizeFileName(skill.Id) + ".json");
				OperationResult saveResult = jsonFileStore.Save(path, skill, true);
				if (!saveResult.Success)
				{
					throw saveResult.Exception ?? new InvalidOperationException(saveResult.Message);
				}
			}
		}

		private void SaveManifest(string repositoryRoot, StarPrismDataSet dataSet)
		{
			DataManifest manifest = dataSet.Manifest ?? new DataManifest();
			manifest.Characters = dataSet.Characters
				.Where(character => character != null && !string.IsNullOrWhiteSpace(character.Id))
				.GroupBy(character => NormalizeKey(character.Id))
				.Select(group => group.Last())
				.Select(character => new EntityIndexItem
				{
					Id = character.Id,
					DisplayName = string.IsNullOrWhiteSpace(character.DisplayName) ? character.Name : character.DisplayName,
					Path = "characters/" + NormalizeFileName(character.Id) + ".json"
				})
				.ToList();
			manifest.Skills = dataSet.Skills
				.Where(skill => skill != null && !string.IsNullOrWhiteSpace(skill.Id))
				.Select(skill => new EntityIndexItem
				{
					Id = skill.Id,
					DisplayName = skill.Name,
					Path = "skills/" + NormalizeFileName(skill.Id) + ".json"
				})
				.ToList();

			OperationResult saveResult = jsonFileStore.Save(Path.Combine(repositoryRoot, "manifest.json"), manifest, true);
			if (!saveResult.Success)
			{
				throw saveResult.Exception ?? new InvalidOperationException(saveResult.Message);
			}
		}

		private ImportedCharacter BuildImportedCharacter(
			string nickname,
			Dictionary<string, string> info,
			Dictionary<string, string> baseData,
			Dictionary<string, string> advanced,
			Dictionary<string, Character> currentById)
		{
			ProfileParts profileParts = ParseProfileInfo(GetValue(advanced, "txtInfo"));
			string displayName = CleanPlainText(GetValue(info, "txtName"));
			if (string.IsNullOrWhiteSpace(displayName))
			{
				displayName = profileParts.Name;
			}

			NameParts nameParts = ParseDisplayName(displayName, profileParts.Name);
			string characterName = !string.IsNullOrWhiteSpace(profileParts.Name) ? profileParts.Name : nameParts.Name;
			if (string.IsNullOrWhiteSpace(characterName))
			{
				return null;
			}

			string generatedId = "character_" + NormalizeIdentifier(nickname);
			Character existing = null;
			currentById.TryGetValue(NormalizeKey(generatedId), out existing);
			string characterId = existing == null ? generatedId : existing.Id;
			Character character = new Character
			{
				Id = characterId,
				Name = characterName,
				Title = nameParts.Title,
				DisplayName = string.IsNullOrWhiteSpace(nameParts.Title) ? characterName : nameParts.Title + " " + characterName,
				Profile = new CharacterProfile
				{
					Sex = profileParts.Sex,
					Age = profileParts.Age,
					Story = profileParts.Story,
					Quote = CleanQuote(GetValue(info, "txtInfo"))
				},
				Assets = existing != null && existing.Assets != null ? existing.Assets : new CharacterAssets(),
				SkillLinks = new List<CharacterSkillLink>(),
				Metadata = existing != null && existing.Metadata != null ? existing.Metadata : new EntityMetadata()
			};

			string portraitPath = CleanPlainText(GetValue(advanced, "imgHead"));
			if (!string.IsNullOrWhiteSpace(portraitPath))
			{
				character.Assets.PortraitPath = portraitPath;
			}

			AddTag(character.Metadata, "excel:" + nickname);
			string now = DateTime.Now.ToString("s");
			character.Metadata.UpdatedAt = now;
			if (string.IsNullOrWhiteSpace(character.Metadata.CreatedAt))
			{
				character.Metadata.CreatedAt = now;
			}

			List<Skill> skills = new List<Skill>();
			for (int i = 1; i <= 4; i++)
			{
				AddSkillFromCell(character, skills, nickname, "base", i, GetValue(baseData, "txtSkl" + i), GetValue(baseData, "zone12image" + (i == 1 ? string.Empty : " " + (i - 1))));
			}

			AddSkillFromCell(character, skills, nickname, "advanced", 5, GetValue(advanced, "txtSkl5"), GetValue(advanced, "zone40image"));
			AddSkillFromCell(character, skills, nickname, "advanced", 6, GetValue(advanced, "txtSkl6"), GetValue(advanced, "zone40image 1"));
			return new ImportedCharacter
			{
				Character = character,
				Skills = skills,
				IsOverwrite = existing != null
			};
		}

		private static void AddSkillFromCell(Character character, List<Skill> skills, string nickname, string tier, int order, string rawText, string effectImage)
		{
			ParsedSkillText parsed = ParseSkillText(rawText);
			if (string.IsNullOrWhiteSpace(parsed.Name) && string.IsNullOrWhiteSpace(parsed.Description))
			{
				return;
			}

			string skillId = "skill_" + NormalizeIdentifier(nickname) + "_" + order.ToString("00");
			Skill skill = new Skill
			{
				Id = skillId,
				Name = parsed.Name,
				Type = tier,
				Trigger = string.Empty,
				Description = parsed.Description,
				Costs = parsed.Costs,
				Targeting = new SkillTargeting(),
				Effects = new List<SkillEffect>(),
				Options = new List<SkillOption>(),
				Metadata = new EntityMetadata
				{
					Version = 1,
					CreatedAt = DateTime.Now.ToString("s"),
					UpdatedAt = DateTime.Now.ToString("s"),
					Tags = new List<string> { "excel", tier, "slot:" + order }
				}
			};

			if (!string.IsNullOrWhiteSpace(effectImage))
			{
				skill.Metadata.Tags.Add("effectImage:" + CleanPlainText(effectImage));
			}

			skills.Add(skill);
			character.SkillLinks.Add(new CharacterSkillLink
			{
				SkillId = skill.Id,
				Order = order,
				OverrideName = string.Empty,
				OverrideDescription = string.Empty
			});
		}

		private static ParsedSkillText ParseSkillText(string rawText)
		{
			string text = ConvertIconTokens(NormalizeMultiline(rawText)).Replace("**", string.Empty).Trim();
			text = Regex.Replace(text, "\\s+", " ");
			ParsedSkillText parsed = new ParsedSkillText
			{
				Costs = new List<SkillCost>()
			};

			if (string.IsNullOrWhiteSpace(text))
			{
				return parsed;
			}

			int split = text.IndexOf('：');
			if (split < 0)
			{
				split = text.IndexOf(':');
			}

			if (split >= 0)
			{
				parsed.Name = text.Substring(0, split).Trim();
				parsed.Description = text.Substring(split + 1).Trim();
			}
			else
			{
				parsed.Name = text;
				parsed.Description = string.Empty;
			}

			Match costMatch = Regex.Match(parsed.Description, "使用\\s*([ADMST R\\?/\\+]+)");
			if (costMatch.Success)
			{
				foreach (Match cardMatch in Regex.Matches(costMatch.Groups[1].Value, "[ADMSTR\\?]"))
				{
					string card = cardMatch.Value;
					SkillCost existing = parsed.Costs.FirstOrDefault(cost => cost.Card == card);
					if (existing == null)
					{
						parsed.Costs.Add(new SkillCost { Card = card, Count = 1 });
					}
					else
					{
						existing.Count++;
					}
				}
			}

			return parsed;
		}

		private static string ConvertIconTokens(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return string.Empty;
			}

			string text = value;
			text = Regex.Replace(text, "\\{[^}]*ATK_Icon\\.png\\}", "A", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*DEF_Icon\\.png\\}", "D", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*MOB_Icon\\.png\\}", "M", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*SEN_Icon\\.png\\}", "S", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*REC_Icon\\.png\\}", "R", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*TAC_Icon\\.png\\}", "T", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "\\{[^}]*ACT_Icon\\.png\\}", "?", RegexOptions.IgnoreCase);
			return Regex.Replace(text, "\\{[^}]*\\}", string.Empty);
		}

		private static ProfileParts ParseProfileInfo(string value)
		{
			string text = NormalizeProfileSeparators(NormalizeMultiline(value).Replace("**", string.Empty)).Trim();
			ProfileParts parts = new ProfileParts();
			if (string.IsNullOrWhiteSpace(text))
			{
				return parts;
			}

			int firstSeparator = text.IndexOf('|');
			int secondSeparator = firstSeparator < 0 ? -1 : text.IndexOf('|', firstSeparator + 1);
			if (firstSeparator >= 0 && secondSeparator > firstSeparator)
			{
				parts.Name = CleanPlainText(text.Substring(0, firstSeparator));
				parts.Sex = CleanPlainText(text.Substring(firstSeparator + 1, secondSeparator - firstSeparator - 1));

				string ageAndStory = text.Substring(secondSeparator + 1).Trim();
				Match ageMatch = Regex.Match(ageAndStory, "^(\\S+)\\s*(.*)$");
				if (ageMatch.Success)
				{
					parts.Age = ParseAge(CleanPlainText(ageMatch.Groups[1].Value));
					parts.Story = CleanPlainText(ageMatch.Groups[2].Value);
				}
				else
				{
					parts.Story = CleanPlainText(ageAndStory);
				}

				return parts;
			}

			parts.Story = CleanPlainText(text);
			return parts;
		}

		private static string NormalizeProfileSeparators(string value)
		{
			return string.IsNullOrWhiteSpace(value)
				? string.Empty
				: value.Replace('\uFF5C', '|').Replace('\u2223', '|');
		}

		private static int? ParseAge(string value)
		{
			Match match = Regex.Match(value ?? string.Empty, "\\d+");
			if (!match.Success)
			{
				return null;
			}

			int age;
			return int.TryParse(match.Value, out age) ? (int?)age : null;
		}

		private static NameParts ParseDisplayName(string displayName, string fallbackName)
		{
			displayName = CleanPlainText(displayName);
			fallbackName = CleanPlainText(fallbackName);
			if (string.IsNullOrWhiteSpace(displayName))
			{
				return new NameParts { Name = fallbackName, Title = string.Empty };
			}

			if (!string.IsNullOrWhiteSpace(fallbackName) && displayName.EndsWith(fallbackName, StringComparison.Ordinal))
			{
				return new NameParts
				{
					Name = fallbackName,
					Title = displayName.Substring(0, displayName.Length - fallbackName.Length).Trim()
				};
			}

			string[] parts = displayName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length >= 2)
			{
				return new NameParts
				{
					Title = string.Join(" ", parts.Take(parts.Length - 1).ToArray()),
					Name = parts[parts.Length - 1]
				};
			}

			return new NameParts { Name = displayName, Title = string.Empty };
		}

		private static string CleanQuote(string value)
		{
			string text = CleanPlainText(value);
			return text.Trim().Trim('“', '”', '"', '\'');
		}

		private static string CleanPlainText(string value)
		{
			string text = NormalizeMultiline(value).Replace("**", string.Empty).Trim();
			return Regex.Replace(text, "\\s+", " ").Trim();
		}

		private static string NormalizeMultiline(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return string.Empty;
			}

			string text = value.Replace("_x000D_", string.Empty).Replace("\r", "\n");
			string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(line => line.Trim())
				.Where(line => line.Length > 0 && line != "/")
				.ToArray();
			return string.Join(" ", lines);
		}

		private WorkbookData ReadWorkbook(string excelFilePath)
		{
			using (ZipArchive archive = ZipFile.OpenRead(excelFilePath))
			{
				List<string> sharedStrings = ReadSharedStrings(archive);
				XmlDocument workbookXml = LoadXml(archive, "xl/workbook.xml");
				XmlDocument relationshipsXml = LoadXml(archive, "xl/_rels/workbook.xml.rels");
				Dictionary<string, string> relationshipTargets = ReadRelationships(relationshipsXml);
				XmlNamespaceManager ns = CreateNamespaceManager(workbookXml);
				WorkbookData workbook = new WorkbookData();

				foreach (XmlNode sheetNode in workbookXml.SelectNodes("//m:sheet", ns))
				{
					string name = sheetNode.Attributes["name"].Value;
					string relationshipId = sheetNode.Attributes["r:id"].Value;
					string target = relationshipTargets[relationshipId];
					if (!target.StartsWith("xl/", StringComparison.OrdinalIgnoreCase))
					{
						target = "xl/" + target;
					}

					workbook.Sheets[name] = ReadSheet(archive, target, sharedStrings);
				}

				return workbook;
			}
		}

		private static List<Dictionary<string, string>> ReadSheet(ZipArchive archive, string entryName, List<string> sharedStrings)
		{
			XmlDocument sheetXml = LoadXml(archive, entryName);
			XmlNamespaceManager ns = CreateNamespaceManager(sheetXml);
			List<Dictionary<int, string>> rawRows = new List<Dictionary<int, string>>();
			foreach (XmlNode rowNode in sheetXml.SelectNodes("//m:sheetData/m:row", ns))
			{
				Dictionary<int, string> row = new Dictionary<int, string>();
				foreach (XmlNode cellNode in rowNode.SelectNodes("m:c", ns))
				{
					string reference = cellNode.Attributes["r"].Value;
					int column = GetColumnIndex(reference);
					XmlNode valueNode = cellNode.SelectSingleNode("m:v", ns);
					string value = valueNode == null ? string.Empty : valueNode.InnerText;
					XmlAttribute typeAttribute = cellNode.Attributes["t"];
					if (typeAttribute != null && typeAttribute.Value == "s" && !string.IsNullOrWhiteSpace(value))
					{
						value = sharedStrings[int.Parse(value)];
					}

					row[column] = value;
				}

				rawRows.Add(row);
			}

			if (rawRows.Count == 0)
			{
				return new List<Dictionary<string, string>>();
			}

			Dictionary<int, string> headers = rawRows[0];
			List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
			foreach (Dictionary<int, string> rawRow in rawRows.Skip(1))
			{
				Dictionary<string, string> row = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				foreach (KeyValuePair<int, string> header in headers)
				{
					if (string.IsNullOrWhiteSpace(header.Value))
					{
						continue;
					}

					string value;
					rawRow.TryGetValue(header.Key, out value);
					row[header.Value] = value ?? string.Empty;
				}

				rows.Add(row);
			}

			return rows;
		}

		private static Dictionary<string, Dictionary<string, string>> IndexRowsByNickname(List<Dictionary<string, string>> rows)
		{
			Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
			foreach (Dictionary<string, string> row in rows)
			{
				string nickname = GetValue(row, "Nickname");
				if (!string.IsNullOrWhiteSpace(nickname) && !result.ContainsKey(nickname))
				{
					result[nickname] = row;
				}
			}

			return result;
		}

		private static List<string> ReadSharedStrings(ZipArchive archive)
		{
			ZipArchiveEntry entry = archive.GetEntry("xl/sharedStrings.xml");
			if (entry == null)
			{
				return new List<string>();
			}

			XmlDocument xml = LoadXml(entry);
			XmlNamespaceManager ns = CreateNamespaceManager(xml);
			List<string> values = new List<string>();
			foreach (XmlNode itemNode in xml.SelectNodes("//m:si", ns))
			{
				values.Add(itemNode.InnerText);
			}

			return values;
		}

		private static Dictionary<string, string> ReadRelationships(XmlDocument relationshipsXml)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();
			foreach (XmlNode node in relationshipsXml.DocumentElement.ChildNodes)
			{
				XmlAttribute id = node.Attributes["Id"];
				XmlAttribute target = node.Attributes["Target"];
				if (id != null && target != null)
				{
					result[id.Value] = target.Value;
				}
			}

			return result;
		}

		private static XmlDocument LoadXml(ZipArchive archive, string entryName)
		{
			ZipArchiveEntry entry = archive.GetEntry(entryName);
			if (entry == null)
			{
				throw new FileNotFoundException("Excel entry not found: " + entryName);
			}

			return LoadXml(entry);
		}

		private static XmlDocument LoadXml(ZipArchiveEntry entry)
		{
			XmlDocument xml = new XmlDocument();
			using (Stream stream = entry.Open())
			{
				xml.Load(stream);
			}

			return xml;
		}

		private static XmlNamespaceManager CreateNamespaceManager(XmlDocument xml)
		{
			XmlNamespaceManager ns = new XmlNamespaceManager(xml.NameTable);
			ns.AddNamespace("m", MainNamespace);
			ns.AddNamespace("r", RelationshipNamespace);
			return ns;
		}

		private static int GetColumnIndex(string cellReference)
		{
			Match match = Regex.Match(cellReference ?? string.Empty, "^[A-Z]+");
			int result = 0;
			foreach (char ch in match.Value)
			{
				result = result * 26 + (ch - 'A' + 1);
			}

			return result;
		}

		private static string GetValue(Dictionary<string, string> row, string key)
		{
			if (row == null || !row.ContainsKey(key))
			{
				return string.Empty;
			}

			return row[key] ?? string.Empty;
		}

		private static Character FindMatchingImportedCharacter(Character existing, IEnumerable<Character> importedCharacters)
		{
			if (existing == null || string.IsNullOrWhiteSpace(existing.Id))
			{
				return null;
			}

			string existingId = NormalizeKey(existing.Id);
			return importedCharacters.FirstOrDefault(imported =>
				imported != null &&
				!string.IsNullOrWhiteSpace(imported.Id) &&
				NormalizeKey(imported.Id) == existingId);
		}

		private static void AddTag(EntityMetadata metadata, string tag)
		{
			if (metadata == null || string.IsNullOrWhiteSpace(tag))
			{
				return;
			}

			if (metadata.Tags == null)
			{
				metadata.Tags = new List<string>();
			}

			if (!metadata.Tags.Contains(tag))
			{
				metadata.Tags.Add(tag);
			}
		}

		private static string NormalizeKey(string value)
		{
			return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim().ToLowerInvariant();
		}

		private static string NormalizeIdentifier(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return "unknown";
			}

			string text = value.Trim().ToLowerInvariant();
			StringBuilder builder = new StringBuilder();
			foreach (char ch in text)
			{
				if ((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'))
				{
					builder.Append(ch);
				}
				else
				{
					builder.Append('_');
				}
			}

			return Regex.Replace(builder.ToString(), "_+", "_").Trim('_');
		}

		private static string NormalizeFileName(string value)
		{
			foreach (char invalidChar in Path.GetInvalidFileNameChars())
			{
				value = value.Replace(invalidChar, '_');
			}

			return value;
		}

		private class WorkbookData
		{
			public WorkbookData()
			{
				Sheets = new Dictionary<string, List<Dictionary<string, string>>>(StringComparer.OrdinalIgnoreCase);
			}

			public Dictionary<string, List<Dictionary<string, string>>> Sheets { get; private set; }
		}

		private class ImportedCharacter
		{
			public Character Character { get; set; }

			public List<Skill> Skills { get; set; }

			public bool IsOverwrite { get; set; }
		}

		private class ProfileParts
		{
			public string Name { get; set; }

			public string Sex { get; set; }

			public int? Age { get; set; }

			public string Story { get; set; }
		}

		private class NameParts
		{
			public string Name { get; set; }

			public string Title { get; set; }
		}

		private class ParsedSkillText
		{
			public string Name { get; set; }

			public string Description { get; set; }

			public List<SkillCost> Costs { get; set; }
		}
	}
}
