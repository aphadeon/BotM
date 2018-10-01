using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotM
{
    public class Settings
    {
        public string LaunchCommand { get; set; }
        public string UpdatePath { get; set; }
        public string GamePath { get; set; }
        public string NotInstalledModsDirectory { get; set; }
        public string InstalledModsDirectory { get; set; }
        public string BackupDirectory { get; set; }
        public bool CloseOnRun { get; set; }
        public bool DeveloperMode { get; set; }
    }
}
