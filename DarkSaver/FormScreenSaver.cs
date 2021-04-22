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
		public FormScreenSaver(Screen screen)
		{
			InitializeComponent();
			this.Bounds = screen.Bounds;
			rect = new Rectangle(Cursor.Position.X - 10, Cursor.Position.Y - 10, 20, 20);

			IsPreviewMode = false;
		}

		public FormScreenSaver(IntPtr PreviewHandle)
		{
			InitializeComponent();
			//このウィンドウの親ウィンドウを設定する
			Win32API.SetParent(this.Handle, PreviewHandle);

			//この子ウィンドウを作成する
			//スクリーンセーバーの設定ダイアログボックスが閉じられると終了する
			Win32API.SetWindowLong(this.Handle, -16, new IntPtr(Win32API.GetWindowLong(this.Handle, -16) | 0x40000000));

			//親ウィンドウのサイズに設定する
			Rectangle ParentRect;
			Win32API.GetClientRect(PreviewHandle, out ParentRect);
			Size = ParentRect.Size;
			Location = new Point(0, 0);

			IsPreviewMode = true;
		}

		public bool IsPreviewMode { get; }

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
