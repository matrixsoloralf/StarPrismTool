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
		}

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
	}
}
