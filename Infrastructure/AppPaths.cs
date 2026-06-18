using System;
using System.IO;
using System.Windows.Forms;

namespace StarPrismTools.Infrastructure
{
	public static class AppPaths
	{
		public static string UserDataDirectory
		{
			get { return Application.UserAppDataPath; }
		}

		public static string ConfigurationFilePath
		{
			get { return Path.Combine(UserDataDirectory, "appsettings.json"); }
		}

		public static string DefaultRepositoryDirectory
		{
			get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "StarPrismData"); }
		}
	}
}
