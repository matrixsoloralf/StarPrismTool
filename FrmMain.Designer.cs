namespace StarPrismTools
{
	partial class frmMain
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.stpStatus = new System.Windows.Forms.StatusStrip();
			this.lblVer = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblVerNo = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tpCharacter = new System.Windows.Forms.TabPage();
			this.tpSkill = new System.Windows.Forms.TabPage();
			this.tpRule = new System.Windows.Forms.TabPage();
			this.tpConcept = new System.Windows.Forms.TabPage();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnLoad = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnSaveNew = new System.Windows.Forms.ToolStripButton();
			this.btnExport = new System.Windows.Forms.ToolStripButton();
			this.btnExit = new System.Windows.Forms.ToolStripButton();
			this.characterCard = new StarPrismTools.Components.CharacterCard();
			this.skillList = new StarPrismTools.Components.SkillList();
			this.stpStatus.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tpCharacter.SuspendLayout();
			this.tpSkill.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// stpStatus
			// 
			this.stpStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVer,
            this.lblVerNo});
			this.stpStatus.Location = new System.Drawing.Point(0, 419);
			this.stpStatus.Name = "stpStatus";
			this.stpStatus.Size = new System.Drawing.Size(584, 22);
			this.stpStatus.TabIndex = 1;
			this.stpStatus.Text = "statusStrip1";
			// 
			// lblVer
			// 
			this.lblVer.Name = "lblVer";
			this.lblVer.Size = new System.Drawing.Size(55, 17);
			this.lblVer.Text = "Version:";
			// 
			// lblVerNo
			// 
			this.lblVerNo.ForeColor = System.Drawing.Color.Red;
			this.lblVerNo.Name = "lblVerNo";
			this.lblVerNo.Size = new System.Drawing.Size(62, 17);
			this.lblVerNo.Text = "Unknown";
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tpCharacter);
			this.tabMain.Controls.Add(this.tpSkill);
			this.tabMain.Controls.Add(this.tpRule);
			this.tabMain.Controls.Add(this.tpConcept);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.ImageList = this.imageList;
			this.tabMain.Location = new System.Drawing.Point(0, 25);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(584, 394);
			this.tabMain.TabIndex = 2;
			// 
			// tpCharacter
			// 
			this.tpCharacter.Controls.Add(this.characterCard);
			this.tpCharacter.ImageIndex = 0;
			this.tpCharacter.Location = new System.Drawing.Point(4, 23);
			this.tpCharacter.Name = "tpCharacter";
			this.tpCharacter.Padding = new System.Windows.Forms.Padding(3);
			this.tpCharacter.Size = new System.Drawing.Size(576, 367);
			this.tpCharacter.TabIndex = 0;
			this.tpCharacter.Text = "Character";
			this.tpCharacter.UseVisualStyleBackColor = true;
			// 
			// tpSkill
			// 
			this.tpSkill.Controls.Add(this.skillList);
			this.tpSkill.ImageIndex = 1;
			this.tpSkill.Location = new System.Drawing.Point(4, 23);
			this.tpSkill.Name = "tpSkill";
			this.tpSkill.Padding = new System.Windows.Forms.Padding(3);
			this.tpSkill.Size = new System.Drawing.Size(576, 367);
			this.tpSkill.TabIndex = 1;
			this.tpSkill.Text = "Skill";
			this.tpSkill.UseVisualStyleBackColor = true;
			// 
			// tpRule
			// 
			this.tpRule.ImageIndex = 3;
			this.tpRule.Location = new System.Drawing.Point(4, 23);
			this.tpRule.Name = "tpRule";
			this.tpRule.Padding = new System.Windows.Forms.Padding(3);
			this.tpRule.Size = new System.Drawing.Size(576, 367);
			this.tpRule.TabIndex = 2;
			this.tpRule.Text = "Rule";
			this.tpRule.UseVisualStyleBackColor = true;
			// 
			// tpConcept
			// 
			this.tpConcept.ImageIndex = 2;
			this.tpConcept.Location = new System.Drawing.Point(4, 23);
			this.tpConcept.Name = "tpConcept";
			this.tpConcept.Padding = new System.Windows.Forms.Padding(3);
			this.tpConcept.Size = new System.Drawing.Size(576, 367);
			this.tpConcept.TabIndex = 3;
			this.tpConcept.Text = "Concept";
			this.tpConcept.UseVisualStyleBackColor = true;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave,
            this.btnSaveNew,
            this.toolStripSeparator1,
            this.btnExport,
            this.toolStripSeparator3,
            this.btnExit});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(584, 25);
			this.toolStrip2.TabIndex = 3;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "character.png");
			this.imageList.Images.SetKeyName(1, "skill.png");
			this.imageList.Images.SetKeyName(2, "concept.png");
			this.imageList.Images.SetKeyName(3, "rule.png");
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnLoad
			// 
			this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
			this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(57, 22);
			this.btnLoad.Text = "Load";
			// 
			// btnSave
			// 
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(55, 22);
			this.btnSave.Text = "Save";
			// 
			// btnSaveNew
			// 
			this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
			this.btnSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveNew.Name = "btnSaveNew";
			this.btnSaveNew.Size = new System.Drawing.Size(85, 22);
			this.btnSaveNew.Text = "Save New";
			// 
			// btnExport
			// 
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(66, 22);
			this.btnExport.Text = "Export";
			// 
			// btnExit
			// 
			this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
			this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(48, 22);
			this.btnExit.Text = "Exit";
			// 
			// characterCard
			// 
			this.characterCard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.characterCard.Location = new System.Drawing.Point(3, 3);
			this.characterCard.Name = "characterCard";
			this.characterCard.Size = new System.Drawing.Size(570, 361);
			this.characterCard.TabIndex = 1;
			// 
			// skillList
			// 
			this.skillList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skillList.Location = new System.Drawing.Point(3, 3);
			this.skillList.Name = "skillList";
			this.skillList.Size = new System.Drawing.Size(570, 361);
			this.skillList.TabIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.stpStatus);
			this.Controls.Add(this.toolStrip2);
			this.Name = "frmMain";
			this.Text = "StarPrism DMS";
			this.stpStatus.ResumeLayout(false);
			this.stpStatus.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tpCharacter.ResumeLayout(false);
			this.tpSkill.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.StatusStrip stpStatus;
		private System.Windows.Forms.ToolStripStatusLabel lblVer;
		private System.Windows.Forms.ToolStripStatusLabel lblVerNo;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tpCharacter;
		private System.Windows.Forms.TabPage tpSkill;
		private System.Windows.Forms.TabPage tpRule;
		private System.Windows.Forms.TabPage tpConcept;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton btnLoad;
		private System.Windows.Forms.ToolStripButton btnSave;
		private System.Windows.Forms.ToolStripButton btnSaveNew;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnExit;
		private Components.CharacterCard characterCard;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton btnExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private Components.SkillList skillList;
	}
}

