using System.Runtime.Serialization;

namespace StarPrismTools.Infrastructure
{
	[DataContract]
	public class AppConfiguration
	{
		[DataMember(Order = 1)]
		public string RepositoryPath { get; set; }

		[DataMember(Order = 2)]
		public string RemoteUrl { get; set; }

		[DataMember(Order = 3)]
		public string BranchName { get; set; }

		[DataMember(Order = 4)]
		public string CommitAuthorName { get; set; }

		[DataMember(Order = 5)]
		public string CommitAuthorEmail { get; set; }

		public static AppConfiguration CreateDefault()
		{
			return new AppConfiguration
			{
				RepositoryPath = AppPaths.DefaultRepositoryDirectory,
				RemoteUrl = string.Empty,
				BranchName = "main",
				CommitAuthorName = string.Empty,
				CommitAuthorEmail = string.Empty
			};
		}
	}
}
