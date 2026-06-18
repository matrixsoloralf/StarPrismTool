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
				Skills = new List<Skill>()
			};

			foreach (EntityIndexItem item in dataSet.Manifest.Characters)
			{
				OperationResult<Character> characterResult = jsonFileStore.Load<Character>(Path.Combine(repositoryRoot, item.Path));
				if (!characterResult.Success)
				{
					return OperationResult<StarPrismDataSet>.Fail(characterResult.Message, characterResult.Exception);
				}

				dataSet.Characters.Add(characterResult.Value);
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

			return OperationResult<StarPrismDataSet>.Ok(dataSet);
		}
	}
}
