using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BotM
{
    public partial class FormMods : Form
    {
        private bool hacking = false;
        public FormMods()
        {
            InitializeComponent();
            CenterToScreen();
            listBoxInstalled.DataSource = new BindingList<ModListing>();
            listBoxNotInstalled.DataSource = new BindingList<ModListing>();
            UpdateModList();

            var feh = new System.IO.FileSystemEventHandler(OnFileEvent);
            var feh2 = new System.IO.RenamedEventHandler(OnFileEvent);
            System.IO.FileSystemWatcher watcher1 = new System.IO.FileSystemWatcher
            {
                Path = MainForm.Settings.NotInstalledModsDirectory,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.botm.zip"
            };
            watcher1.Created += feh;
            watcher1.Changed += feh;
            watcher1.Renamed += feh2;
            watcher1.Deleted += feh;
            watcher1.EnableRaisingEvents = true;
            System.IO.FileSystemWatcher watcher2 = new System.IO.FileSystemWatcher
            {
                Path = MainForm.Settings.NotInstalledModsDirectory,
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.botm.zip"
            };
            watcher2.Created += feh;
            watcher2.Deleted += feh;
            watcher2.EnableRaisingEvents = true;
        }

        private void OnFileEvent(object n, EventArgs e)
        {
            UpdateModList();
        }

        private void UpdateModList()
        {
            if (hacking) return;
            hacking = true;
            BindingList<ModListing> niMods = (BindingList<ModListing>)listBoxNotInstalled.DataSource;
            niMods.Clear();
            foreach (var f in Directory.GetFiles(MainForm.Settings.NotInstalledModsDirectory, "*.botm.zip"))
            {
                Mod m = ReadModMeta(f);
                if (m == null)
                {
                    MessageBox.Show(this, "Mod ignored- Appears to be invalid:\n\n" + f, "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                niMods.Add(new ModListing { m = m, ModName = m.ModName, ModAuthor = m.ModAuthor, ModHelp = m.ModHelp, HasIcon = (m.ModIcon != null),  Icon = m.ModIcon?.bmp });
            }

            BindingList<ModListing> iMods = (BindingList<ModListing>)listBoxInstalled.DataSource;
            iMods.Clear();
            foreach (var f in Directory.GetFiles(MainForm.Settings.InstalledModsDirectory, "*.botm.zip"))
            {
                Mod m = ReadModMeta(f);
                if (m == null)
                {
                    MessageBox.Show(this, "Mod ignored- Appears to be invalid:\n\n" + f, "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
                iMods.Add(new ModListing { m = m, ModName = m.ModName, ModAuthor = m.ModAuthor, ModHelp = m.ModHelp, HasIcon = (m.ModIcon != null), Icon = m.ModIcon?.bmp });
            }
            listBoxInstalled.Invoke(new Action(listBoxInstalled.ListHack));
            listBoxNotInstalled.Invoke(new Action(listBoxNotInstalled.ListHack));
            hacking = false;
        }

        private Mod ReadModMeta(string filepath)
        {
            if (!File.Exists(filepath)) return null;
            try
            {
                using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    using (var zf = new ZipFile(fs))
                    {
                        Mod m;
                        
                        var ze = zf.GetEntry("mod.json");
                        if (ze == null)
                        {
                            if (MainForm.Settings.DeveloperMode) MessageBox.Show(this, "Mod read error:\n\n" + filepath + "\n\nMissing mod.json !", "Mod Read Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }

                        using (var s = zf.GetInputStream(ze))
                        {
                            using (StreamReader reader = new StreamReader(s))
                            {
                                m = Newtonsoft.Json.JsonConvert.DeserializeObject<Mod>(reader.ReadToEnd());
                            }
                        }

                        m.ModFile = filepath;

                        var ze2 = zf.GetEntry("mod.png");
                        if(ze2 != null)
                        {
                            //this mod has an icon
                            using (var s = zf.GetInputStream(ze2))
                            {
                                m.ModIcon = new ModIcon(new Bitmap(s));
                            }
                        }

                        var ze3 = zf.GetEntry("readme.txt");
                        if (ze3 != null)
                        {
                            //this mod has a readme
                            using (var s = zf.GetInputStream(ze3))
                            {
                                using (StreamReader reader = new StreamReader(s))
                                {
                                    m.ModHelp = reader.ReadToEnd();
                                }
                            }
                        } else
                        {
                            m.ModHelp = null;
                        }

                        return m;
                    }
                }
            } catch (Exception e)
            {
                if (MainForm.Settings.DeveloperMode)
                {
                    MessageBox.Show(this, "Mod read error:\n\n" + filepath + "\n\n" + e.Message, "Mod Read Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return null;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog
            {
                Title = "Add Mod from File",
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                Filter = "BotM Mod (*.botm.zip)|*.botm.zip|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                string fn = System.IO.Path.GetFileName(fdlg.FileName);
                try
                {
                    System.IO.File.Copy(fdlg.FileName, System.IO.Path.Combine(MainForm.Settings.NotInstalledModsDirectory, fn));
                    MessageBox.Show("Mod successfully imported.");
                } catch(Exception ex)
                {
                    MessageBox.Show(this, "Mod import failed:\n\n" + ex.Message,"Mod Import Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MainForm.Settings.NotInstalledModsDirectory);
        }

        private void OnModClick(object sender, EventArgs e)
        {
            ListBoxMods lbm = (ListBoxMods)sender;
            if(lbm.SelectedItem != null)
            {
                string help = ((ModListing)lbm.SelectedItem).ModHelp;
                if (!string.IsNullOrWhiteSpace(help))
                {
                    textBoxHelp.Text = ((ModListing)lbm.SelectedItem).ModHelp;
                    textBoxHelp.Visible = true;
                } else
                {
                    textBoxHelp.Text = "";
                    textBoxHelp.Visible = false;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //install mod
            if (listBoxNotInstalled.SelectedItem == null) return;
            try
            {
                ModListing ml = (ModListing)listBoxNotInstalled.SelectedItem;

                //do install
                List<InstallAction> actions = ml.m.InstallActions;
                if(actions != null)
                {
                    foreach(var a in actions)
                    {
                        switch (a.Action)
                        {
                            case "Overwrite":
                                if(a.Parameters.Length != 2)
                                {
                                    MessageBox.Show("Wrong number of parameters for install action: " + a.Action);
                                    continue;
                                }
                                Overwrite(ml.m, a.Parameters[0], a.Parameters[1]);
                                break;
                            default:
                                MessageBox.Show("Unknown install action:\n" + a.Action);
                                continue;
                        }
                    }
                }

                File.Move(ml.m.ModFile, Path.Combine(MainForm.Settings.InstalledModsDirectory, Path.GetFileName(ml.m.ModFile)));
                MessageBox.Show("Mod successfully installed.");
            }
            catch(Exception ex) {
                MessageBox.Show("Error occured while installing mod:\n" + ex.Message);
            }
        }

        public void UnOverwrite(Mod m, string destinationFile)
        {
            if (!File.Exists(m.ModFile)) throw new Exception("Mod file does not exist!");
            string baseFile = destinationFile;
            //let's find the destination
            if (destinationFile.StartsWith("update\\"))
            {
                destinationFile = destinationFile.Substring(7);
                destinationFile = MainForm.Settings.UpdatePath + Path.DirectorySeparatorChar + destinationFile;
            }
            else if (destinationFile.StartsWith("game\\"))
            {
                destinationFile = destinationFile.Substring(5);
                destinationFile = MainForm.Settings.GamePath + Path.DirectorySeparatorChar + destinationFile;
            }

            string backupFile = Path.Combine(MainForm.Settings.BackupDirectory, Path.GetFileNameWithoutExtension(m.ModFile), Path.GetFileName(destinationFile));
            if (File.Exists(backupFile))
            {
                DialogResult dr = MessageBox.Show(this, "Would you like to restore the backup of: " + destinationFile, "Restore Backup?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                if(MainForm.ReplacedFiles.ContainsKey(baseFile)) MainForm.ReplacedFiles.Remove(baseFile);
                File.Copy(backupFile, destinationFile, true);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "No backup available for:\n" + destinationFile + "\nSelect 'Yes' to leave the file where it is,\nor 'No' to remove it (not recommended!)", "No Backup!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes) return;
                else
                {
                    File.Delete(destinationFile);
                }
            }
        }

        public void Overwrite(Mod m, string sourceFile, string destinationFile)
        {
            if (!File.Exists(m.ModFile)) throw new Exception("Mod file does not exist!");

            using (var fs = new FileStream(m.ModFile, FileMode.Open, FileAccess.Read))
            {
                using (var zf = new ZipFile(fs))
                {

                    var ze = zf.GetEntry(sourceFile.Replace('\\', '/'));
                    if (ze == null)
                    {
                        if (MainForm.Settings.DeveloperMode) MessageBox.Show(this, "Mod read error:\n\n" + m.ModName + "\n\nMissing file: " + sourceFile, "Mod Read Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (var s = zf.GetInputStream(ze))
                    {
                        byte[] output;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            s.CopyTo(ms);
                            output = ms.ToArray();
                        }

                        //we have the source file
                        //let's find the destination
                        string baseFile = destinationFile;
                        if (destinationFile.StartsWith("update\\"))
                        {
                            destinationFile = destinationFile.Substring(7);
                            destinationFile = MainForm.Settings.UpdatePath + Path.DirectorySeparatorChar + destinationFile;
                        } else if(destinationFile.StartsWith("game\\"))
                        {
                            destinationFile = destinationFile.Substring(5);
                            destinationFile = MainForm.Settings.GamePath + Path.DirectorySeparatorChar + destinationFile;
                        }
                        if (File.Exists(destinationFile))
                        {
                            DialogResult dr = MessageBox.Show(this, "The mod would like to replace this file: " + destinationFile + "\n\nAllow this operation?", "Overwrite", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.No) return;

                            if (MainForm.ReplacedFiles.ContainsKey(baseFile))
                            {
                                DialogResult dr3 = MessageBox.Show(this, "Another mod (" + MainForm.ReplacedFiles[baseFile] + ") has already replaced this file: " + destinationFile + "\n\nContinue anyway? (not recommended)", "Mod Collision", MessageBoxButtons.YesNo);
                                if (dr3 == DialogResult.No) return;
                            }

                            //create backup
                            try
                            {
                                Directory.CreateDirectory(Path.Combine(MainForm.Settings.BackupDirectory, Path.GetFileNameWithoutExtension(m.ModFile)));
                                File.Copy(destinationFile, Path.Combine(MainForm.Settings.BackupDirectory, Path.GetFileNameWithoutExtension(m.ModFile), Path.GetFileName(destinationFile)), true);
                            } catch(Exception e)
                            {
                                DialogResult dr2 = MessageBox.Show(this, "Failed to backup file: " + destinationFile + "\n" + e.Message + "\nContinue anyway? (not recommended!)", "Backup Failed!", MessageBoxButtons.YesNo);
                                if (dr2 == DialogResult.No) return;
                            }
                        } else
                        {
                            DialogResult dr = MessageBox.Show(this, "Tried to replace this file:\n" + destinationFile + "\n\nbut it doesn't seem to exist.\nPlease make sure directories are set correctly.\n\nPlace file here anyway?", "Overwrite", MessageBoxButtons.YesNo);
                            if(dr == DialogResult.No) return;
                        }
                        MainForm.ReplacedFiles[baseFile] = Path.GetFileNameWithoutExtension(m.ModFile);
                        File.WriteAllBytes(destinationFile, output);
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //uninstall mod
            if (listBoxInstalled.SelectedItem == null) return;
            try
            {
                ModListing ml = (ModListing)listBoxInstalled.SelectedItem;

                //do uninstall
                List<InstallAction> actions = ml.m.InstallActions;
                if (actions != null)
                {
                    foreach (var a in actions)
                    {
                        switch (a.Action)
                        {
                            case "Overwrite":
                                if (a.Parameters.Length != 2)
                                {
                                    MessageBox.Show("Wrong number of parameters for install action: " + a.Action);
                                    continue;
                                }
                                UnOverwrite(ml.m, a.Parameters[1]);
                                break;
                            default:
                                MessageBox.Show("Unknown install action:\n" + a.Action);
                                continue;
                        }
                    }
                }

                File.Move(ml.m.ModFile, Path.Combine(MainForm.Settings.NotInstalledModsDirectory, Path.GetFileName(ml.m.ModFile)));
                MessageBox.Show("Mod successfully uninstalled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while uninstalling mod:\n" + ex.Message);
            }
        }
    }
}
