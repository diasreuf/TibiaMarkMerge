namespace TibiaMarkerMerge
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            MergeButton = new Button();
            openFileDialog = new OpenFileDialog();
            backupMarkers = new CheckBox();
            updateMinimap = new CheckBox();
            labelLogo = new Label();
            reuforgediLabel = new Label();
            labelDesc1 = new Label();
            labelDesc2 = new Label();
            labelDesc3 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // MergeButton
            // 
            MergeButton.Location = new Point(15, 198);
            MergeButton.Name = "MergeButton";
            MergeButton.Size = new Size(220, 36);
            MergeButton.TabIndex = 2;
            MergeButton.Text = "Update Map Markers";
            MergeButton.UseVisualStyleBackColor = true;
            MergeButton.Click += MergeButton_Click;
            // 
            // backupMarkers
            // 
            backupMarkers.AutoSize = true;
            backupMarkers.Checked = true;
            backupMarkers.CheckState = CheckState.Checked;
            backupMarkers.Location = new Point(6, 7);
            backupMarkers.Name = "backupMarkers";
            backupMarkers.Size = new Size(161, 19);
            backupMarkers.TabIndex = 3;
            backupMarkers.Text = "Backup minimap markers";
            backupMarkers.UseVisualStyleBackColor = true;
            // 
            // updateMinimap
            // 
            updateMinimap.AutoSize = true;
            updateMinimap.Location = new Point(6, 30);
            updateMinimap.Name = "updateMinimap";
            updateMinimap.Size = new Size(139, 19);
            updateMinimap.TabIndex = 4;
            updateMinimap.Text = "Update minimap files";
            updateMinimap.UseVisualStyleBackColor = true;
            // 
            // labelLogo
            // 
            labelLogo.AutoSize = true;
            labelLogo.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelLogo.Location = new Point(16, 9);
            labelLogo.Name = "labelLogo";
            labelLogo.Size = new Size(165, 18);
            labelLogo.TabIndex = 5;
            labelLogo.Text = "Tibia Minimap Update";
            // 
            // reuforgediLabel
            // 
            reuforgediLabel.AutoSize = true;
            reuforgediLabel.Cursor = Cursors.Hand;
            reuforgediLabel.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            reuforgediLabel.Location = new Point(18, 27);
            reuforgediLabel.Name = "reuforgediLabel";
            reuforgediLabel.Size = new Size(87, 13);
            reuforgediLabel.TabIndex = 6;
            reuforgediLabel.Text = "by Reuforgedi";
            reuforgediLabel.Click += reuforgediLabel_Click;
            // 
            // labelDesc1
            // 
            labelDesc1.AutoSize = true;
            labelDesc1.Location = new Point(17, 52);
            labelDesc1.Name = "labelDesc1";
            labelDesc1.Size = new Size(213, 15);
            labelDesc1.TabIndex = 7;
            labelDesc1.Text = "Update your minimap files, and merge ";
            // 
            // labelDesc2
            // 
            labelDesc2.AutoSize = true;
            labelDesc2.Location = new Point(17, 67);
            labelDesc2.Name = "labelDesc2";
            labelDesc2.Size = new Size(223, 15);
            labelDesc2.TabIndex = 8;
            labelDesc2.Text = "your current map markers with new ones";
            // 
            // labelDesc3
            // 
            labelDesc3.AutoSize = true;
            labelDesc3.Location = new Point(16, 83);
            labelDesc3.Name = "labelDesc3";
            labelDesc3.Size = new Size(140, 15);
            labelDesc3.TabIndex = 9;
            labelDesc3.Text = "provided by TibiaMaps.io";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(16, 109);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(221, 83);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(backupMarkers);
            tabPage1.Controls.Add(updateMinimap);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(213, 55);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Options";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 246);
            Controls.Add(tabControl1);
            Controls.Add(labelDesc3);
            Controls.Add(labelDesc2);
            Controls.Add(labelDesc1);
            Controls.Add(reuforgediLabel);
            Controls.Add(labelLogo);
            Controls.Add(MergeButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tibia Map Update";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MergeButton;
        private OpenFileDialog openFileDialog;
        private ListBox updateLog;
        private CheckBox backupMarkers;
        private CheckBox updateMinimap;
        private Label labelLogo;
        private Label reuforgediLabel;
        private Label labelDesc1;
        private Label labelDesc2;
        private Label labelDesc3;
        private TabControl tabControl1;
        private TabPage tabPage1;
    }
}