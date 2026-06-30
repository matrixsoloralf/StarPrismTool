using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarPrismTools.Components;
using StarPrismTools.Data;
using StarPrismTools.Data.Export;
using StarPrismTools.Data.Git;
using StarPrismTools.Data.Import;
using StarPrismTools.Data.Json;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools
{
	public partial class frmMain : Form
	{
		private readonly AppConfigurationService configurationService;
		private readonly StarPrismDataService dataService;
		private readonly ExcelCharacterImportService excelCharacterImportService;
		private readonly MarkdownCharacterExportService markdownCharacterExportService;
		private readonly IGitService gitService;
		private AppConfiguration configuration;
		private StarPrismDataSet dataSet;
		private readonly Dictionary<string, ConceptCard> conceptCardMap;
		private ConceptCard highlightedConceptCard;

		public frmMain()
		{
			InitializeComponent();
			JsonFileStore jsonFileStore = new JsonFileStore();
			configurationService = new AppConfigurationService(jsonFileStore);
			dataService = new StarPrismDataService(jsonFileStore);
			excelCharacterImportService = new ExcelCharacterImportService(jsonFileStore);
			markdownCharacterExportService = new MarkdownCharacterExportService();
			gitService = new GitService();
			conceptCardMap = new Dictionary<string, ConceptCard>();
			Load += FrmMain_Load;
			btnLoad.Click += BtnLoad_Click;
			btnImport.Click += BtnImport_Click;
			btnExport2MD.Click += BtnExport2MD_Click;
			btnSave.Click += BtnSave_Click;
			btnExit.Click += BtnExit_Click;
			characterCard.CharacterDataChanged += CharacterCard_CharacterDataChanged;
			btnExpandAll.Click += BtnExpandAll_Click;
			btnCollapseAll.Click += BtnCollapseAll_Click;
			btnConceptSearch.Click += BtnConceptSearch_Click;
			txtConceptSearchPattern.KeyDown += TxtConceptSearchPattern_KeyDown;
			tvwConcept.AfterSelect += TvwConcept_AfterSelect;
			lstConcept.SelectedIndexChanged += LstConcept_SelectedIndexChanged;
			pnlConceptContainer.Resize += PnlConceptContainer_Resize;
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

		private void BtnImport_Click(object sender, EventArgs e)
		{
			if (configuration == null || string.IsNullOrWhiteSpace(configuration.RepositoryPath))
			{
				MessageBox.Show(this, "Please select a JSON data repository first.", "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Title = "Import character Excel";
				dialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|All files (*.*)|*.*";
				dialog.Multiselect = false;

				if (dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}

				OperationResult<ExcelCharacterImportPlan> planResult = excelCharacterImportService.CreatePlan(dialog.FileName, dataSet);
				if (!planResult.Success)
				{
					ShowError(planResult);
					return;
				}

				ExcelCharacterImportPlan plan = planResult.Value;
				string prompt = string.Format(
					"Parsed {0} characters and {1} skills from Excel.{2}{2}New characters: {3}{2}Characters to overwrite by ID: {4}{2}{2}Overwrite current data for matching character IDs?",
					plan.Characters.Count,
					plan.Skills.Count,
					Environment.NewLine,
					plan.NewCharacterNames.Count,
					plan.OverwrittenCharacterNames.Count);
				DialogResult confirm = MessageBox.Show(this, prompt, "Import Character Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (confirm != DialogResult.Yes)
				{
					return;
				}

				OperationResult<ExcelCharacterImportResult> importResult = excelCharacterImportService.ApplyPlan(configuration.RepositoryPath, dataSet, plan);
				if (!importResult.Success)
				{
					ShowError(importResult);
					return;
				}

				LoadDataSet();
				MessageBox.Show(
					this,
					string.Format(
						"Import completed.{0}{0}Characters: {1}{0}Skills: {2}{0}Overwritten: {3}{0}New: {4}",
						Environment.NewLine,
						importResult.Value.CharacterCount,
						importResult.Value.SkillCount,
						importResult.Value.OverwrittenCharacterCount,
						importResult.Value.NewCharacterCount),
					"StarPrism Tools",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		private void BtnExport2MD_Click(object sender, EventArgs e)
		{
			if (dataSet == null || dataSet.Characters == null || dataSet.Characters.Count == 0)
			{
				MessageBox.Show(this, "No character data is loaded.", "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.Title = "Export character Markdown";
				dialog.Filter = "Markdown File (*.md)|*.md|All files (*.*)|*.*";
				dialog.FileName = "StarPrism_Character_Info.md";
				dialog.DefaultExt = "md";
				dialog.AddExtension = true;
				dialog.OverwritePrompt = true;

				if (configuration != null && Directory.Exists(configuration.RepositoryPath))
				{
					dialog.InitialDirectory = configuration.RepositoryPath;
				}

				if (dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}

				try
				{
					string markdown = markdownCharacterExportService.Export(dataSet.Characters, dataSet.Skills);
					File.WriteAllText(dialog.FileName, markdown, new UTF8Encoding(false));
					MessageBox.Show(this, "Markdown export completed.", "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					ShowError(OperationResult.Fail("Failed to export Markdown: " + ex.Message, ex));
				}
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

		private void CharacterCard_CharacterDataChanged(object sender, EventArgs e)
		{
			LoadDataSet();
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
				BindConcepts(dataSet.Concepts);
				return;
			}

			dataSet = loadResult.Value;
			characterCard.BindData(dataSet.Characters, dataSet.Skills, configuration.RepositoryPath);
			skillList.BindData(dataSet.Skills);
			BindConcepts(dataSet.Concepts);
		}

		private void BindConcepts(IEnumerable<Concept> concepts)
		{
			List<Concept> orderedConcepts = OrderConcepts(concepts).ToList();
			BuildConceptCards(orderedConcepts);
			BuildConceptTree(orderedConcepts);
			RefreshConceptSearchResults();
		}

		private void BuildConceptCards(IEnumerable<Concept> concepts)
		{
			pnlConceptContainer.SuspendLayout();
			pnlConceptContainer.Controls.Clear();
			pnlConceptContainer.WrapContents = false;
			conceptCardMap.Clear();
			highlightedConceptCard = null;

			foreach (Concept concept in concepts)
			{
				ConceptCard card = new ConceptCard();
				card.Margin = new Padding(4, 4, 12, 4);
				card.Width = GetConceptCardWidth();
				card.BindData(concept, configuration == null ? null : configuration.RepositoryPath);
				pnlConceptContainer.Controls.Add(card);

				if (!string.IsNullOrWhiteSpace(concept.Id))
				{
					conceptCardMap[concept.Id] = card;
				}
			}

			pnlConceptContainer.ResumeLayout();
		}

		private void BuildConceptTree(IEnumerable<Concept> concepts)
		{
			tvwConcept.BeginUpdate();
			tvwConcept.Nodes.Clear();

			foreach (IGrouping<string, Concept> group in concepts.GroupBy(GetConceptCategoryKey))
			{
				Concept firstConcept = group.FirstOrDefault();
				string categoryName = GetConceptCategoryName(firstConcept);
				TreeNode categoryNode = new TreeNode(categoryName);
				categoryNode.Tag = "category:" + group.Key;

				foreach (Concept concept in group)
				{
					TreeNode conceptNode = new TreeNode(concept.Name);
					conceptNode.Tag = "concept:" + concept.Id;
					categoryNode.Nodes.Add(conceptNode);
				}

				tvwConcept.Nodes.Add(categoryNode);
			}

			tvwConcept.EndUpdate();
			tvwConcept.ExpandAll();
		}

		private void RefreshConceptSearchResults()
		{
			string pattern = txtConceptSearchPattern.Text;
			List<Concept> matches = SearchConcepts(pattern).ToList();
			lstConcept.BeginUpdate();
			lstConcept.Items.Clear();

			foreach (Concept concept in matches)
			{
				lstConcept.Items.Add(new ConceptListItem(concept));
			}

			lstConcept.EndUpdate();
		}

		private IEnumerable<Concept> SearchConcepts(string pattern)
		{
			IEnumerable<Concept> concepts = OrderConcepts(dataSet == null ? null : dataSet.Concepts);
			if (string.IsNullOrWhiteSpace(pattern))
			{
				return concepts;
			}

			string normalizedPattern = NormalizeSearchText(pattern);
			return concepts
				.Select(concept => new { Concept = concept, Score = GetConceptSearchScore(concept, normalizedPattern) })
				.Where(result => result.Score > 0)
				.OrderByDescending(result => result.Score)
				.ThenBy(result => result.Concept.Order)
				.Select(result => result.Concept);
		}

		private static int GetConceptSearchScore(Concept concept, string normalizedPattern)
		{
			if (concept == null || string.IsNullOrEmpty(normalizedPattern))
			{
				return 0;
			}

			int score = 0;
			score = Math.Max(score, MatchScore(concept.Name, normalizedPattern, 100));
			if (concept.Aliases != null)
			{
				foreach (string alias in concept.Aliases)
				{
					score = Math.Max(score, MatchScore(alias, normalizedPattern, 90));
				}
			}

			score = Math.Max(score, MatchScore(concept.Summary, normalizedPattern, 70));
			score = Math.Max(score, MatchScore(concept.Description, normalizedPattern, 50));
			score = Math.Max(score, MatchScore(concept.CategoryName, normalizedPattern, 40));
			return score;
		}

		private static int MatchScore(string value, string normalizedPattern, int baseScore)
		{
			string normalizedValue = NormalizeSearchText(value);
			if (string.IsNullOrEmpty(normalizedValue))
			{
				return 0;
			}

			if (normalizedValue == normalizedPattern)
			{
				return baseScore + 20;
			}

			if (normalizedValue.Contains(normalizedPattern))
			{
				return baseScore;
			}

			return IsSubsequence(normalizedPattern, normalizedValue) ? baseScore / 2 : 0;
		}

		private static bool IsSubsequence(string pattern, string value)
		{
			int patternIndex = 0;
			for (int i = 0; i < value.Length && patternIndex < pattern.Length; i++)
			{
				if (value[i] == pattern[patternIndex])
				{
					patternIndex++;
				}
			}

			return patternIndex == pattern.Length;
		}

		private static string NormalizeSearchText(string value)
		{
			return string.IsNullOrWhiteSpace(value)
				? string.Empty
				: value.Trim().ToLowerInvariant().Replace(" ", string.Empty);
		}

		private IEnumerable<Concept> OrderConcepts(IEnumerable<Concept> concepts)
		{
			return (concepts ?? Enumerable.Empty<Concept>())
				.OrderBy(concept => string.IsNullOrWhiteSpace(concept.Category) ? "zzzz" : concept.Category)
				.ThenBy(concept => concept.Order)
				.ThenBy(concept => concept.Name);
		}

		private static string GetConceptCategoryKey(Concept concept)
		{
			return concept == null || string.IsNullOrWhiteSpace(concept.Category) ? "uncategorized" : concept.Category;
		}

		private static string GetConceptCategoryName(Concept concept)
		{
			if (concept != null && !string.IsNullOrWhiteSpace(concept.CategoryName))
			{
				return concept.CategoryName;
			}

			string category = GetConceptCategoryKey(concept);
			return category == "uncategorized" ? "Uncategorized" : category;
		}

		private void NavigateToConcept(string conceptId)
		{
			if (string.IsNullOrWhiteSpace(conceptId) || !conceptCardMap.ContainsKey(conceptId))
			{
				return;
			}

			ConceptCard card = conceptCardMap[conceptId];
			if (highlightedConceptCard != null && highlightedConceptCard != card)
			{
				highlightedConceptCard.SetHighlighted(false);
			}

			highlightedConceptCard = card;
			highlightedConceptCard.SetHighlighted(true);
			pnlConceptContainer.ScrollControlIntoView(card);
		}

		private void NavigateToCategory(string category)
		{
			Concept concept = OrderConcepts(dataSet == null ? null : dataSet.Concepts)
				.FirstOrDefault(item => GetConceptCategoryKey(item) == category);
			if (concept != null)
			{
				NavigateToConcept(concept.Id);
			}
		}

		private void ResizeConceptCards()
		{
			int width = GetConceptCardWidth();
			foreach (ConceptCard card in conceptCardMap.Values)
			{
				card.Width = width;
			}
		}

		private int GetConceptCardWidth()
		{
			return Math.Max(480, pnlConceptContainer.ClientSize.Width - 28);
		}

		private void BtnExpandAll_Click(object sender, EventArgs e)
		{
			tvwConcept.ExpandAll();
		}

		private void BtnCollapseAll_Click(object sender, EventArgs e)
		{
			tvwConcept.CollapseAll();
		}

		private void BtnConceptSearch_Click(object sender, EventArgs e)
		{
			RefreshConceptSearchResults();
		}

		private void TxtConceptSearchPattern_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
				RefreshConceptSearchResults();
			}
		}

		private void TvwConcept_AfterSelect(object sender, TreeViewEventArgs e)
		{
			string tag = e.Node == null ? null : e.Node.Tag as string;
			if (string.IsNullOrWhiteSpace(tag))
			{
				return;
			}

			if (tag.StartsWith("concept:", StringComparison.Ordinal))
			{
				NavigateToConcept(tag.Substring("concept:".Length));
			}
			else if (tag.StartsWith("category:", StringComparison.Ordinal))
			{
				NavigateToCategory(tag.Substring("category:".Length));
			}
		}

		private void LstConcept_SelectedIndexChanged(object sender, EventArgs e)
		{
			ConceptListItem item = lstConcept.SelectedItem as ConceptListItem;
			if (item != null && item.Concept != null)
			{
				NavigateToConcept(item.Concept.Id);
			}
		}

		private void PnlConceptContainer_Resize(object sender, EventArgs e)
		{
			ResizeConceptCards();
		}

		private void ShowError(OperationResult result)
		{
			MessageBox.Show(this, result.Message, "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private class ConceptListItem
		{
			public ConceptListItem(Concept concept)
			{
				Concept = concept;
			}

			public Concept Concept { get; private set; }

			public override string ToString()
			{
				if (Concept == null)
				{
					return string.Empty;
				}

				return string.IsNullOrWhiteSpace(Concept.CategoryName)
					? Concept.Name
					: Concept.Name + " [" + Concept.CategoryName + "]";
			}
		}
	}
}
