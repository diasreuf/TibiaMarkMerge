using Aspose.Zip;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TibiaMarkerMerge
{

    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {

            foreach(Process p in Process.GetProcesses()) {
                if (p.ProcessName == "client" && p.MainWindowTitle == "Tibia") {
                    MessageBox.Show("Tibia client is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (updateMinimap.Checked)
            {

                DialogResult updateMinimapFiles = MessageBox.Show("Are you sure you want to update your minimap files?", "Update Minimap Files", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (updateMinimapFiles == DialogResult.No)
                {
                    return;
                }

            }

            Download download = new Download();

            download.FormClosing += Download_FormClosing;
            download.ShowDialog();

        }

        private void Download_FormClosing(object? sender, FormClosingEventArgs e)
        {

            Program.tibiaMapMarkerFile = String.Format(@"{0}\Tibia\packages\Tibia\minimap\minimapmarkers.bin", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            if (!File.Exists(Program.tibiaMapMarkerFile))
            {

                DialogResult tibiaMarkerAskResult = MessageBox.Show("Tibia installation folder not found.\nDo you want to find your minimapmarkers.bin?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (tibiaMarkerAskResult == DialogResult.No)
                {
                    return;
                }

                openFileDialog.FileName = String.Empty;
                openFileDialog.InitialDirectory = String.Format(@"{0}\Tibia\packages\Tibia\minimap", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                openFileDialog.Filter = "BIN Files (*.bin)|*.bin";

                DialogResult openTibiaMarkerDialog = openFileDialog.ShowDialog();
                if (openTibiaMarkerDialog == DialogResult.Cancel)
                {
                    return;
                }

                Program.tibiaMapMarkerFile = openFileDialog.FileName;

            }

            List<MapMarker> oldMarkers = Tools.DecodeMapMarkers(Program.tibiaMapMarkerFile);
            if (oldMarkers.Count == 0)
            {
                MessageBox.Show("Unable to decode minimapmarkers.bin file.\nThe file may be empty or corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(Program.tibiaMapsFile))
            {

                DialogResult tibiaMapsFileResult = MessageBox.Show("minimap-with-markers file not found.\nDo you want to find your minimap-with-markers.zip?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (tibiaMapsFileResult == DialogResult.No)
                {
                    return;
                }

                openFileDialog.FileName = String.Empty;
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "ZIP Files (*.zip)|*.zip";

                DialogResult openTibiaMapsResult = openFileDialog.ShowDialog();
                if (openTibiaMapsResult == DialogResult.Cancel)
                {
                    return;
                }

                Program.tibiaMapsFile = openFileDialog.FileName;

            }

            if (!File.Exists(Program.tibiaMapsFile) || new FileInfo(Program.tibiaMapsFile).Length < (1024 * 1024))
            {
                MessageBox.Show("Unable to unzip minimap-with-markers.zip.\nThe file may be empty or corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tibiaMapsMarkerFile = String.Format(@"{0}\minimapmarkers.bin", Path.GetDirectoryName(Application.ExecutablePath));
            string tibiaMinimapDirectory = String.Format(@"{0}\Tibia\packages\Tibia", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            using (var archive = new Archive(Program.tibiaMapsFile))
            {

                foreach (ArchiveEntry entry in archive.Entries)
                {

                    if (entry.IsDirectory || !Directory.Exists(tibiaMinimapDirectory))
                    {
                        continue;
                    }

                    if (entry.Name.Contains("minimapmarkers.bin"))
                    {

                        entry.Extract(tibiaMapsMarkerFile);

                    }
                    else
                    {

                        if (!updateMinimap.Checked)
                        {
                            continue;
                        }

                        entry.Extract(String.Format(@"{0}\{1}", tibiaMinimapDirectory, entry.Name));

                    }

                }

            }

            if (!File.Exists(tibiaMapsMarkerFile))
            {
                MessageBox.Show("Cannot find new minimapmarkers.bin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<MapMarker> newMarkers = Tools.DecodeMapMarkers(tibiaMapsMarkerFile);
            if (newMarkers.Count == 0)
            {
                MessageBox.Show("Unable to decode new minimapmarkers.bin file.\nThe file may be empty or corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<MapMarker> result = newMarkers.Where(p => !oldMarkers.Any(l => p.PosX == l.PosX && p.PosY == l.PosY && p.PosZ == l.PosZ && p.MarkerIcon == l.MarkerIcon && p.Description == l.Description));
            if (result.Count() == 0)
            {
                MessageBox.Show("There are no new map markers to add.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int newMarkerCount = result.Count();
            foreach (MapMarker marker in result)
            {
                oldMarkers.Add(marker);
            }

            if (backupMarkers.Checked)
            {
                File.Copy(Program.tibiaMapMarkerFile, String.Format(@"{0}\minimap_{1}.bin", Path.GetDirectoryName(Program.tibiaMapMarkerFile), DateTimeOffset.UtcNow.ToUnixTimeSeconds()));
            }

            if (!Tools.SaveMapMarkers(oldMarkers, Program.tibiaMapMarkerFile))
            {
                MessageBox.Show("Unable to update your old map markers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(String.Format("Added new {0} map markers to your client.", newMarkerCount), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void reuforgediLabel_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo {
                FileName = "https://www.tibia.com/community/?subtopic=characters&name=Reuforgedi",
                UseShellExecute = true
            });
        }
    }

}
