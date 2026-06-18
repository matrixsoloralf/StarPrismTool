using System.IO;
using StarPrismTools.Data.Json;

namespace StarPrismTools.Infrastructure
{
	public class AppConfigurationService
	{
		private readonly IJsonFileStore jsonFileStore;
		private readonly string configurationFilePath;

		public AppConfigurationService(IJsonFileStore jsonFileStore)
			: this(jsonFileStore, AppPaths.ConfigurationFilePath)
		{
		}

		public AppConfigurationService(IJsonFileStore jsonFileStore, string configurationFilePath)
		{
			this.jsonFileStore = jsonFileStore;
			this.configurationFilePath = configurationFilePath;
		}

		public OperationResult<AppConfiguration> Load()
		{
			if (!File.Exists(configurationFilePath))
			{
				AppConfiguration defaultConfiguration = AppConfiguration.CreateDefault();
				OperationResult saveResult = Save(defaultConfiguration);
				if (!saveResult.Success)
				{
					return OperationResult<AppConfiguration>.Fail(saveResult.Message, saveResult.Exception);
				}

				return OperationResult<AppConfiguration>.Ok(defaultConfiguration);
			}

			return jsonFileStore.Load<AppConfiguration>(configurationFilePath);
		}

		public OperationResult Save(AppConfiguration configuration)
		{
			return jsonFileStore.Save(configurationFilePath, configuration, true);
		}
	}
}
