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

namespace StarPrismTools.Components
{
	public partial class SkillList : UserControl
	{
		public SkillList()
		{
			InitializeComponent();
			InitializeGrid();
		}

		public void BindData(IEnumerable<Skill> skills)
		{
			dgvSkill.Rows.Clear();
			foreach (Skill skill in skills ?? Enumerable.Empty<Skill>())
			{
				dgvSkill.Rows.Add(skill.Id, skill.Name, skill.Type, skill.Trigger, skill.Description);
			}

			lblSkillCountNo.Text = dgvSkill.Rows.Count.ToString();
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
