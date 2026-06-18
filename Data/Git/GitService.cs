using System;
using System.Diagnostics;
using System.IO;
using StarPrismTools.Infrastructure;

namespace StarPrismTools.Data.Git
{
	public class GitService : IGitService
	{
		public OperationResult<bool> IsRepository(string repositoryPath)
		{
			if (string.IsNullOrWhiteSpace(repositoryPath))
			{
				return OperationResult<bool>.Ok(false);
			}

			GitCommandResult result = Run(repositoryPath, "rev-parse --is-inside-work-tree");
			return OperationResult<bool>.Ok(result.Success && result.Output.Trim().Equals("true", StringComparison.OrdinalIgnoreCase));
		}

		public OperationResult<string> GetStatus(string repositoryPath)
		{
			GitCommandResult result = Run(repositoryPath, "status --short");
			if (!result.Success)
			{
				return OperationResult<string>.Fail("Failed to read git status.", new InvalidOperationException(result.Error));
			}

			return OperationResult<string>.Ok(result.Output);
		}

		public OperationResult Pull(string repositoryPath, string remoteName = "origin", string branchName = "main")
		{
			return ToOperationResult(Run(repositoryPath, "pull " + remoteName + " " + branchName), "Git pull failed.");
		}

		public OperationResult Push(string repositoryPath, string remoteName = "origin", string branchName = "main")
		{
			return ToOperationResult(Run(repositoryPath, "push " + remoteName + " " + branchName), "Git push failed.");
		}

		public OperationResult CommitAll(string repositoryPath, string message)
		{
			OperationResult addResult = ToOperationResult(Run(repositoryPath, "add ."), "Git add failed.");
			if (!addResult.Success)
			{
				return addResult;
			}

			return ToOperationResult(Run(repositoryPath, "commit -m \"" + EscapeArgument(message) + "\""), "Git commit failed.");
		}

		private static OperationResult ToOperationResult(GitCommandResult result, string failureMessage)
		{
			if (result.Success)
			{
				return OperationResult.Ok(result.Output);
			}

			return OperationResult.Fail(failureMessage + " " + result.Error, new InvalidOperationException(result.Error));
		}

		private static GitCommandResult Run(string repositoryPath, string arguments)
		{
			if (!Directory.Exists(repositoryPath))
			{
				return new GitCommandResult
				{
					ExitCode = -1,
					Output = string.Empty,
					Error = "Repository directory does not exist: " + repositoryPath
				};
			}

			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "git",
				Arguments = arguments,
				WorkingDirectory = repositoryPath,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};

			using (Process process = Process.Start(startInfo))
			{
				string output = process.StandardOutput.ReadToEnd();
				string error = process.StandardError.ReadToEnd();
				process.WaitForExit();

				return new GitCommandResult
				{
					ExitCode = process.ExitCode,
					Output = output,
					Error = error
				};
			}
		}

		private static string EscapeArgument(string value)
		{
			return (value ?? string.Empty).Replace("\"", "\\\"");
		}
	}
}
