using StarPrismTools.Data.Json;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Repositories
{
	public class ConceptRepository : JsonEntityRepositoryBase<Concept>
	{
		public ConceptRepository(IJsonFileStore jsonFileStore, string repositoryRoot)
			: base(jsonFileStore, repositoryRoot)
		{
		}

		protected override string EntityFolder
		{
			get { return "concepts"; }
		}

		protected override string GetEntityId(Concept entity)
		{
			return entity.Id;
		}
	}
}
