namespace StarPrismTools.Forms
{
	partial class FrmViewCode
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
			this.txtJsonCode = new System.Windows.Forms.RichTextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnEditSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtJsonCode
			// 
			this.txtJsonCode.Enabled = false;
			this.txtJsonCode.Location = new System.Drawing.Point(12, 12);
			this.txtJsonCode.Name = "txtJsonCode";
			this.txtJsonCode.Size = new System.Drawing.Size(360, 208);
			this.txtJsonCode.TabIndex = 0;
			this.txtJsonCode.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(297, 226);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnEditSave
			// 
			this.btnEditSave.Location = new System.Drawing.Point(216, 226);
			this.btnEditSave.Name = "btnEditSave";
			this.btnEditSave.Size = new System.Drawing.Size(75, 23);
			this.btnEditSave.TabIndex = 2;
			this.btnEditSave.Text = "Edit";
			this.btnEditSave.UseVisualStyleBackColor = true;
			// 
			// FrmViewCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.btnEditSave);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtJsonCode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmViewCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View Code";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtJsonCode;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnEditSave;
	}
}