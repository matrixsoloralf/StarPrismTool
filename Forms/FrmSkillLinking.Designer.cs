namespace StarPrismTools.Forms
{
	partial class FrmSkillLinking
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSkillLinking));
			this.stpTool = new System.Windows.Forms.ToolStrip();
			this.dgvSkill = new System.Windows.Forms.DataGridView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.ToolStripLabel();
			this.txtName = new System.Windows.Forms.ToolStripTextBox();
			this.lblType = new System.Windows.Forms.ToolStripLabel();
			this.cboType = new System.Windows.Forms.ToolStripComboBox();
			this.lblTrigger = new System.Windows.Forms.ToolStripLabel();
			this.cboTrigger = new System.Windows.Forms.ToolStripComboBox();
			this.btnDesc = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAsc = new System.Windows.Forms.ToolStripButton();
			this.btnSearch = new System.Windows.Forms.ToolStripButton();
			this.stpTool.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkill)).BeginInit();
			this.SuspendLayout();
			// 
			// stpTool
			// 
			this.stpTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblName,
            this.txtName,
            this.lblType,
            this.cboType,
            this.lblTrigger,
            this.cboTrigger,
            this.btnSearch,
            this.toolStripSeparator1,
            this.btnAsc,
            this.btnDesc});
			this.stpTool.Location = new System.Drawing.Point(0, 0);
			this.stpTool.Name = "stpTool";
			this.stpTool.Size = new System.Drawing.Size(584, 25);
			this.stpTool.TabIndex = 0;
			this.stpTool.Text = "toolStrip1";
			// 
			// dgvSkill
			// 
			this.dgvSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSkill.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgvSkill.Location = new System.Drawing.Point(0, 25);
			this.dgvSkill.Name = "dgvSkill";
			this.dgvSkill.Size = new System.Drawing.Size(584, 255);
			this.dgvSkill.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(497, 286);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(416, 286);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// lblName
			// 
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(43, 22);
			this.lblName.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(75, 25);
			// 
			// lblType
			// 
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(36, 22);
			this.lblType.Text = "Type";
			// 
			// cboType
			// 
			this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(75, 25);
			// 
			// lblTrigger
			// 
			this.lblTrigger.Name = "lblTrigger";
			this.lblTrigger.Size = new System.Drawing.Size(51, 22);
			this.lblTrigger.Text = "Trigger";
			// 
			// cboTrigger
			// 
			this.cboTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.cboTrigger.Name = "cboTrigger";
			this.cboTrigger.Size = new System.Drawing.Size(75, 25);
			// 
			// btnDesc
			// 
			this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
			this.btnDesc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDesc.Name = "btnDesc";
			this.btnDesc.Size = new System.Drawing.Size(56, 22);
			this.btnDesc.Text = "Desc";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAsc
			// 
			this.btnAsc.Image = ((System.Drawing.Image)(resources.GetObject("btnAsc.Image")));
			this.btnAsc.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAsc.Name = "btnAsc";
			this.btnAsc.Size = new System.Drawing.Size(48, 22);
			this.btnAsc.Text = "Asc";
			// 
			// btnSearch
			// 
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(67, 22);
			this.btnSearch.Text = "Search";
			// 
			// FrmSkillLinking
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(584, 321);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.dgvSkill);
			this.Controls.Add(this.stpTool);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSkillLinking";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skill Linking";
			this.stpTool.ResumeLayout(false);
			this.stpTool.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkill)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip stpTool;
		private System.Windows.Forms.DataGridView dgvSkill;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ToolStripLabel lblName;
		private System.Windows.Forms.ToolStripTextBox txtName;
		private System.Windows.Forms.ToolStripLabel lblType;
		private System.Windows.Forms.ToolStripComboBox cboType;
		private System.Windows.Forms.ToolStripLabel lblTrigger;
		private System.Windows.Forms.ToolStripComboBox cboTrigger;
		private System.Windows.Forms.ToolStripButton btnDesc;
		private System.Windows.Forms.ToolStripButton btnSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnAsc;
	}
}