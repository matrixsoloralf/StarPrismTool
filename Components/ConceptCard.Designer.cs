namespace StarPrismTools.Components
{
	partial class ConceptCard
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
			this.gbConcept = new System.Windows.Forms.GroupBox();
			this.lblImgIndex = new System.Windows.Forms.Label();
			this.txtConceptExplanation = new System.Windows.Forms.RichTextBox();
			this.btnDelete = new System.Windows.Forms.LinkLabel();
			this.lnkEdit = new System.Windows.Forms.LinkLabel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRemoveImg = new System.Windows.Forms.Button();
			this.btnAddImg = new System.Windows.Forms.Button();
			this.picEffectArea = new System.Windows.Forms.PictureBox();
			this.gbConcept.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEffectArea)).BeginInit();
			this.SuspendLayout();
			// 
			// gbConcept
			// 
			this.gbConcept.Controls.Add(this.btnRemoveImg);
			this.gbConcept.Controls.Add(this.btnAddImg);
			this.gbConcept.Controls.Add(this.btnCancel);
			this.gbConcept.Controls.Add(this.btnOK);
			this.gbConcept.Controls.Add(this.lnkEdit);
			this.gbConcept.Controls.Add(this.btnDelete);
			this.gbConcept.Controls.Add(this.txtConceptExplanation);
			this.gbConcept.Controls.Add(this.lblImgIndex);
			this.gbConcept.Controls.Add(this.picEffectArea);
			this.gbConcept.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbConcept.Location = new System.Drawing.Point(0, 0);
			this.gbConcept.Name = "gbConcept";
			this.gbConcept.Size = new System.Drawing.Size(512, 128);
			this.gbConcept.TabIndex = 0;
			this.gbConcept.TabStop = false;
			this.gbConcept.Text = "Concept Name";
			// 
			// lblImgIndex
			// 
			this.lblImgIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblImgIndex.AutoSize = true;
			this.lblImgIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblImgIndex.Location = new System.Drawing.Point(479, 106);
			this.lblImgIndex.Name = "lblImgIndex";
			this.lblImgIndex.Size = new System.Drawing.Size(24, 13);
			this.lblImgIndex.TabIndex = 1;
			this.lblImgIndex.Text = "0/0";
			this.lblImgIndex.Visible = false;
			// 
			// txtConceptExplanation
			// 
			this.txtConceptExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConceptExplanation.BackColor = System.Drawing.SystemColors.ControlLight;
			this.txtConceptExplanation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtConceptExplanation.Enabled = false;
			this.txtConceptExplanation.Location = new System.Drawing.Point(6, 21);
			this.txtConceptExplanation.Name = "txtConceptExplanation";
			this.txtConceptExplanation.Size = new System.Drawing.Size(393, 72);
			this.txtConceptExplanation.TabIndex = 2;
			this.txtConceptExplanation.Text = "";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.AutoSize = true;
			this.btnDelete.Location = new System.Drawing.Point(6, 103);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(53, 16);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.TabStop = true;
			this.btnDelete.Text = "Delete";
			// 
			// lnkEdit
			// 
			this.lnkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lnkEdit.AutoSize = true;
			this.lnkEdit.Location = new System.Drawing.Point(65, 103);
			this.lnkEdit.Name = "lnkEdit";
			this.lnkEdit.Size = new System.Drawing.Size(34, 16);
			this.lnkEdit.TabIndex = 4;
			this.lnkEdit.TabStop = true;
			this.lnkEdit.Text = "Edit";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(243, 99);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Visible = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(324, 99);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			// 
			// btnRemoveImg
			// 
			this.btnRemoveImg.BackgroundImage = global::StarPrismTools.Properties.Resources._83b752f6af6642b38c2cdf18bf9e71bb;
			this.btnRemoveImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRemoveImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRemoveImg.Location = new System.Drawing.Point(407, 42);
			this.btnRemoveImg.Name = "btnRemoveImg";
			this.btnRemoveImg.Size = new System.Drawing.Size(20, 20);
			this.btnRemoveImg.TabIndex = 8;
			this.btnRemoveImg.UseVisualStyleBackColor = true;
			this.btnRemoveImg.Visible = false;
			// 
			// btnAddImg
			// 
			this.btnAddImg.BackgroundImage = global::StarPrismTools.Properties.Resources._5471389542d547acad1b899731e8da14;
			this.btnAddImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAddImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddImg.Location = new System.Drawing.Point(407, 23);
			this.btnAddImg.Name = "btnAddImg";
			this.btnAddImg.Size = new System.Drawing.Size(20, 20);
			this.btnAddImg.TabIndex = 7;
			this.btnAddImg.UseVisualStyleBackColor = true;
			this.btnAddImg.Visible = false;
			// 
			// picEffectArea
			// 
			this.picEffectArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.picEffectArea.Location = new System.Drawing.Point(405, 21);
			this.picEffectArea.Name = "picEffectArea";
			this.picEffectArea.Size = new System.Drawing.Size(101, 101);
			this.picEffectArea.TabIndex = 0;
			this.picEffectArea.TabStop = false;
			this.picEffectArea.Visible = false;
			// 
			// ConceptCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbConcept);
			this.Name = "ConceptCard";
			this.Size = new System.Drawing.Size(512, 128);
			this.gbConcept.ResumeLayout(false);
			this.gbConcept.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEffectArea)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbConcept;
		private System.Windows.Forms.PictureBox picEffectArea;
		private System.Windows.Forms.Label lblImgIndex;
		private System.Windows.Forms.RichTextBox txtConceptExplanation;
		private System.Windows.Forms.LinkLabel btnDelete;
		private System.Windows.Forms.LinkLabel lnkEdit;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRemoveImg;
		private System.Windows.Forms.Button btnAddImg;
	}
}
