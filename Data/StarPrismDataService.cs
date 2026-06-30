using System.Collections.Generic;
using System.IO;
using StarPrismTools.Data.Json;
using StarPrismTools.Data.Repositories;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools.Data
{
	public class StarPrismDataService
	{
		private readonly IJsonFileStore jsonFileStore;

		public StarPrismDataService(IJsonFileStore jsonFileStore)
		{
			this.jsonFileStore = jsonFileStore;
		}

		public OperationResult<StarPrismDataSet> Load(string repositoryRoot)
		{
			if (string.IsNullOrWhiteSpace(repositoryRoot))
			{
				return OperationResult<StarPrismDataSet>.Fail("Data repository path is required.");
			}

			if (!Directory.Exists(repositoryRoot))
			{
				return OperationResult<StarPrismDataSet>.Fail("Data repository does not exist: " + repositoryRoot);
			}

			DataManifestRepository manifestRepository = new DataManifestRepository(jsonFileStore, repositoryRoot);
			OperationResult<DataManifest> manifestResult = manifestRepository.Load();
			if (!manifestResult.Success)
			{
				return OperationResult<StarPrismDataSet>.Fail(manifestResult.Message, manifestResult.Exception);
			}

			StarPrismDataSet dataSet = new StarPrismDataSet
			{
				Manifest = manifestResult.Value,
				Characters = new List<Character>(),
				Skills = new List<Skill>(),
				Concepts = new List<Concept>()
			};

			HashSet<string> loadedCharacterIds = new HashSet<string>();
			HashSet<string> loadedCharacterPaths = new HashSet<string>();
			foreach (EntityIndexItem item in dataSet.Manifest.Characters)
			{
				string characterIdKey = (item.Id ?? string.Empty).Trim().ToLowerInvariant();
				string characterPathKey = (item.Path ?? string.Empty).Trim().Replace('\\', '/').ToLowerInvariant();
				if (loadedCharacterIds.Contains(characterIdKey) || loadedCharacterPaths.Contains(characterPathKey))
				{
					continue;
				}

				OperationResult<Character> characterResult = jsonFileStore.Load<Character>(Path.Combine(repositoryRoot, item.Path));
				if (!characterResult.Success)
				{
					return OperationResult<StarPrismDataSet>.Fail(characterResult.Message, characterResult.Exception);
				}

				dataSet.Characters.Add(characterResult.Value);
				if (!string.IsNullOrWhiteSpace(characterIdKey))
				{
					loadedCharacterIds.Add(characterIdKey);
				}

				if (!string.IsNullOrWhiteSpace(characterPathKey))
				{
					loadedCharacterPaths.Add(characterPathKey);
				}
			}

			foreach (EntityIndexItem item in dataSet.Manifest.Skills)
			{
				OperationResult<Skill> skillResult = jsonFileStore.Load<Skill>(Path.Combine(repositoryRoot, item.Path));
				if (!skillResult.Success)
				{
					return OperationResult<StarPrismDataSet>.Fail(skillResult.Message, skillResult.Exception);
				}

				dataSet.Skills.Add(skillResult.Value);
			}

			if (dataSet.Manifest.Concepts != null && dataSet.Manifest.Concepts.Count > 0)
			{
				foreach (EntityIndexItem item in dataSet.Manifest.Concepts)
				{
					OperationResult<Concept> conceptResult = jsonFileStore.Load<Concept>(Path.Combine(repositoryRoot, item.Path));
					if (!conceptResult.Success)
					{
						return OperationResult<StarPrismDataSet>.Fail(conceptResult.Message, conceptResult.Exception);
					}

					dataSet.Concepts.Add(conceptResult.Value);
				}
			}
			else
			{
				ConceptRepository conceptRepository = new ConceptRepository(jsonFileStore, repositoryRoot);
				OperationResult<List<Concept>> conceptsResult = conceptRepository.LoadAll();
				if (!conceptsResult.Success)
				{
					return OperationResult<StarPrismDataSet>.Fail(conceptsResult.Message, conceptsResult.Exception);
				}

				dataSet.Concepts = conceptsResult.Value;
			}

			return OperationResult<StarPrismDataSet>.Ok(dataSet);
		}
	}
}
