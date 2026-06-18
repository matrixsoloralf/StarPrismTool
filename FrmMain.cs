using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarPrismTools.Data;
using StarPrismTools.Data.Git;
using StarPrismTools.Data.Json;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools
{
	public partial class frmMain : Form
	{
		private readonly AppConfigurationService configurationService;
		private readonly StarPrismDataService dataService;
		private readonly IGitService gitService;
		private AppConfiguration configuration;
		private StarPrismDataSet dataSet;

		public frmMain()
		{
			InitializeComponent();
			JsonFileStore jsonFileStore = new JsonFileStore();
			configurationService = new AppConfigurationService(jsonFileStore);
			dataService = new StarPrismDataService(jsonFileStore);
			gitService = new GitService();
			Load += FrmMain_Load;
			btnLoad.Click += BtnLoad_Click;
			btnSave.Click += BtnSave_Click;
			btnExit.Click += BtnExit_Click;
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			lblVerNo.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			LoadConfiguration();
			LoadDataSet();
			RefreshStatus();
		}

		private void BtnLoad_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
			{
				dialog.Description = "Select StarPrism JSON data repository";
				dialog.SelectedPath = configuration.RepositoryPath;

				if (dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}

				configuration.RepositoryPath = dialog.SelectedPath;
				OperationResult saveResult = configurationService.Save(configuration);
				if (!saveResult.Success)
				{
					ShowError(saveResult);
					return;
				}

				RefreshStatus();
				LoadDataSet();
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			OperationResult saveResult = configurationService.Save(configuration);
			if (!saveResult.Success)
			{
				ShowError(saveResult);
				return;
			}

			RefreshStatus();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LoadConfiguration()
		{
			OperationResult<AppConfiguration> loadResult = configurationService.Load();
			if (loadResult.Success)
			{
				configuration = loadResult.Value;
				return;
			}

			configuration = AppConfiguration.CreateDefault();
			ShowError(loadResult);
		}

		private void RefreshStatus()
		{
			if (configuration == null)
			{
				return;
			}

			OperationResult<bool> repositoryResult = gitService.IsRepository(configuration.RepositoryPath);
			string repositoryState = repositoryResult.Success && repositoryResult.Value ? "Git repository" : "No git repository";
			Text = "StarPrism DMS - " + configuration.RepositoryPath + " (" + repositoryState + ")";
		}

		private void LoadDataSet()
		{
			OperationResult<StarPrismDataSet> loadResult = dataService.Load(configuration.RepositoryPath);
			if (!loadResult.Success)
			{
				dataSet = new StarPrismDataSet();
				characterCard.BindData(dataSet.Characters, dataSet.Skills, configuration.RepositoryPath);
				skillList.BindData(dataSet.Skills);
				return;
			}

			dataSet = loadResult.Value;
			characterCard.BindData(dataSet.Characters, dataSet.Skills, configuration.RepositoryPath);
			skillList.BindData(dataSet.Skills);
		}

		private void ShowError(OperationResult result)
		{
			MessageBox.Show(this, result.Message, "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
