using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BotM
{
    public class ModListing : INotifyPropertyChanged
    {
        internal Mod m;

        private string _ModName;
        public string ModName
        {
            get { return _ModName; }
            set
            {
                if (_ModName != value)
                {
                    _ModName = value;
                    NotifyPropertyChanged("ModName");
                }
            }
        }

        private string _ModHelp;
        public string ModHelp
        {
            get { return _ModHelp; }
            set
            {
                if (_ModHelp != value)
                {
                    _ModHelp = value;
                    NotifyPropertyChanged("ModHelp");
                }
            }
        }

        private string _ModAuthor;
        public string ModAuthor
        {
            get { return _ModAuthor; }
            set
            {
                if (_ModAuthor != value)
                {
                    _ModAuthor = value;
                    NotifyPropertyChanged("ModAuthor");
                }
            }
        }

        public bool _HasIcon;
        public bool HasIcon
        {
            get { return _HasIcon; }
            set
            {
                if(_HasIcon != value)
                {
                    _HasIcon = value;
                    NotifyPropertyChanged("HasIcon");
                }
            }
        }

        public System.Drawing.Bitmap _Icon;
        public System.Drawing.Bitmap Icon
        {
            get { return _Icon; }
            set
            {
                if(_Icon != value)
                {
                    _Icon = value;
                    NotifyPropertyChanged("Icon");
                }
            }
        }


        public void Ping()
        {
            NotifyPropertyChanged("Name");
        }

        public override string ToString()
        {
            return ModName + "\nAuthor: " + ModAuthor;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

    }
}