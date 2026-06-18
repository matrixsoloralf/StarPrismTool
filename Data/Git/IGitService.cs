using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Git
{
	public interface IGitService
	{
		OperationResult<bool> IsRepository(string repositoryPath);

		OperationResult<string> GetStatus(string repositoryPath);

		OperationResult Pull(string repositoryPath, string remoteName = "origin", string branchName = "main");

		OperationResult Push(string repositoryPath, string remoteName = "origin", string branchName = "main");

		OperationResult CommitAll(string repositoryPath, string message);
	}
}
