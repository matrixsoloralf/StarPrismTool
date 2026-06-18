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
			this.characterCard = new StarPrismTools.Components.CharacterCard();
			this.tpSkill = new System.Windows.Forms.TabPage();
			this.skillList = new StarPrismTools.Components.SkillList();
			this.tpRule = new System.Windows.Forms.TabPage();
			this.tpConcept = new System.Windows.Forms.TabPage();
			this.pnlConcept = new System.Windows.Forms.SplitContainer();
			this.tpResource = new System.Windows.Forms.TabPage();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btnLoad = new System.Windows.Forms.ToolStripButton();
			this.btnSave = new System.Windows.Forms.ToolStripButton();
			this.btnSaveNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExit = new System.Windows.Forms.ToolStripButton();
			this.tabConcept = new System.Windows.Forms.TabControl();
			this.tpTreeView = new System.Windows.Forms.TabPage();
			this.tpSearch = new System.Windows.Forms.TabPage();
			this.stpToolTree = new System.Windows.Forms.ToolStrip();
			this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
			this.btnCollapseAll = new System.Windows.Forms.ToolStripButton();
			this.tvwConcept = new System.Windows.Forms.TreeView();
			this.btnNewConcept = new System.Windows.Forms.ToolStripButton();
			this.stpToolConceptSearch = new System.Windows.Forms.ToolStrip();
			this.lblConceptSearchPattern = new System.Windows.Forms.ToolStripLabel();
			this.txtConceptSearchPattern = new System.Windows.Forms.ToolStripTextBox();
			this.btnConceptSearch = new System.Windows.Forms.ToolStripButton();
			this.lstConcept = new System.Windows.Forms.ListBox();
			this.tapConceptCardContainer = new System.Windows.Forms.TabControl();
			this.tpConceptCardContainer = new System.Windows.Forms.TabPage();
			this.pnlConceptContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.stpStatus.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tpCharacter.SuspendLayout();
			this.tpSkill.SuspendLayout();
			this.tpConcept.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlConcept)).BeginInit();
			this.pnlConcept.Panel1.SuspendLayout();
			this.pnlConcept.Panel2.SuspendLayout();
			this.pnlConcept.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.tabConcept.SuspendLayout();
			this.tpTreeView.SuspendLayout();
			this.tpSearch.SuspendLayout();
			this.stpToolTree.SuspendLayout();
			this.stpToolConceptSearch.SuspendLayout();
			this.tapConceptCardContainer.SuspendLayout();
			this.tpConceptCardContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// stpStatus
			// 
			this.stpStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVer,
            this.lblVerNo});
			this.stpStatus.Location = new System.Drawing.Point(0, 539);
			this.stpStatus.Name = "stpStatus";
			this.stpStatus.Size = new System.Drawing.Size(784, 22);
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
			this.tabMain.Controls.Add(this.tpResource);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.ImageList = this.imageList;
			this.tabMain.Location = new System.Drawing.Point(0, 25);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(784, 514);
			this.tabMain.TabIndex = 2;
			// 
			// tpCharacter
			// 
			this.tpCharacter.Controls.Add(this.characterCard);
			this.tpCharacter.ImageIndex = 0;
			this.tpCharacter.Location = new System.Drawing.Point(4, 23);
			this.tpCharacter.Name = "tpCharacter";
			this.tpCharacter.Padding = new System.Windows.Forms.Padding(3);
			this.tpCharacter.Size = new System.Drawing.Size(776, 487);
			this.tpCharacter.TabIndex = 0;
			this.tpCharacter.Text = "Character";
			this.tpCharacter.UseVisualStyleBackColor = true;
			// 
			// characterCard
			// 
			this.characterCard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.characterCard.Location = new System.Drawing.Point(3, 3);
			this.characterCard.Name = "characterCard";
			this.characterCard.Size = new System.Drawing.Size(770, 481);
			this.characterCard.TabIndex = 1;
			// 
			// tpSkill
			// 
			this.tpSkill.Controls.Add(this.skillList);
			this.tpSkill.ImageIndex = 1;
			this.tpSkill.Location = new System.Drawing.Point(4, 23);
			this.tpSkill.Name = "tpSkill";
			this.tpSkill.Padding = new System.Windows.Forms.Padding(3);
			this.tpSkill.Size = new System.Drawing.Size(776, 487);
			this.tpSkill.TabIndex = 1;
			this.tpSkill.Text = "Skill";
			this.tpSkill.UseVisualStyleBackColor = true;
			// 
			// skillList
			// 
			this.skillList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.skillList.Location = new System.Drawing.Point(3, 3);
			this.skillList.Name = "skillList";
			this.skillList.Size = new System.Drawing.Size(770, 481);
			this.skillList.TabIndex = 0;
			// 
			// tpRule
			// 
			this.tpRule.ImageIndex = 3;
			this.tpRule.Location = new System.Drawing.Point(4, 23);
			this.tpRule.Name = "tpRule";
			this.tpRule.Padding = new System.Windows.Forms.Padding(3);
			this.tpRule.Size = new System.Drawing.Size(776, 487);
			this.tpRule.TabIndex = 2;
			this.tpRule.Text = "Rule";
			this.tpRule.UseVisualStyleBackColor = true;
			// 
			// tpConcept
			// 
			this.tpConcept.Controls.Add(this.pnlConcept);
			this.tpConcept.ImageIndex = 2;
			this.tpConcept.Location = new System.Drawing.Point(4, 23);
			this.tpConcept.Name = "tpConcept";
			this.tpConcept.Padding = new System.Windows.Forms.Padding(3);
			this.tpConcept.Size = new System.Drawing.Size(776, 487);
			this.tpConcept.TabIndex = 3;
			this.tpConcept.Text = "Concept";
			this.tpConcept.UseVisualStyleBackColor = true;
			// 
			// pnlConcept
			// 
			this.pnlConcept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlConcept.Location = new System.Drawing.Point(3, 3);
			this.pnlConcept.Name = "pnlConcept";
			// 
			// pnlConcept.Panel1
			// 
			this.pnlConcept.Panel1.Controls.Add(this.tabConcept);
			// 
			// pnlConcept.Panel2
			// 
			this.pnlConcept.Panel2.Controls.Add(this.tapConceptCardContainer);
			this.pnlConcept.Size = new System.Drawing.Size(770, 481);
			this.pnlConcept.SplitterDistance = 256;
			this.pnlConcept.TabIndex = 0;
			// 
			// tpResource
			// 
			this.tpResource.Location = new System.Drawing.Point(4, 23);
			this.tpResource.Name = "tpResource";
			this.tpResource.Padding = new System.Windows.Forms.Padding(3);
			this.tpResource.Size = new System.Drawing.Size(776, 487);
			this.tpResource.TabIndex = 4;
			this.tpResource.Text = "Resource";
			this.tpResource.UseVisualStyleBackColor = true;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "character.png");
			this.imageList.Images.SetKeyName(1, "skill.png");
			this.imageList.Images.SetKeyName(2, "concept.png");
			this.imageList.Images.SetKeyName(3, "rule.png");
			this.imageList.Images.SetKeyName(4, "treeView.png");
			this.imageList.Images.SetKeyName(5, "search.png");
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
			this.toolStrip2.Size = new System.Drawing.Size(784, 25);
			this.toolStrip2.TabIndex = 3;
			this.toolStrip2.Text = "toolStrip2";
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnExport
			// 
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(66, 22);
			this.btnExport.Text = "Export";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnExit
			// 
			this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
			this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(48, 22);
			this.btnExit.Text = "Exit";
			// 
			// tabConcept
			// 
			this.tabConcept.Controls.Add(this.tpTreeView);
			this.tabConcept.Controls.Add(this.tpSearch);
			this.tabConcept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabConcept.ImageList = this.imageList;
			this.tabConcept.Location = new System.Drawing.Point(0, 0);
			this.tabConcept.Name = "tabConcept";
			this.tabConcept.SelectedIndex = 0;
			this.tabConcept.Size = new System.Drawing.Size(256, 481);
			this.tabConcept.TabIndex = 0;
			// 
			// tpTreeView
			// 
			this.tpTreeView.Controls.Add(this.tvwConcept);
			this.tpTreeView.Controls.Add(this.stpToolTree);
			this.tpTreeView.ImageIndex = 4;
			this.tpTreeView.Location = new System.Drawing.Point(4, 23);
			this.tpTreeView.Name = "tpTreeView";
			this.tpTreeView.Padding = new System.Windows.Forms.Padding(3);
			this.tpTreeView.Size = new System.Drawing.Size(248, 454);
			this.tpTreeView.TabIndex = 0;
			this.tpTreeView.Text = "Tree View";
			this.tpTreeView.UseVisualStyleBackColor = true;
			// 
			// tpSearch
			// 
			this.tpSearch.Controls.Add(this.lstConcept);
			this.tpSearch.Controls.Add(this.stpToolConceptSearch);
			this.tpSearch.ImageIndex = 5;
			this.tpSearch.Location = new System.Drawing.Point(4, 23);
			this.tpSearch.Name = "tpSearch";
			this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
			this.tpSearch.Size = new System.Drawing.Size(248, 454);
			this.tpSearch.TabIndex = 1;
			this.tpSearch.Text = "Search";
			this.tpSearch.UseVisualStyleBackColor = true;
			// 
			// stpToolTree
			// 
			this.stpToolTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExpandAll,
            this.btnCollapseAll,
            this.btnNewConcept});
			this.stpToolTree.Location = new System.Drawing.Point(3, 3);
			this.stpToolTree.Name = "stpToolTree";
			this.stpToolTree.Size = new System.Drawing.Size(242, 25);
			this.stpToolTree.TabIndex = 0;
			this.stpToolTree.Text = "toolStrip1";
			// 
			// btnExpandAll
			// 
			this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
			this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExpandAll.Name = "btnExpandAll";
			this.btnExpandAll.Size = new System.Drawing.Size(71, 22);
			this.btnExpandAll.Text = "Expand";
			// 
			// btnCollapseAll
			// 
			this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
			this.btnCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCollapseAll.Name = "btnCollapseAll";
			this.btnCollapseAll.Size = new System.Drawing.Size(78, 22);
			this.btnCollapseAll.Text = "Collapse";
			// 
			// tvwConcept
			// 
			this.tvwConcept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwConcept.Location = new System.Drawing.Point(3, 28);
			this.tvwConcept.Name = "tvwConcept";
			this.tvwConcept.Size = new System.Drawing.Size(242, 423);
			this.tvwConcept.TabIndex = 1;
			// 
			// btnNewConcept
			// 
			this.btnNewConcept.Image = ((System.Drawing.Image)(resources.GetObject("btnNewConcept.Image")));
			this.btnNewConcept.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNewConcept.Name = "btnNewConcept";
			this.btnNewConcept.Size = new System.Drawing.Size(54, 22);
			this.btnNewConcept.Text = "New";
			// 
			// stpToolConceptSearch
			// 
			this.stpToolConceptSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConceptSearchPattern,
            this.txtConceptSearchPattern,
            this.btnConceptSearch});
			this.stpToolConceptSearch.Location = new System.Drawing.Point(3, 3);
			this.stpToolConceptSearch.Name = "stpToolConceptSearch";
			this.stpToolConceptSearch.Size = new System.Drawing.Size(242, 25);
			this.stpToolConceptSearch.TabIndex = 0;
			this.stpToolConceptSearch.Text = "toolStrip1";
			// 
			// lblConceptSearchPattern
			// 
			this.lblConceptSearchPattern.Name = "lblConceptSearchPattern";
			this.lblConceptSearchPattern.Size = new System.Drawing.Size(49, 22);
			this.lblConceptSearchPattern.Text = "Pattern";
			// 
			// txtConceptSearchPattern
			// 
			this.txtConceptSearchPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtConceptSearchPattern.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
			this.txtConceptSearchPattern.Name = "txtConceptSearchPattern";
			this.txtConceptSearchPattern.Size = new System.Drawing.Size(128, 25);
			// 
			// btnConceptSearch
			// 
			this.btnConceptSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnConceptSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnConceptSearch.Image")));
			this.btnConceptSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnConceptSearch.Name = "btnConceptSearch";
			this.btnConceptSearch.Size = new System.Drawing.Size(23, 22);
			this.btnConceptSearch.Text = "toolStripButton1";
			// 
			// lstConcept
			// 
			this.lstConcept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstConcept.FormattingEnabled = true;
			this.lstConcept.Location = new System.Drawing.Point(3, 28);
			this.lstConcept.Name = "lstConcept";
			this.lstConcept.Size = new System.Drawing.Size(242, 423);
			this.lstConcept.TabIndex = 1;
			// 
			// tapConceptCardContainer
			// 
			this.tapConceptCardContainer.Controls.Add(this.tpConceptCardContainer);
			this.tapConceptCardContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tapConceptCardContainer.Location = new System.Drawing.Point(0, 0);
			this.tapConceptCardContainer.Name = "tapConceptCardContainer";
			this.tapConceptCardContainer.SelectedIndex = 0;
			this.tapConceptCardContainer.Size = new System.Drawing.Size(510, 481);
			this.tapConceptCardContainer.TabIndex = 0;
			// 
			// tpConceptCardContainer
			// 
			this.tpConceptCardContainer.Controls.Add(this.pnlConceptContainer);
			this.tpConceptCardContainer.Location = new System.Drawing.Point(4, 22);
			this.tpConceptCardContainer.Name = "tpConceptCardContainer";
			this.tpConceptCardContainer.Padding = new System.Windows.Forms.Padding(3);
			this.tpConceptCardContainer.Size = new System.Drawing.Size(502, 455);
			this.tpConceptCardContainer.TabIndex = 0;
			this.tpConceptCardContainer.Text = "Concept";
			this.tpConceptCardContainer.UseVisualStyleBackColor = true;
			// 
			// pnlConceptContainer
			// 
			this.pnlConceptContainer.AutoScroll = true;
			this.pnlConceptContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlConceptContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.pnlConceptContainer.Location = new System.Drawing.Point(3, 3);
			this.pnlConceptContainer.Name = "pnlConceptContainer";
			this.pnlConceptContainer.Size = new System.Drawing.Size(496, 449);
			this.pnlConceptContainer.TabIndex = 0;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
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
			this.tpConcept.ResumeLayout(false);
			this.pnlConcept.Panel1.ResumeLayout(false);
			this.pnlConcept.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlConcept)).EndInit();
			this.pnlConcept.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.tabConcept.ResumeLayout(false);
			this.tpTreeView.ResumeLayout(false);
			this.tpTreeView.PerformLayout();
			this.tpSearch.ResumeLayout(false);
			this.tpSearch.PerformLayout();
			this.stpToolTree.ResumeLayout(false);
			this.stpToolTree.PerformLayout();
			this.stpToolConceptSearch.ResumeLayout(false);
			this.stpToolConceptSearch.PerformLayout();
			this.tapConceptCardContainer.ResumeLayout(false);
			this.tpConceptCardContainer.ResumeLayout(false);
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
		private System.Windows.Forms.TabPage tpResource;
		private System.Windows.Forms.SplitContainer pnlConcept;
		private System.Windows.Forms.TabControl tabConcept;
		private System.Windows.Forms.TabPage tpTreeView;
		private System.Windows.Forms.TabPage tpSearch;
		private System.Windows.Forms.ToolStrip stpToolTree;
		private System.Windows.Forms.ToolStripButton btnExpandAll;
		private System.Windows.Forms.ToolStripButton btnCollapseAll;
		private System.Windows.Forms.TreeView tvwConcept;
		private System.Windows.Forms.ToolStripButton btnNewConcept;
		private System.Windows.Forms.ToolStrip stpToolConceptSearch;
		private System.Windows.Forms.ToolStripLabel lblConceptSearchPattern;
		private System.Windows.Forms.ToolStripTextBox txtConceptSearchPattern;
		private System.Windows.Forms.ToolStripButton btnConceptSearch;
		private System.Windows.Forms.ListBox lstConcept;
		private System.Windows.Forms.TabControl tapConceptCardContainer;
		private System.Windows.Forms.TabPage tpConceptCardContainer;
		private System.Windows.Forms.FlowLayoutPanel pnlConceptContainer;
	}
}

