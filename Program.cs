using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotM
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Settings s;
            if (System.IO.File.Exists("config.json"))
            {
                string json = System.IO.File.ReadAllText("config.json");
                s = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(json);
            }
            else s = new Settings()
            {
                LaunchCommand = "C:\\Cemu\\Cemu.exe -g \"G:\\Cemu\\games\\botw\\code\\U-King.rpx\"",
                UpdatePath = "C:\\Cemu\\mlc01\\usr\title\\00050000\\101C9400\\",
                GamePath = "C:\\Cemu\\games\\botw\\",
                NotInstalledModsDirectory = "mods\\",
                InstalledModsDirectory = "mods\\installed\\",
                BackupDirectory = "mods\\installed\\backup\\",
                DeveloperMode = false
            };
            System.IO.Directory.CreateDirectory(s.InstalledModsDirectory);
            System.IO.Directory.CreateDirectory(s.NotInstalledModsDirectory);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(s));
        }
    }
}
