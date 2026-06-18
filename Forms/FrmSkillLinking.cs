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
	public partial class FrmSkillLinking : Form
	{
		private List<Skill> skills;

		public FrmSkillLinking()
		{
			InitializeComponent();
			skills = new List<Skill>();
			InitializeGrid();
			btnSearch.Click += BtnSearch_Click;
		}

		public FrmSkillLinking(IEnumerable<Skill> skills)
			: this()
		{
			this.skills = (skills ?? Enumerable.Empty<Skill>()).ToList();
			BindSkills(this.skills);
		}

		private void BtnSearch_Click(object sender, EventArgs e)
		{
			string keyword = txtName.Text.Trim();
			IEnumerable<Skill> filtered = skills;
			if (!string.IsNullOrWhiteSpace(keyword))
			{
				filtered = filtered.Where(item => item.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			BindSkills(filtered);
		}

		private void BindSkills(IEnumerable<Skill> skills)
		{
			dgvSkill.Rows.Clear();
			foreach (Skill skill in skills)
			{
				dgvSkill.Rows.Add(skill.Id, skill.Name, skill.Type, skill.Trigger, skill.Description);
			}
		}

		private void InitializeGrid()
		{
			dgvSkill.AutoGenerateColumns = false;
			dgvSkill.AllowUserToAddRows = false;
			dgvSkill.ReadOnly = true;
			dgvSkill.MultiSelect = false;
			dgvSkill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvSkill.Columns.Clear();
			dgvSkill.Columns.Add("Id", "Id");
			dgvSkill.Columns.Add("Name", "Name");
			dgvSkill.Columns.Add("Type", "Type");
			dgvSkill.Columns.Add("Trigger", "Trigger");
			dgvSkill.Columns.Add("Description", "Description");
			dgvSkill.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
	}
}
