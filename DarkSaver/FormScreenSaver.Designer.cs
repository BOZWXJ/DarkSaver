
namespace DarkSaver
{
	partial class FormScreenSaver
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
			if (disposing && (components != null)) {
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
			this.SuspendLayout();
			// 
			// FormScreenSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "FormScreenSaver";
			this.Opacity = 0.8D;
			this.Text = "FormScreenSaver";
			this.TopMost = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormScreenSaver_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormScreenSaver_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormScreenSaver_MouseMove);
			this.ResumeLayout(false);

		}

		#endregion
	}
}