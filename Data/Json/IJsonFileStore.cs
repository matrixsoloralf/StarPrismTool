using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Json
{
	public interface IJsonFileStore
	{
		OperationResult<T> Load<T>(string filePath) where T : class;

		OperationResult Save<T>(string filePath, T value, bool createBackup = true) where T : class;
	}
}
