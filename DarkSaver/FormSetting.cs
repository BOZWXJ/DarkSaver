using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkSaver
{
	public partial class FormSetting : Form
	{
		public FormSetting()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
