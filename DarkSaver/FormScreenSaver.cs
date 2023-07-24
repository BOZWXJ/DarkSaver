using PInvoke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkSaver
{
	public partial class FormScreenSaver : Form
	{
		public bool IsPreviewMode { get; }

		public FormScreenSaver(Screen screen)
		{
			InitializeComponent();

			Capture = true;
			Bounds = screen.Bounds;
			pictureBox1.Visible = false;
			Opacity = 0.8;

			rect = new Rectangle(Cursor.Position.X - 10, Cursor.Position.Y - 10, 20, 20);

			IsPreviewMode = false;
		}

		public FormScreenSaver(IntPtr PreviewHandle)
		{
			InitializeComponent();

			//このウィンドウの親ウィンドウを設定する
			User32.SetParent(this.Handle, PreviewHandle);

			//この子ウィンドウを作成する
			//スクリーンセーバーの設定ダイアログボックスが閉じられると終了する
			User32.SetWindowLong(this.Handle, User32.WindowLongIndexFlags.GWL_STYLE, (User32.SetWindowLongFlags)(User32.GetWindowLong(this.Handle, User32.WindowLongIndexFlags.GWL_STYLE) | 0x40000000));

			//親ウィンドウのサイズに設定する
			RECT ParentRect;
			User32.GetClientRect(PreviewHandle, out ParentRect);
			Size = new Size(ParentRect.right - ParentRect.left + 1, ParentRect.bottom - ParentRect.top + 1);
			Location = new Point(0, 0);

			pictureBox1.Image = new Bitmap(Bounds.Width, Bounds.Height);
			using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
			using (Brush brush = new SolidBrush(Color.FromArgb(205, 0, 0, 0)))
			using (Graphics g1 = Graphics.FromImage(bmp))
			using (Graphics g2 = Graphics.FromImage(pictureBox1.Image)) {
				g1.CopyFromScreen(0, 0, 0, 0, bmp.Size);
				g2.DrawImage(bmp, pictureBox1.Bounds);
				g2.FillRectangle(brush, pictureBox1.Bounds);
				pictureBox1.Refresh();
			}

			IsPreviewMode = true;
		}

		private void FormScreenSaver_KeyDown(object sender, KeyEventArgs e)
		{
			if (!IsPreviewMode) {
				Environment.Exit(0);
			}
		}

		private void FormScreenSaver_MouseDown(object sender, MouseEventArgs e)
		{
			if (!IsPreviewMode) {
				Environment.Exit(0);
			}
		}

		Rectangle rect;
		private void FormScreenSaver_MouseMove(object sender, MouseEventArgs e)
		{
			if (!IsPreviewMode && !rect.Contains(Cursor.Position)) {
				Environment.Exit(0);
			}
		}

	}
}
