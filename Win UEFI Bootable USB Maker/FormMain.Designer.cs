namespace Win_UEFİ_Bootable_USB_Maker
{
    partial class FormMain
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
            this.metroLabel_Devices = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox_Devices = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel_SourceFolder = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.textBox_Browse = new System.Windows.Forms.TextBox();
            this.metroButton_BrowseFolder = new MetroFramework.Controls.MetroButton();
            this.metroCheckBox_Accept = new MetroFramework.Controls.MetroCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroRadioButton_Folder = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton_İmage = new MetroFramework.Controls.MetroRadioButton();
            this.metroButton_Burn = new MetroFramework.Controls.MetroButton();
            this.metroLabel_Status = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel_Devices
            // 
            this.metroLabel_Devices.AutoSize = true;
            this.metroLabel_Devices.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_Devices.Location = new System.Drawing.Point(27, 106);
            this.metroLabel_Devices.Name = "metroLabel_Devices";
            this.metroLabel_Devices.Size = new System.Drawing.Size(106, 19);
            this.metroLabel_Devices.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel_Devices.TabIndex = 0;
            this.metroLabel_Devices.Text = "Device            :";
            // 
            // metroComboBox_Devices
            // 
            this.metroComboBox_Devices.FormattingEnabled = true;
            this.metroComboBox_Devices.ItemHeight = 23;
            this.metroComboBox_Devices.Location = new System.Drawing.Point(155, 100);
            this.metroComboBox_Devices.Name = "metroComboBox_Devices";
            this.metroComboBox_Devices.Size = new System.Drawing.Size(160, 29);
            this.metroComboBox_Devices.TabIndex = 1;
            this.metroComboBox_Devices.UseSelectable = true;
            this.metroComboBox_Devices.SelectedIndexChanged += new System.EventHandler(this.metroComboBox_Devices_SelectedIndexChanged);
            // 
            // metroLabel_SourceFolder
            // 
            this.metroLabel_SourceFolder.AutoSize = true;
            this.metroLabel_SourceFolder.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel_SourceFolder.Location = new System.Drawing.Point(27, 209);
            this.metroLabel_SourceFolder.Name = "metroLabel_SourceFolder";
            this.metroLabel_SourceFolder.Size = new System.Drawing.Size(103, 19);
            this.metroLabel_SourceFolder.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel_SourceFolder.TabIndex = 0;
            this.metroLabel_SourceFolder.Text = "Source           :";
            // 
            // textBox_Browse
            // 
            this.textBox_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_Browse.Location = new System.Drawing.Point(155, 204);
            this.textBox_Browse.Name = "textBox_Browse";
            this.textBox_Browse.Size = new System.Drawing.Size(160, 29);
            this.textBox_Browse.TabIndex = 2;
            // 
            // metroButton_BrowseFolder
            // 
            this.metroButton_BrowseFolder.Location = new System.Drawing.Point(335, 204);
            this.metroButton_BrowseFolder.Name = "metroButton_BrowseFolder";
            this.metroButton_BrowseFolder.Size = new System.Drawing.Size(111, 29);
            this.metroButton_BrowseFolder.TabIndex = 4;
            this.metroButton_BrowseFolder.Text = "Browse...";
            this.metroButton_BrowseFolder.UseSelectable = true;
            this.metroButton_BrowseFolder.Click += new System.EventHandler(this.metroButton_BrowseFolder_Click);
            // 
            // metroCheckBox_Accept
            // 
            this.metroCheckBox_Accept.AutoSize = true;
            this.metroCheckBox_Accept.Checked = true;
            this.metroCheckBox_Accept.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox_Accept.Location = new System.Drawing.Point(155, 297);
            this.metroCheckBox_Accept.Name = "metroCheckBox_Accept";
            this.metroCheckBox_Accept.Size = new System.Drawing.Size(191, 15);
            this.metroCheckBox_Accept.TabIndex = 6;
            this.metroCheckBox_Accept.Text = "I accept to erase all files on disk ";
            this.metroCheckBox_Accept.UseSelectable = true;
            this.metroCheckBox_Accept.CheckedChanged += new System.EventHandler(this.metroCheckBox_Accept_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Win_UEFİ_Bootable_USB_Maker.Properties.Resources.refresh_icon;
            this.pictureBox1.Location = new System.Drawing.Point(335, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 161);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(252, 38);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Take  Windows İnstall Source Files From\r\n";
            // 
            // metroRadioButton_Folder
            // 
            this.metroRadioButton_Folder.AutoSize = true;
            this.metroRadioButton_Folder.Location = new System.Drawing.Point(281, 163);
            this.metroRadioButton_Folder.Name = "metroRadioButton_Folder";
            this.metroRadioButton_Folder.Size = new System.Drawing.Size(94, 15);
            this.metroRadioButton_Folder.TabIndex = 10;
            this.metroRadioButton_Folder.Text = "Folder / Drive";
            this.metroRadioButton_Folder.UseSelectable = true;
            // 
            // metroRadioButton_İmage
            // 
            this.metroRadioButton_İmage.AutoSize = true;
            this.metroRadioButton_İmage.Checked = true;
            this.metroRadioButton_İmage.Location = new System.Drawing.Point(390, 163);
            this.metroRadioButton_İmage.Name = "metroRadioButton_İmage";
            this.metroRadioButton_İmage.Size = new System.Drawing.Size(77, 15);
            this.metroRadioButton_İmage.TabIndex = 11;
            this.metroRadioButton_İmage.TabStop = true;
            this.metroRadioButton_İmage.Text = "İmage File";
            this.metroRadioButton_İmage.UseSelectable = true;
            // 
            // metroButton_Burn
            // 
            this.metroButton_Burn.Location = new System.Drawing.Point(178, 380);
            this.metroButton_Burn.Name = "metroButton_Burn";
            this.metroButton_Burn.Size = new System.Drawing.Size(125, 35);
            this.metroButton_Burn.TabIndex = 13;
            this.metroButton_Burn.Text = "Burn";
            this.metroButton_Burn.UseSelectable = true;
            this.metroButton_Burn.Click += new System.EventHandler(this.metroButton_Burn_Click);
            // 
            // metroLabel_Status
            // 
            this.metroLabel_Status.AutoSize = true;
            this.metroLabel_Status.Location = new System.Drawing.Point(178, 349);
            this.metroLabel_Status.Name = "metroLabel_Status";
            this.metroLabel_Status.Size = new System.Drawing.Size(102, 19);
            this.metroLabel_Status.TabIndex = 15;
            this.metroLabel_Status.Text = "Status : Waiting ";
            // 
            // FormMain
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(490, 438);
            this.Controls.Add(this.metroLabel_Status);
            this.Controls.Add(this.metroButton_Burn);
            this.Controls.Add(this.metroRadioButton_İmage);
            this.Controls.Add(this.metroRadioButton_Folder);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroCheckBox_Accept);
            this.Controls.Add(this.metroButton_BrowseFolder);
            this.Controls.Add(this.textBox_Browse);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroComboBox_Devices);
            this.Controls.Add(this.metroLabel_SourceFolder);
            this.Controls.Add(this.metroLabel_Devices);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(456, 337);
            this.Name = "FormMain";
            this.Text = "Windows UEFİ Bootable USB Maker";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel_Devices;
        private MetroFramework.Controls.MetroComboBox metroComboBox_Devices;
        private MetroFramework.Controls.MetroLabel metroLabel_SourceFolder;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.TextBox textBox_Browse;
        private MetroFramework.Controls.MetroButton metroButton_BrowseFolder;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox_Accept;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton_Folder;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton_İmage;
        private MetroFramework.Controls.MetroButton metroButton_Burn;
        private MetroFramework.Controls.MetroLabel metroLabel_Status;
    }
}

