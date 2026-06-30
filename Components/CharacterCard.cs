using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarPrismTools.Data.Json;
using StarPrismTools.Data.Repositories;
using StarPrismTools.Forms;
using StarPrismTools.Infrastructure;
using StarPrismTools.Models;

namespace StarPrismTools.Components
{
	public partial class CharacterCard : UserControl
	{
		private List<Character> characters;
		private List<Skill> skills;
		private string repositoryRoot;

		public CharacterCard()
		{
			InitializeComponent();
			characters = new List<Character>();
			skills = new List<Skill>();
			repositoryRoot = string.Empty;
			InitializeDisplaySettings();
			cboCharacter.SelectedIndexChanged += CboCharacter_SelectedIndexChanged;
			btnInfoEdit.Click += BtnInfoEdit_Click;
			btnSkillLinking.Click += BtnSkillLinking_Click;
			btnPortraitEdit.Click += BtnPortraitEdit_Click;
			btnIllustrationEdit.Click += BtnIllustrationEdit_Click;
			btnDelete.Click += BtnDelete_Click;
			btnViewCode.Click += BtnViewCode_Click;
		}

		public event EventHandler CharacterDataChanged;

		public void BindData(IEnumerable<Character> characters, IEnumerable<Skill> skills, string repositoryRoot)
		{
			this.characters = (characters ?? Enumerable.Empty<Character>()).ToList();
			this.skills = (skills ?? Enumerable.Empty<Skill>()).ToList();
			this.repositoryRoot = repositoryRoot ?? string.Empty;

			cboCharacter.ComboBox.DataSource = null;
			cboCharacter.ComboBox.DisplayMember = "DisplayName";
			cboCharacter.ComboBox.ValueMember = "Id";
			cboCharacter.ComboBox.DataSource = this.characters;

			if (this.characters.Count > 0)
			{
				cboCharacter.SelectedIndex = 0;
				ShowCharacter(this.characters[0]);
			}
			else
			{
				ShowCharacter(null);
			}
		}

		private void CboCharacter_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowCharacter(cboCharacter.SelectedItem as Character);
		}

		private void BtnInfoEdit_Click(object sender, EventArgs e)
		{
			Character character = cboCharacter.SelectedItem as Character;
			if (character == null)
			{
				return;
			}

			using (FrmInfoEdit form = new FrmInfoEdit(character))
			{
				form.ShowDialog(this);
			}
		}

		private void BtnSkillLinking_Click(object sender, EventArgs e)
		{
			using (FrmSkillLinking form = new FrmSkillLinking(skills))
			{
				form.ShowDialog(this);
			}
		}

		private void BtnPortraitEdit_Click(object sender, EventArgs e)
		{
			ImportCharacterImage("portrait");
		}

		private void BtnIllustrationEdit_Click(object sender, EventArgs e)
		{
			ImportCharacterImage("illustration");
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			Character character = cboCharacter.SelectedItem as Character;
			if (character == null)
			{
				return;
			}

			string displayName = string.IsNullOrWhiteSpace(character.DisplayName) ? character.Name : character.DisplayName;
			DialogResult confirm = MessageBox.Show(
				this,
				"Delete character \"" + displayName + "\"?\r\n\r\nThe character JSON and manifest entry will be removed. Linked skill JSON files will be kept.",
				"Delete Character",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);
			if (confirm != DialogResult.Yes)
			{
				return;
			}

			OperationResult deleteResult = DeleteCharacter(character);
			if (!deleteResult.Success)
			{
				MessageBox.Show(this, deleteResult.Message, "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			characters.RemoveAll(item => item.Id == character.Id);
			BindData(characters, skills, repositoryRoot);
			OnCharacterDataChanged();
		}

		private void BtnViewCode_Click(object sender, EventArgs e)
		{
			Character character = cboCharacter.SelectedItem as Character;
			if (character == null)
			{
				return;
			}

			using (FrmViewCode form = new FrmViewCode(character, SaveCharacterJsonFromCode))
			{
				form.ShowDialog(this);
				if (form.SavedCharacter != null)
				{
					ReplaceCharacter(form.SavedCharacter);
					OnCharacterDataChanged();
				}
			}
		}

		private void ShowCharacter(Character character)
		{
			if (character == null)
			{
				lblTitle.Text = "Title: ";
				lblName.Text = "Name: ";
				lblSex.Text = "Sex: ";
				lblAge.Text = "Age: ";
				lblQuote.Text = "Quote: \"\"";
				lblStory.Text = "Info: ";
				dgvSkil.Rows.Clear();
				SetPicture(picPortrait, null);
				SetPicture(picIllustration, null);
				return;
			}

			lblTitle.Text = "Title: " + character.Title;
			lblName.Text = "Name: " + character.Name;
			lblSex.Text = "Sex: " + (character.Profile == null ? string.Empty : character.Profile.Sex);
			lblAge.Text = "Age: " + (character.Profile == null || !character.Profile.Age.HasValue ? "Unknown" : character.Profile.Age.Value.ToString());
			lblQuote.Text = "Quote: \"" + (character.Profile == null ? string.Empty : character.Profile.Quote) + "\"";
			lblStory.Text = "Info: " + (character.Profile == null ? string.Empty : character.Profile.Story);
			LoadCharacterImages(character);

			dgvSkil.Rows.Clear();
			foreach (CharacterSkillLink link in character.SkillLinks.OrderBy(item => item.Order))
			{
				Skill skill = skills.FirstOrDefault(item => item.Id == link.SkillId);
				string name = !string.IsNullOrWhiteSpace(link.OverrideName) ? link.OverrideName : skill == null ? link.SkillId : skill.Name;
				string description = !string.IsNullOrWhiteSpace(link.OverrideDescription) ? link.OverrideDescription : skill == null ? string.Empty : skill.Description;
				dgvSkil.Rows.Add(name, description);
			}
		}

		private void InitializeDisplaySettings()
		{
			lblTitle.TextAlign = ContentAlignment.MiddleLeft;
			lblName.TextAlign = ContentAlignment.MiddleLeft;
			lblSex.TextAlign = ContentAlignment.MiddleLeft;
			lblAge.TextAlign = ContentAlignment.MiddleLeft;
			lblQuote.TextAlign = ContentAlignment.MiddleLeft;
			lblStory.TextAlign = ContentAlignment.MiddleLeft;

			dgvSkil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvSkil.MultiSelect = false;
			dgvSkil.AllowUserToAddRows = false;
			dgvSkil.ReadOnly = true;
		}

		private void ImportCharacterImage(string purpose)
		{
			Character character = cboCharacter.SelectedItem as Character;
			if (character == null || string.IsNullOrWhiteSpace(repositoryRoot))
			{
				return;
			}

			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Title = "Select " + purpose + " image";
				dialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff|BMP Files|*.bmp|JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*";
				dialog.Multiselect = false;

				if (dialog.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}

				string relativePath = CopyImageToAssets(character, dialog.FileName, purpose);
				if (character.Assets == null)
				{
					character.Assets = new CharacterAssets();
				}

				if (purpose == "portrait")
				{
					character.Assets.PortraitPath = relativePath;
				}
				else
				{
					character.Assets.IllustrationPath = relativePath;
				}

				CharacterRepository repository = new CharacterRepository(new JsonFileStore(), repositoryRoot);
				OperationResult saveResult = repository.Save(character);
				if (!saveResult.Success)
				{
					MessageBox.Show(this, saveResult.Message, "StarPrism Tools", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				ShowCharacter(character);
			}
		}

		private string CopyImageToAssets(Character character, string sourceFilePath, string purpose)
		{
			string characterName = string.IsNullOrWhiteSpace(character.Name) ? character.Id : character.Name;
			string safeCharacterName = NormalizePathSegment(characterName);
			string extension = Path.GetExtension(sourceFilePath).ToLowerInvariant();
			string assetsFolder = Path.Combine(repositoryRoot, "assets", "characters", safeCharacterName);
			Directory.CreateDirectory(assetsFolder);

			string fileName = safeCharacterName + "_" + purpose + extension;
			string targetFilePath = Path.Combine(assetsFolder, fileName);
			File.Copy(sourceFilePath, targetFilePath, true);

			return Path.Combine("assets", "characters", safeCharacterName, fileName).Replace('\\', '/');
		}

		private OperationResult<Character> SaveCharacterJsonFromCode(string json)
		{
			OperationResult<Character> parseResult = FrmViewCode.ParseCharacter(json);
			if (!parseResult.Success)
			{
				return parseResult;
			}

			if (string.IsNullOrWhiteSpace(repositoryRoot))
			{
				return OperationResult<Character>.Fail("Data repository path is required.");
			}

			Character character = parseResult.Value;
			OperationResult saveResult = SaveCharacterAndManifest(character);
			if (!saveResult.Success)
			{
				return OperationResult<Character>.Fail(saveResult.Message, saveResult.Exception);
			}

			return OperationResult<Character>.Ok(character);
		}

		private OperationResult SaveCharacterAndManifest(Character character)
		{
			try
			{
				CharacterRepository characterRepository = new CharacterRepository(new JsonFileStore(), repositoryRoot);
				OperationResult saveResult = characterRepository.Save(character);
				if (!saveResult.Success)
				{
					return saveResult;
				}

				DataManifestRepository manifestRepository = new DataManifestRepository(new JsonFileStore(), repositoryRoot);
				OperationResult<DataManifest> manifestResult = manifestRepository.Load();
				if (!manifestResult.Success)
				{
					return manifestResult;
				}

				DataManifest manifest = manifestResult.Value;
				EntityIndexItem item = manifest.Characters.FirstOrDefault(indexItem => indexItem.Id == character.Id);
				if (item == null)
				{
					item = new EntityIndexItem
					{
						Id = character.Id,
						Path = "characters/" + NormalizePathSegment(character.Id) + ".json"
					};
					manifest.Characters.Add(item);
				}

				item.DisplayName = string.IsNullOrWhiteSpace(character.DisplayName) ? character.Name : character.DisplayName;
				return manifestRepository.Save(manifest);
			}
			catch (Exception ex)
			{
				return OperationResult.Fail("Failed to save character JSON.", ex);
			}
		}

		private OperationResult DeleteCharacter(Character character)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(repositoryRoot))
				{
					return OperationResult.Fail("Data repository path is required.");
				}

				DataManifestRepository manifestRepository = new DataManifestRepository(new JsonFileStore(), repositoryRoot);
				OperationResult<DataManifest> manifestResult = manifestRepository.Load();
				if (!manifestResult.Success)
				{
					return manifestResult;
				}

				DataManifest manifest = manifestResult.Value;
				EntityIndexItem item = manifest.Characters.FirstOrDefault(indexItem => indexItem.Id == character.Id);
				string relativePath = item == null ? Path.Combine("characters", NormalizePathSegment(character.Id) + ".json") : item.Path;
				manifest.Characters.RemoveAll(indexItem => indexItem.Id == character.Id);
				OperationResult saveResult = manifestRepository.Save(manifest);
				if (!saveResult.Success)
				{
					return saveResult;
				}

				string fullPath = Path.Combine(repositoryRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));
				if (File.Exists(fullPath))
				{
					File.Delete(fullPath);
				}

				return OperationResult.Ok();
			}
			catch (Exception ex)
			{
				return OperationResult.Fail("Failed to delete character.", ex);
			}
		}

		private void ReplaceCharacter(Character character)
		{
			int index = characters.FindIndex(item => item.Id == character.Id);
			if (index >= 0)
			{
				characters[index] = character;
			}
			else
			{
				characters.Add(character);
			}

			BindData(characters, skills, repositoryRoot);
			cboCharacter.SelectedItem = characters.FirstOrDefault(item => item.Id == character.Id);
			ShowCharacter(character);
		}

		private void LoadCharacterImages(Character character)
		{
			if (character.Assets == null)
			{
				SetPicture(picPortrait, null);
				SetPicture(picIllustration, null);
				return;
			}

			SetPicture(picPortrait, ResolveAssetPath(character.Assets.PortraitPath));
			SetPicture(picIllustration, ResolveAssetPath(character.Assets.IllustrationPath));
		}

		private string ResolveAssetPath(string relativePath)
		{
			if (string.IsNullOrWhiteSpace(relativePath) || string.IsNullOrWhiteSpace(repositoryRoot))
			{
				return null;
			}

			return Path.Combine(repositoryRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));
		}

		private static void SetPicture(PictureBox pictureBox, string filePath)
		{
			Image oldImage = pictureBox.Image;
			pictureBox.Image = null;
			if (oldImage != null)
			{
				oldImage.Dispose();
			}

			if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
			{
				return;
			}

			using (Image image = Image.FromFile(filePath))
			{
				pictureBox.Image = new Bitmap(image);
			}
		}

		private static string NormalizePathSegment(string value)
		{
			foreach (char invalidChar in Path.GetInvalidFileNameChars())
			{
				value = value.Replace(invalidChar, '_');
			}

			return value.Trim();
		}

		private void OnCharacterDataChanged()
		{
			EventHandler handler = CharacterDataChanged;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}
