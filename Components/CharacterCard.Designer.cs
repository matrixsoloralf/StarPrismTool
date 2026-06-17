namespace StarPrismTools.Components
{
	partial class CharacterCard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCard));
			this.stpTool = new System.Windows.Forms.ToolStrip();
			this.lblChara = new System.Windows.Forms.ToolStripLabel();
			this.cboCharacter = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlChara = new System.Windows.Forms.SplitContainer();
			this.pnlInfo = new System.Windows.Forms.SplitContainer();
			this.tabProfile = new System.Windows.Forms.TabControl();
			this.tpProfile = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblStory = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblQuote = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblSex = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.tabSkill = new System.Windows.Forms.TabControl();
			this.tpSkill = new System.Windows.Forms.TabPage();
			this.dgvSkil = new System.Windows.Forms.DataGridView();
			this.tabIllustration = new System.Windows.Forms.TabControl();
			this.tpIllustration = new System.Windows.Forms.TabPage();
			this.dgvColSkillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvColSkillDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnPortraitEdit = new System.Windows.Forms.Button();
			this.picPortrait = new System.Windows.Forms.PictureBox();
			this.btnIllustrationEdit = new System.Windows.Forms.Button();
			this.picIllustration = new System.Windows.Forms.PictureBox();
			this.btnInfoEdit = new System.Windows.Forms.ToolStripButton();
			this.btnSkillLinking = new System.Windows.Forms.ToolStripButton();
			this.stpTool.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlChara)).BeginInit();
			this.pnlChara.Panel1.SuspendLayout();
			this.pnlChara.Panel2.SuspendLayout();
			this.pnlChara.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).BeginInit();
			this.pnlInfo.Panel1.SuspendLayout();
			this.pnlInfo.Panel2.SuspendLayout();
			this.pnlInfo.SuspendLayout();
			this.tabProfile.SuspendLayout();
			this.tpProfile.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabSkill.SuspendLayout();
			this.tpSkill.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSkil)).BeginInit();
			this.tabIllustration.SuspendLayout();
			this.tpIllustration.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPortrait)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picIllustration)).BeginInit();
			this.SuspendLayout();
			// 
			// stpTool
			// 
			this.stpTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblChara,
            this.cboCharacter,
            this.toolStripSeparator1,
            this.btnInfoEdit,
            this.btnSkillLinking});
			this.stpTool.Location = new System.Drawing.Point(0, 0);
			this.stpTool.Name = "stpTool";
			this.stpTool.Size = new System.Drawing.Size(600, 25);
			this.stpTool.TabIndex = 0;
			this.stpTool.Text = "toolStrip1";
			// 
			// lblChara
			// 
			this.lblChara.Name = "lblChara";
			this.lblChara.Size = new System.Drawing.Size(64, 22);
			this.lblChara.Text = "Character";
			// 
			// cboCharacter
			// 
			this.cboCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.cboCharacter.Name = "cboCharacter";
			this.cboCharacter.Size = new System.Drawing.Size(121, 25);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// pnlChara
			// 
			this.pnlChara.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlChara.Location = new System.Drawing.Point(0, 25);
			this.pnlChara.Name = "pnlChara";
			// 
			// pnlChara.Panel1
			// 
			this.pnlChara.Panel1.Controls.Add(this.pnlInfo);
			// 
			// pnlChara.Panel2
			// 
			this.pnlChara.Panel2.Controls.Add(this.tabIllustration);
			this.pnlChara.Size = new System.Drawing.Size(600, 335);
			this.pnlChara.SplitterDistance = 362;
			this.pnlChara.TabIndex = 1;
			// 
			// pnlInfo
			// 
			this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlInfo.Location = new System.Drawing.Point(0, 0);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlInfo.Panel1
			// 
			this.pnlInfo.Panel1.Controls.Add(this.tabProfile);
			// 
			// pnlInfo.Panel2
			// 
			this.pnlInfo.Panel2.Controls.Add(this.tabSkill);
			this.pnlInfo.Size = new System.Drawing.Size(362, 335);
			this.pnlInfo.SplitterDistance = 139;
			this.pnlInfo.TabIndex = 0;
			// 
			// tabProfile
			// 
			this.tabProfile.Controls.Add(this.tpProfile);
			this.tabProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabProfile.Location = new System.Drawing.Point(0, 0);
			this.tabProfile.Name = "tabProfile";
			this.tabProfile.SelectedIndex = 0;
			this.tabProfile.Size = new System.Drawing.Size(362, 139);
			this.tabProfile.TabIndex = 3;
			// 
			// tpProfile
			// 
			this.tpProfile.Controls.Add(this.tableLayoutPanel1);
			this.tpProfile.Location = new System.Drawing.Point(4, 22);
			this.tpProfile.Name = "tpProfile";
			this.tpProfile.Padding = new System.Windows.Forms.Padding(3);
			this.tpProfile.Size = new System.Drawing.Size(354, 113);
			this.tpProfile.TabIndex = 0;
			this.tpProfile.Text = "Profile";
			this.tpProfile.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.25287F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.74712F));
			this.tableLayoutPanel1.Controls.Add(this.btnPortraitEdit, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblStory, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.picPortrait, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.89571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.10429F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 107);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// lblStory
			// 
			this.lblStory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblStory.Location = new System.Drawing.Point(70, 63);
			this.lblStory.Name = "lblStory";
			this.lblStory.Size = new System.Drawing.Size(275, 44);
			this.lblStory.TabIndex = 4;
			this.lblStory.Text = "Story";
			this.lblStory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.lblQuote, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(67, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(281, 63);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// lblQuote
			// 
			this.lblQuote.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblQuote.Location = new System.Drawing.Point(3, 31);
			this.lblQuote.Name = "lblQuote";
			this.lblQuote.Size = new System.Drawing.Size(275, 32);
			this.lblQuote.TabIndex = 1;
			this.lblQuote.Text = "Quote";
			this.lblQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.Controls.Add(this.lblAge, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblSex, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblName, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblTitle, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(281, 31);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// lblAge
			// 
			this.lblAge.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblAge.Location = new System.Drawing.Point(227, 0);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(51, 31);
			this.lblAge.TabIndex = 3;
			this.lblAge.Text = "Age";
			this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSex
			// 
			this.lblSex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblSex.Location = new System.Drawing.Point(171, 0);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(50, 31);
			this.lblSex.TabIndex = 2;
			this.lblSex.Text = "Sex";
			this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblName
			// 
			this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblName.Location = new System.Drawing.Point(87, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(78, 31);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Location = new System.Drawing.Point(3, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(78, 31);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabSkill
			// 
			this.tabSkill.Controls.Add(this.tpSkill);
			this.tabSkill.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabSkill.Location = new System.Drawing.Point(0, 0);
			this.tabSkill.Name = "tabSkill";
			this.tabSkill.SelectedIndex = 0;
			this.tabSkill.Size = new System.Drawing.Size(362, 192);
			this.tabSkill.TabIndex = 1;
			// 
			// tpSkill
			// 
			this.tpSkill.Controls.Add(this.dgvSkil);
			this.tpSkill.Location = new System.Drawing.Point(4, 22);
			this.tpSkill.Name = "tpSkill";
			this.tpSkill.Padding = new System.Windows.Forms.Padding(3);
			this.tpSkill.Size = new System.Drawing.Size(354, 166);
			this.tpSkill.TabIndex = 0;
			this.tpSkill.Text = "Skill";
			this.tpSkill.UseVisualStyleBackColor = true;
			// 
			// dgvSkil
			// 
			this.dgvSkil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSkil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColSkillName,
            this.dgvColSkillDescription});
			this.dgvSkil.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSkil.Location = new System.Drawing.Point(3, 3);
			this.dgvSkil.Name = "dgvSkil";
			this.dgvSkil.Size = new System.Drawing.Size(348, 160);
			this.dgvSkil.TabIndex = 0;
			// 
			// tabIllustration
			// 
			this.tabIllustration.Controls.Add(this.tpIllustration);
			this.tabIllustration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabIllustration.Location = new System.Drawing.Point(0, 0);
			this.tabIllustration.Name = "tabIllustration";
			this.tabIllustration.SelectedIndex = 0;
			this.tabIllustration.Size = new System.Drawing.Size(234, 335);
			this.tabIllustration.TabIndex = 3;
			// 
			// tpIllustration
			// 
			this.tpIllustration.Controls.Add(this.btnIllustrationEdit);
			this.tpIllustration.Controls.Add(this.picIllustration);
			this.tpIllustration.Location = new System.Drawing.Point(4, 22);
			this.tpIllustration.Name = "tpIllustration";
			this.tpIllustration.Padding = new System.Windows.Forms.Padding(3);
			this.tpIllustration.Size = new System.Drawing.Size(226, 309);
			this.tpIllustration.TabIndex = 0;
			this.tpIllustration.Text = "Illustration";
			this.tpIllustration.UseVisualStyleBackColor = true;
			// 
			// dgvColSkillName
			// 
			this.dgvColSkillName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dgvColSkillName.FillWeight = 25F;
			this.dgvColSkillName.HeaderText = "Name";
			this.dgvColSkillName.Name = "dgvColSkillName";
			// 
			// dgvColSkillDescription
			// 
			this.dgvColSkillDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dgvColSkillDescription.FillWeight = 75F;
			this.dgvColSkillDescription.HeaderText = "Description";
			this.dgvColSkillDescription.Name = "dgvColSkillDescription";
			// 
			// btnPortraitEdit
			// 
			this.btnPortraitEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnPortraitEdit.BackgroundImage = global::StarPrismTools.Properties.Resources.be0abb14409e4427af114252e5b91dad;
			this.btnPortraitEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnPortraitEdit.Location = new System.Drawing.Point(17, 69);
			this.btnPortraitEdit.Name = "btnPortraitEdit";
			this.btnPortraitEdit.Size = new System.Drawing.Size(32, 32);
			this.btnPortraitEdit.TabIndex = 5;
			this.btnPortraitEdit.UseVisualStyleBackColor = true;
			// 
			// picPortrait
			// 
			this.picPortrait.BackColor = System.Drawing.SystemColors.ControlDark;
			this.picPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picPortrait.Location = new System.Drawing.Point(3, 3);
			this.picPortrait.Name = "picPortrait";
			this.picPortrait.Size = new System.Drawing.Size(61, 57);
			this.picPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPortrait.TabIndex = 1;
			this.picPortrait.TabStop = false;
			// 
			// btnIllustrationEdit
			// 
			this.btnIllustrationEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnIllustrationEdit.BackgroundImage = global::StarPrismTools.Properties.Resources.be0abb14409e4427af114252e5b91dad;
			this.btnIllustrationEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnIllustrationEdit.Location = new System.Drawing.Point(188, 6);
			this.btnIllustrationEdit.Name = "btnIllustrationEdit";
			this.btnIllustrationEdit.Size = new System.Drawing.Size(32, 32);
			this.btnIllustrationEdit.TabIndex = 3;
			this.btnIllustrationEdit.UseVisualStyleBackColor = true;
			// 
			// picIllustration
			// 
			this.picIllustration.BackColor = System.Drawing.SystemColors.ControlDark;
			this.picIllustration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picIllustration.Location = new System.Drawing.Point(3, 3);
			this.picIllustration.Name = "picIllustration";
			this.picIllustration.Size = new System.Drawing.Size(220, 303);
			this.picIllustration.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picIllustration.TabIndex = 1;
			this.picIllustration.TabStop = false;
			// 
			// btnInfoEdit
			// 
			this.btnInfoEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoEdit.Image")));
			this.btnInfoEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnInfoEdit.Name = "btnInfoEdit";
			this.btnInfoEdit.Size = new System.Drawing.Size(77, 22);
			this.btnInfoEdit.Text = "Info Edit";
			// 
			// btnSkillLinking
			// 
			this.btnSkillLinking.Image = ((System.Drawing.Image)(resources.GetObject("btnSkillLinking.Image")));
			this.btnSkillLinking.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSkillLinking.Name = "btnSkillLinking";
			this.btnSkillLinking.Size = new System.Drawing.Size(96, 22);
			this.btnSkillLinking.Text = "Skill Linking";
			// 
			// CharacterCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlChara);
			this.Controls.Add(this.stpTool);
			this.Name = "CharacterCard";
			this.Size = new System.Drawing.Size(600, 360);
			this.stpTool.ResumeLayout(false);
			this.stpTool.PerformLayout();
			this.pnlChara.Panel1.ResumeLayout(false);
			this.pnlChara.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlChara)).EndInit();
			this.pnlChara.ResumeLayout(false);
			this.pnlInfo.Panel1.ResumeLayout(false);
			this.pnlInfo.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlInfo)).EndInit();
			this.pnlInfo.ResumeLayout(false);
			this.tabProfile.ResumeLayout(false);
			this.tpProfile.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tabSkill.ResumeLayout(false);
			this.tpSkill.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSkil)).EndInit();
			this.tabIllustration.ResumeLayout(false);
			this.tpIllustration.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picPortrait)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picIllustration)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip stpTool;
		private System.Windows.Forms.ToolStripLabel lblChara;
		private System.Windows.Forms.ToolStripComboBox cboCharacter;
		private System.Windows.Forms.SplitContainer pnlChara;
		private System.Windows.Forms.SplitContainer pnlInfo;
		private System.Windows.Forms.TabControl tabSkill;
		private System.Windows.Forms.TabPage tpSkill;
		private System.Windows.Forms.TabControl tabIllustration;
		private System.Windows.Forms.TabPage tpIllustration;
		private System.Windows.Forms.DataGridView dgvSkil;
		private System.Windows.Forms.PictureBox picIllustration;
		private System.Windows.Forms.TabControl tabProfile;
		private System.Windows.Forms.TabPage tpProfile;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.PictureBox picPortrait;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnInfoEdit;
		private System.Windows.Forms.ToolStripButton btnSkillLinking;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblSex;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblQuote;
		private System.Windows.Forms.Label lblStory;
		private System.Windows.Forms.Button btnIllustrationEdit;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvColSkillName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvColSkillDescription;
		private System.Windows.Forms.Button btnPortraitEdit;
	}
}
