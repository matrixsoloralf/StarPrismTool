using System.IO;
using StarPrismTools.Data.Json;
using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Repositories
{
	public abstract class JsonRepositoryBase<T> where T : class
	{
		private readonly IJsonFileStore jsonFileStore;

		protected JsonRepositoryBase(IJsonFileStore jsonFileStore, string repositoryRoot)
		{
			this.jsonFileStore = jsonFileStore;
			RepositoryRoot = repositoryRoot;
		}

		protected string RepositoryRoot { get; private set; }

		protected abstract string RelativeFilePath { get; }

		protected string FilePath
		{
			get { return Path.Combine(RepositoryRoot, RelativeFilePath); }
		}

		public OperationResult<T> Load()
		{
			return jsonFileStore.Load<T>(FilePath);
		}

		public OperationResult Save(T value)
		{
			return jsonFileStore.Save(FilePath, value, true);
		}
	}
}
