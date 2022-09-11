using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace windows_filesystemsynchronizer
{
    public partial class MainForm : Form
    {
        private Boolean formIsHidden;
        public MainForm()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("Main");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.formIsHidden = false;
            System.Diagnostics.Debug.WriteLine("load");
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.formIsHidden = false;
            this.Show();
        }

        private void trayNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.formIsHidden = false;
            this.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                hideFormAndNotify();
            }
        }

        private void hideFormAndNotify()
        {
            this.Hide();
            trayNotifyIcon.ShowBalloonTip(1000, "Important", "Something important", ToolTipIcon.Info);
            this.formIsHidden = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.formIsHidden)
            {
                Application.Exit();
                return;
            }
            // notify user and prevent closing
            hideFormAndNotify();
            e.Cancel = true;
        }
    }
}
