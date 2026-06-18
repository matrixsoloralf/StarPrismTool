using System;
using System.Collections.Generic;
using System.IO;
using StarPrismTools.Data.Json;
using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Repositories
{
	public abstract class JsonEntityRepositoryBase<T> where T : class
	{
		private readonly IJsonFileStore jsonFileStore;

		protected JsonEntityRepositoryBase(IJsonFileStore jsonFileStore, string repositoryRoot)
		{
			this.jsonFileStore = jsonFileStore;
			RepositoryRoot = repositoryRoot;
		}

		protected string RepositoryRoot { get; private set; }

		protected abstract string EntityFolder { get; }

		protected abstract string GetEntityId(T entity);

		public OperationResult<T> Load(string id)
		{
			return jsonFileStore.Load<T>(GetFilePath(id));
		}

		public OperationResult Save(T entity)
		{
			string id = GetEntityId(entity);
			if (string.IsNullOrWhiteSpace(id))
			{
				return OperationResult.Fail("Entity id is required.");
			}

			return jsonFileStore.Save(GetFilePath(id), entity, true);
		}

		public OperationResult<List<T>> LoadAll()
		{
			List<T> items = new List<T>();
			string folder = GetFolderPath();

			if (!Directory.Exists(folder))
			{
				return OperationResult<List<T>>.Ok(items);
			}

			foreach (string filePath in Directory.GetFiles(folder, "*.json"))
			{
				OperationResult<T> loadResult = jsonFileStore.Load<T>(filePath);
				if (!loadResult.Success)
				{
					return OperationResult<List<T>>.Fail(loadResult.Message, loadResult.Exception);
				}

				items.Add(loadResult.Value);
			}

			return OperationResult<List<T>>.Ok(items);
		}

		protected string GetFilePath(string id)
		{
			return Path.Combine(GetFolderPath(), NormalizeFileName(id) + ".json");
		}

		protected string GetFolderPath()
		{
			return Path.Combine(RepositoryRoot, EntityFolder);
		}

		private static string NormalizeFileName(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Entity id is required.", "value");
			}

			foreach (char invalidChar in Path.GetInvalidFileNameChars())
			{
				value = value.Replace(invalidChar, '_');
			}

			return value;
		}
	}
}
