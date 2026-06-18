namespace StarPrismTools.Data.Git
{
	public class GitCommandResult
	{
		public int ExitCode { get; set; }

		public string Output { get; set; }

		public string Error { get; set; }

		public bool Success
		{
			get { return ExitCode == 0; }
		}
	}
}
