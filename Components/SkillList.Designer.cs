namespace StarPrismTools.Components
{
	partial class SkillList
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillList));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnRemove = new System.Windows.Forms.ToolStripButton();
			this.btnEdit = new System.Windows.Forms.ToolStripButton();
			this.btnUp = new System.Windows.Forms.ToolStripButton();
			this.btnDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnShowRange = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblSkillCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblSkillCountNo = new System.Windows.Forms.ToolStripStatusLabel();
			this.dgvSkill = new System.Windows.Forms.DataGridView();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkill)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRemove,
            this.btnEdit,
            this.btnUp,
            this.btnDown,
            this.toolStripSeparator2,
            this.btnShowRange});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(552, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnAdd
			// 
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(52, 22);
			this.btnAdd.Text = "Add";
			// 
			// btnRemove
			// 
			this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
			this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 22);
			this.btnRemove.Text = "Remove";
			// 
			// btnEdit
			// 
			this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
			this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(50, 22);
			this.btnEdit.Text = "Edit";
			// 
			// btnUp
			// 
			this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
			this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(45, 22);
			this.btnUp.Text = "Up";
			// 
			// btnDown
			// 
			this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
			this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(61, 22);
			this.btnDown.Text = "Down";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnShowRange
			// 
			this.btnShowRange.Image = ((System.Drawing.Image)(resources.GetObject("btnShowRange.Image")));
			this.btnShowRange.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowRange.Name = "btnShowRange";
			this.btnShowRange.Size = new System.Drawing.Size(65, 22);
			this.btnShowRange.Text = "Range";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSkillCount,
            this.lblSkillCountNo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 389);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(552, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblSkillCount
			// 
			this.lblSkillCount.Name = "lblSkillCount";
			this.lblSkillCount.Size = new System.Drawing.Size(45, 17);
			this.lblSkillCount.Text = "Count:";
			// 
			// lblSkillCountNo
			// 
			this.lblSkillCountNo.ForeColor = System.Drawing.Color.Blue;
			this.lblSkillCountNo.Name = "lblSkillCountNo";
			this.lblSkillCountNo.Size = new System.Drawing.Size(15, 17);
			this.lblSkillCountNo.Text = "0";
			// 
			// dgvSkill
			// 
			this.dgvSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSkill.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSkill.Location = new System.Drawing.Point(0, 25);
			this.dgvSkill.Name = "dgvSkill";
			this.dgvSkill.Size = new System.Drawing.Size(552, 364);
			this.dgvSkill.TabIndex = 3;
			// 
			// SkillList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgvSkill);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "SkillList";
			this.Size = new System.Drawing.Size(552, 411);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkill)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnRemove;
		private System.Windows.Forms.ToolStripButton btnEdit;
		private System.Windows.Forms.ToolStripButton btnUp;
		private System.Windows.Forms.ToolStripButton btnDown;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnShowRange;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblSkillCount;
		private System.Windows.Forms.ToolStripStatusLabel lblSkillCountNo;
		private System.Windows.Forms.DataGridView dgvSkill;
	}
}
