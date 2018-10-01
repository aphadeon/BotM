using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace BotM
{
    public partial class MainForm : Form
    {
        public static Settings Settings;
        FormSettings formSettings;
        FormMods formMods;
        SoundPlayer rollover = new SoundPlayer(Properties.Resources.mouseover);
        SoundPlayer click = new SoundPlayer(Properties.Resources.pop);

        public static Dictionary<string, string> ReplacedFiles = new Dictionary<string, string>();

        public static void SaveSettings()
        {
            System.IO.Directory.CreateDirectory(Settings.InstalledModsDirectory);
            System.IO.Directory.CreateDirectory(Settings.NotInstalledModsDirectory);
            System.IO.Directory.CreateDirectory(Settings.BackupDirectory);
            string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            System.IO.File.WriteAllText("config.json", json);
        }

        public MainForm(Settings s)
        {
            if (System.IO.File.Exists("affected.json"))
            {
                string j = System.IO.File.ReadAllText("affected.json");
                ReplacedFiles = JsonConvert.DeserializeObject<Dictionary<string,string>>(j);
            }
            InitializeComponent();
            CenterToScreen();
            Settings = s;
            formSettings = new FormSettings();
            formMods = new FormMods();

            formSettings.Visible = false;
            formMods.Visible = false;

            //sound effects
            buttonPlay.MouseEnter += OnButtonHover;
            buttonMods.MouseEnter += OnButtonHover;
            buttonSettings.MouseEnter += OnButtonHover;
            buttonExit.MouseEnter += OnButtonHover;
            buttonPlay.MouseClick += ButtonPlay_MouseClick;
            buttonMods.MouseClick += ButtonMods_MouseClick;
            buttonSettings.MouseClick += ButtonSettings_MouseClick;

            //draggable hacks
            MouseDown += OnMouseDown;
            pictureBox1.MouseDown += OnMouseDown;
            label2.MouseDown += OnMouseDown;
            FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(ReplacedFiles, Formatting.Indented);
            System.IO.File.WriteAllText("affected.json", json);
        }

        private void ButtonSettings_MouseClick(object sender, MouseEventArgs e)
        {
            click.Play();
            formSettings.ShowDialog(this);
        }

        private void ButtonMods_MouseClick(object sender, MouseEventArgs e)
        {
            click.Play();
            formMods.ShowDialog(this);
        }

        private void ButtonPlay_MouseClick(object sender, MouseEventArgs e)
        {
            click.Play();
            //todo: safety & sanity
            new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = new System.IO.FileInfo(Settings.LaunchCommand.Split(' ')[0]).Directory.FullName,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C " + Settings.LaunchCommand
                }
            }.Start();

            if (Settings.CloseOnRun)
            {
                System.Threading.Thread.Sleep(250);
                Application.Exit();
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            click.Play();
            System.Threading.Thread.Sleep(250);
            Application.Exit();
        }

        private void OnButtonHover(object sender, EventArgs e)
        {
            rollover.Play();
        }

        //draggable winform hack
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
    }
}
