using StarPrismTools.Data.Json;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Repositories
{
	public class CharacterRepository : JsonEntityRepositoryBase<Character>
	{
		public CharacterRepository(IJsonFileStore jsonFileStore, string repositoryRoot)
			: base(jsonFileStore, repositoryRoot)
		{
		}

		protected override string EntityFolder
		{
			get { return "characters"; }
		}

		protected override string GetEntityId(Character entity)
		{
			return entity.Id;
		}
	}
}
