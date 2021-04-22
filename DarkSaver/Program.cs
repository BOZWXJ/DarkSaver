using System;
using System.Windows.Forms;

namespace DarkSaver
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			int i;
			if (args.Length >= 1 && args[0].StartsWith("/s", StringComparison.OrdinalIgnoreCase)) {
				// �X�N���[���Z�[�o�[�\��
				foreach (Screen screen in Screen.AllScreens) {
					var form = new FormScreenSaver(screen);
					form.Show();
				}
				Cursor.Hide();
				Application.Run();
			} else if (args.Length >= 2 && args[0].StartsWith("/p", StringComparison.OrdinalIgnoreCase)) {
				// �v���r���[�\��
				Application.Run(new FormScreenSaver(new IntPtr(long.Parse(args[1]))));
			} else if (args.Length >= 1 && args[0].StartsWith("/c", StringComparison.OrdinalIgnoreCase) && args[0].Length > 3 && int.TryParse(args[0].Substring(3), out i)) {
				// �ݒ�t�H�[���\��
				ShowConfigForm(Win32API.GetAncestor(new IntPtr(i), Win32API.GA_ROOT));
			} else {
				ShowConfigForm(IntPtr.Zero);
			}
		}

		static void ShowConfigForm(IntPtr owner)
		{
			string text = "�I�v�V�����Ȃ�\n\n���̃X�N���[�� �Z�[�o�[�ɂ́A�ݒ�ł���I�v�V�����͂���܂���B";
			string caption = "Dark Saver";
			if (owner != IntPtr.Zero) {
				MessageBox.Show(new NativeForm(owner), text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else {
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			//Form form = new FormSetting();
			//if (owner != IntPtr.Zero) {
			//	form.ShowDialog(new NativeForm(owner));
			//} else {
			//	form.ShowDialog();
			//}
		}
	}

	class NativeForm : IWin32Window
	{
		private IntPtr handle;
		public NativeForm(IntPtr hwnd) { handle = hwnd; }
		public IntPtr Handle { get { return handle; } }
	}
}

