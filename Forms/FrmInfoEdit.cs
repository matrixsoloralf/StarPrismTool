using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarPrismTools.Models;

namespace StarPrismTools.Forms
{
	public partial class FrmInfoEdit : Form
	{
		public FrmInfoEdit()
		{
			InitializeComponent();
			EnsureSexOptions();
			ckbAgeUnknown.CheckedChanged += CkbAgeUnknown_CheckedChanged;
		}

		public FrmInfoEdit(Character character)
			: this()
		{
			BindCharacter(character);
		}

		private void BindCharacter(Character character)
		{
			if (character == null)
			{
				return;
			}

			txtTttle.Text = character.Title;
			txtName.Text = character.Name;
			txtQuote.Text = character.Profile == null ? string.Empty : character.Profile.Quote;
			txtStory.Text = character.Profile == null ? string.Empty : character.Profile.Story;

			if (character.Profile != null)
			{
				SelectSex(character.Profile.Sex);
				ckbAgeUnknown.Checked = !character.Profile.Age.HasValue;
				numericUpDown1.Enabled = character.Profile.Age.HasValue;
				if (character.Profile.Age.HasValue)
				{
					numericUpDown1.Value = character.Profile.Age.Value;
				}
			}
		}

		private void CkbAgeUnknown_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDown1.Enabled = !ckbAgeUnknown.Checked;
		}

		private void EnsureSexOptions()
		{
			AddSexOption("男");
			AddSexOption("女");
			AddSexOption("其他");
			AddSexOption("未知");
		}

		private void AddSexOption(string value)
		{
			if (!cboSex.Items.Contains(value))
			{
				cboSex.Items.Add(value);
			}
		}

		private void SelectSex(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return;
			}

			if (!cboSex.Items.Contains(value))
			{
				cboSex.Items.Add(value);
			}

			cboSex.SelectedItem = value;
		}
	}
}
