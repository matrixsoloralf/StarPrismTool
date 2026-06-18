using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using StarPrismTools.Models;

namespace StarPrismTools.Components
{
	public partial class ConceptCard : UserControl
	{
		private Color defaultBackColor;
		private Image conceptImage;

		public ConceptCard()
		{
			InitializeComponent();
			defaultBackColor = gbConcept.BackColor;
			btnDelete.Visible = false;
			lnkEdit.Visible = false;
			btnOK.Visible = false;
			btnCancel.Visible = false;
			btnAddImg.Visible = false;
			btnRemoveImg.Visible = false;
			lblImgIndex.Visible = false;
			txtConceptExplanation.Enabled = true;
			txtConceptExplanation.ReadOnly = true;
			txtConceptExplanation.BackColor = SystemColors.ControlLight;
			txtConceptExplanation.TabStop = false;
		}

		public string ConceptId { get; private set; }

		public void BindData(Concept concept, string repositoryRoot)
		{
			ConceptId = concept == null ? null : concept.Id;
			gbConcept.Text = concept == null ? "Concept" : concept.Name;
			txtConceptExplanation.Text = BuildExplanation(concept);
			LoadConceptImage(concept, repositoryRoot);
			AdjustHeight();
		}

		public void SetHighlighted(bool highlighted)
		{
			gbConcept.BackColor = highlighted ? Color.FromArgb(255, 248, 190) : defaultBackColor;
			txtConceptExplanation.BackColor = highlighted ? Color.FromArgb(255, 252, 220) : SystemColors.ControlLight;
		}

		private static string BuildExplanation(Concept concept)
		{
			if (concept == null)
			{
				return string.Empty;
			}

			List<string> lines = new List<string>();
			if (!string.IsNullOrWhiteSpace(concept.Summary))
			{
				lines.Add(concept.Summary);
			}

			if (!string.IsNullOrWhiteSpace(concept.Description) && concept.Description != concept.Summary)
			{
				if (lines.Count > 0)
				{
					lines.Add(string.Empty);
				}

				lines.Add(concept.Description);
			}

			if (concept.Aliases != null && concept.Aliases.Count > 0)
			{
				lines.Add(string.Empty);
				lines.Add("Aliases: " + string.Join(", ", concept.Aliases.ToArray()));
			}

			return string.Join(Environment.NewLine, lines.ToArray());
		}

		private void LoadConceptImage(Concept concept, string repositoryRoot)
		{
			if (conceptImage != null)
			{
				conceptImage.Dispose();
				conceptImage = null;
			}

			picEffectArea.Image = null;
			picEffectArea.Visible = false;
			lblImgIndex.Visible = false;

			if (concept == null || concept.Images == null || concept.Images.Count == 0)
			{
				return;
			}

			string imagePath = concept.Images[0].Path;
			if (string.IsNullOrWhiteSpace(imagePath))
			{
				return;
			}

			if (!Path.IsPathRooted(imagePath))
			{
				imagePath = Path.Combine(repositoryRoot ?? string.Empty, imagePath);
			}

			if (!File.Exists(imagePath))
			{
				return;
			}

			using (FileStream stream = File.OpenRead(imagePath))
			using (Image image = Image.FromStream(stream))
			{
				conceptImage = new Bitmap(image);
			}

			picEffectArea.SizeMode = PictureBoxSizeMode.Zoom;
			picEffectArea.Image = conceptImage;
			picEffectArea.Visible = true;
			lblImgIndex.Text = "1/" + concept.Images.Count;
			lblImgIndex.Visible = concept.Images.Count > 1;
		}

		private void AdjustHeight()
		{
			int width = txtConceptExplanation.Width > 0 ? txtConceptExplanation.Width : 380;
			Size preferredSize = TextRenderer.MeasureText(
				txtConceptExplanation.Text,
				txtConceptExplanation.Font,
				new Size(width, 0),
				TextFormatFlags.WordBreak);
			int targetHeight = Math.Max(128, preferredSize.Height + 62);
			Height = Math.Min(targetHeight, 260);
		}
	}
}
