using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotM
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            CenterToScreen();
            Shown += FormSettings_Shown;
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            checkBoxCloseOnRun.Checked = MainForm.Settings.CloseOnRun;
            textBoxCommand.Text = MainForm.Settings.LaunchCommand;
            textBoxMlc.Text = MainForm.Settings.UpdatePath;
            textBoxGamePath.Text = MainForm.Settings.GamePath;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            MainForm.Settings.CloseOnRun = checkBoxCloseOnRun.Checked;
            MainForm.Settings.LaunchCommand = textBoxCommand.Text;
            MainForm.Settings.UpdatePath = textBoxMlc.Text;
            MainForm.Settings.GamePath = textBoxGamePath.Text;
            MainForm.SaveSettings();
            Close();
        }

        
    }
}
