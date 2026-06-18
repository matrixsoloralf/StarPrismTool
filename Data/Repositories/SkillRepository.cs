using StarPrismTools.Data.Json;
using StarPrismTools.Models;

namespace StarPrismTools.Data.Repositories
{
	public class SkillRepository : JsonEntityRepositoryBase<Skill>
	{
		public SkillRepository(IJsonFileStore jsonFileStore, string repositoryRoot)
			: base(jsonFileStore, repositoryRoot)
		{
		}

		protected override string EntityFolder
		{
			get { return "skills"; }
		}

		protected override string GetEntityId(Skill entity)
		{
			return entity.Id;
		}
	}
}
