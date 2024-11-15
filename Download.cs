using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TibiaMarkerMerge
{

    public partial class Download : Form
    {

        public Download()
        {
            InitializeComponent();
            InitializeGraphics();
            InitializeUpdate();
        }

        private void InitializeGraphics()
        {

            Bitmap header = new Bitmap(569, 80);
            using (Graphics g = Graphics.FromImage(header))
            {
                g.Clear(Color.FromArgb(178, 255, 255, 255));
                g.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, header.Width, header.Width), Color.White, Color.CadetBlue, LinearGradientMode.Horizontal), new Rectangle(0, 0, header.Width, header.Width));
                g.DrawLine(new Pen(Brushes.DarkGray, 1), new Point(header.Width, 79), new Point(0, 79));
            }

            headerBackground.Image = header;
            headerBackground.Size = new Size(headerBackground.Size.Width, 80);

            updateImage.Image = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("TibiaMarkerMerge.Resources.updateImage.png"));
            updateImage.Parent = headerBackground;
            updateImage.BackColor = Color.Transparent;
            updateImage.Location = new Point(((headerBackground.Size.Width - 64) - 8), 10);
            updateImage.Size = new Size(64, 64);


            updateText1.Parent = headerBackground;
            updateText1.BackColor = Color.Transparent;
            updateText1.Location = new Point(10, 12);

            updateText2.Parent = headerBackground;
            updateText2.BackColor = Color.Transparent;
            updateText2.Location = new Point(15, 34);

            updateText3.Parent = headerBackground;
            updateText3.BackColor = Color.Transparent;
            updateText3.Location = new Point(15, 49);

            updateStatus.Location = new Point(12, 90);
            updateProgress.Location = new Point(14, 110);

        }

        public void InitializeUpdate()
        {

            Program.tibiaMapsFileSize = 0;
            Program.tibiaMapsFile = String.Format(@"{0}\minimap-with-markers.zip", Path.GetDirectoryName(Application.ExecutablePath));

            new Thread(DownloadMapArchive).Start();

        }

        private void DownloadMapArchive()
        {

            using (ManualResetEventSlim completedEvent = new ManualResetEventSlim(false))
            {

                WebClient webclient = new WebClient();

                webclient.DownloadFileCompleted += (s, e) => {
                    
                    updateStatus.Invoke((MethodInvoker)delegate {
                        updateStatus.Text = "Download completed ... extracting minimap-with-markers.zip";
                    });

                    updateProgress.Invoke((MethodInvoker)delegate {
                        updateProgress.Value = 100;
                    });

                    Thread.Sleep(new Random().Next(1000, 1250));

                    completedEvent.Set();

                };

                webclient.DownloadProgressChanged += (s, e) => {

                    updateStatus.Invoke((MethodInvoker)delegate {
                        updateStatus.Text = String.Format("Downloading minimap-with-markers.zip .... {0} / {1} ({2}%)", Tools.GetSizeString(e.BytesReceived), Tools.GetSizeString(e.TotalBytesToReceive), e.ProgressPercentage);
                    });

                    updateProgress.Invoke((MethodInvoker)delegate {
                        updateProgress.Value = e.ProgressPercentage;
                    });

                };

                webclient.DownloadFileAsync(new Uri("https://tibiamaps.io/downloads/minimap-with-markers"), Program.tibiaMapsFile);
                completedEvent.Wait();

            }

            this.Invoke((MethodInvoker)delegate {
                this.Close();
            });

        }

    }

}
