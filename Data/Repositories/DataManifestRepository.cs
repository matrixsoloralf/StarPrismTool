using StarPrismTools.Data.Json;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Repositories
{
	public class DataManifestRepository : JsonRepositoryBase<DataManifest>
	{
		public DataManifestRepository(IJsonFileStore jsonFileStore, string repositoryRoot)
			: base(jsonFileStore, repositoryRoot)
		{
		}

		protected override string RelativeFilePath
		{
			get { return "manifest.json"; }
		}
	}
}
