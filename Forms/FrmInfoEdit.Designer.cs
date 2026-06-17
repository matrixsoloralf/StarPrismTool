namespace StarPrismTools.Forms
{
	partial class FrmInfoEdit
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.gbProfile = new System.Windows.Forms.GroupBox();
			this.ckbAgeUnknown = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblSex = new System.Windows.Forms.Label();
			this.cboSex = new System.Windows.Forms.ComboBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtTttle = new System.Windows.Forms.TextBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblQuote = new System.Windows.Forms.Label();
			this.txtQuote = new System.Windows.Forms.TextBox();
			this.lblStory = new System.Windows.Forms.Label();
			this.txtStory = new System.Windows.Forms.TextBox();
			this.gbProfile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(217, 346);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(136, 346);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// gbProfile
			// 
			this.gbProfile.Controls.Add(this.ckbAgeUnknown);
			this.gbProfile.Controls.Add(this.numericUpDown1);
			this.gbProfile.Controls.Add(this.lblAge);
			this.gbProfile.Controls.Add(this.lblSex);
			this.gbProfile.Controls.Add(this.cboSex);
			this.gbProfile.Controls.Add(this.lblName);
			this.gbProfile.Controls.Add(this.txtName);
			this.gbProfile.Controls.Add(this.txtTttle);
			this.gbProfile.Controls.Add(this.lblTitle);
			this.gbProfile.Location = new System.Drawing.Point(12, 12);
			this.gbProfile.Name = "gbProfile";
			this.gbProfile.Size = new System.Drawing.Size(280, 140);
			this.gbProfile.TabIndex = 2;
			this.gbProfile.TabStop = false;
			this.gbProfile.Text = "Profile";
			// 
			// ckbAgeUnknown
			// 
			this.ckbAgeUnknown.AutoSize = true;
			this.ckbAgeUnknown.Location = new System.Drawing.Point(178, 101);
			this.ckbAgeUnknown.Name = "ckbAgeUnknown";
			this.ckbAgeUnknown.Size = new System.Drawing.Size(72, 17);
			this.ckbAgeUnknown.TabIndex = 8;
			this.ckbAgeUnknown.Text = "Unknown";
			this.ckbAgeUnknown.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(90, 100);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
			this.numericUpDown1.TabIndex = 7;
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(24, 102);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(26, 13);
			this.lblAge.TabIndex = 6;
			this.lblAge.Text = "Age";
			// 
			// lblSex
			// 
			this.lblSex.AutoSize = true;
			this.lblSex.Location = new System.Drawing.Point(24, 76);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(25, 13);
			this.lblSex.TabIndex = 5;
			this.lblSex.Text = "Sex";
			// 
			// cboSex
			// 
			this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSex.FormattingEnabled = true;
			this.cboSex.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other",
            "Unknown"});
			this.cboSex.Location = new System.Drawing.Point(90, 73);
			this.cboSex.Name = "cboSex";
			this.cboSex.Size = new System.Drawing.Size(60, 21);
			this.cboSex.TabIndex = 4;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(24, 50);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(90, 47);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(160, 20);
			this.txtName.TabIndex = 2;
			// 
			// txtTttle
			// 
			this.txtTttle.Location = new System.Drawing.Point(90, 21);
			this.txtTttle.Name = "txtTttle";
			this.txtTttle.Size = new System.Drawing.Size(160, 20);
			this.txtTttle.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(24, 24);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(27, 13);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			// 
			// lblQuote
			// 
			this.lblQuote.AutoSize = true;
			this.lblQuote.Location = new System.Drawing.Point(12, 168);
			this.lblQuote.Name = "lblQuote";
			this.lblQuote.Size = new System.Drawing.Size(36, 13);
			this.lblQuote.TabIndex = 3;
			this.lblQuote.Text = "Quote";
			// 
			// txtQuote
			// 
			this.txtQuote.Location = new System.Drawing.Point(15, 192);
			this.txtQuote.Multiline = true;
			this.txtQuote.Name = "txtQuote";
			this.txtQuote.Size = new System.Drawing.Size(277, 48);
			this.txtQuote.TabIndex = 4;
			// 
			// lblStory
			// 
			this.lblStory.AutoSize = true;
			this.lblStory.Location = new System.Drawing.Point(12, 256);
			this.lblStory.Name = "lblStory";
			this.lblStory.Size = new System.Drawing.Size(31, 13);
			this.lblStory.TabIndex = 5;
			this.lblStory.Text = "Story";
			// 
			// txtStory
			// 
			this.txtStory.Location = new System.Drawing.Point(15, 280);
			this.txtStory.Multiline = true;
			this.txtStory.Name = "txtStory";
			this.txtStory.Size = new System.Drawing.Size(277, 48);
			this.txtStory.TabIndex = 6;
			// 
			// FrmInfoEdit
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(304, 381);
			this.Controls.Add(this.txtStory);
			this.Controls.Add(this.lblStory);
			this.Controls.Add(this.txtQuote);
			this.Controls.Add(this.lblQuote);
			this.Controls.Add(this.gbProfile);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmInfoEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Info Edit";
			this.gbProfile.ResumeLayout(false);
			this.gbProfile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox gbProfile;
		private System.Windows.Forms.ComboBox cboSex;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtTttle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.CheckBox ckbAgeUnknown;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblSex;
		private System.Windows.Forms.Label lblQuote;
		private System.Windows.Forms.TextBox txtQuote;
		private System.Windows.Forms.Label lblStory;
		private System.Windows.Forms.TextBox txtStory;
	}
}