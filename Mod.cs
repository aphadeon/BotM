using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotM
{
    public class Mod
    {
        public string ModName { get; set; }
        public string ModAuthor { get; set; }
        public List<InstallAction> InstallActions { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string ModHelp { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string ModFile { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ModIcon ModIcon { get; set; }
    }
}
