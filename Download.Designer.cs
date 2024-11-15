namespace TibiaMarkerMerge
{
    partial class Download
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Download));
            headerBackground = new PictureBox();
            updateImage = new PictureBox();
            updateText1 = new Label();
            updateText2 = new Label();
            updateText3 = new Label();
            updateStatus = new Label();
            updateProgress = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)headerBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)updateImage).BeginInit();
            SuspendLayout();
            // 
            // headerBackground
            // 
            headerBackground.Location = new Point(0, 0);
            headerBackground.Name = "headerBackground";
            headerBackground.Size = new Size(549, 80);
            headerBackground.TabIndex = 0;
            headerBackground.TabStop = false;
            // 
            // updateImage
            // 
            updateImage.InitialImage = null;
            updateImage.Location = new Point(478, 7);
            updateImage.Name = "updateImage";
            updateImage.Size = new Size(64, 64);
            updateImage.TabIndex = 1;
            updateImage.TabStop = false;
            // 
            // updateText1
            // 
            updateText1.AutoSize = true;
            updateText1.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            updateText1.Location = new Point(12, 9);
            updateText1.Name = "updateText1";
            updateText1.Size = new Size(164, 16);
            updateText1.TabIndex = 2;
            updateText1.Text = "Downloading Updates";
            // 
            // updateText2
            // 
            updateText2.AutoSize = true;
            updateText2.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            updateText2.Location = new Point(12, 25);
            updateText2.Name = "updateText2";
            updateText2.Size = new Size(289, 13);
            updateText2.TabIndex = 3;
            updateText2.Text = "Please wait while the updater search for updates.";
            // 
            // updateText3
            // 
            updateText3.AutoSize = true;
            updateText3.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            updateText3.Location = new Point(12, 38);
            updateText3.Name = "updateText3";
            updateText3.Size = new Size(444, 13);
            updateText3.TabIndex = 4;
            updateText3.Text = "This may take several minutes because it is based on your download speed.";
            // 
            // updateStatus
            // 
            updateStatus.Location = new Point(15, 90);
            updateStatus.Name = "updateStatus";
            updateStatus.Size = new Size(520, 15);
            updateStatus.TabIndex = 5;
            updateStatus.Text = "Connecting to update server ...";
            // 
            // updateProgress
            // 
            updateProgress.Location = new Point(15, 111);
            updateProgress.Name = "updateProgress";
            updateProgress.Size = new Size(522, 30);
            updateProgress.TabIndex = 6;
            // 
            // Download
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 157);
            Controls.Add(updateProgress);
            Controls.Add(updateStatus);
            Controls.Add(updateText3);
            Controls.Add(updateText2);
            Controls.Add(updateText1);
            Controls.Add(updateImage);
            Controls.Add(headerBackground);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Download";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Checking for Updates";
            ((System.ComponentModel.ISupportInitialize)headerBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)updateImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox headerBackground;
        private PictureBox updateImage;
        private Label updateText1;
        private Label updateText2;
        private Label updateText3;
        private Label updateStatus;
        private ProgressBar updateProgress;
    }
}