using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;
namespace Win_UEFİ_Bootable_USB_Maker
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        string path = "";
       void list_RemovableDevices()
        {
            metroComboBox_Devices.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady == true)
                {  
                    metroComboBox_Devices.Items.Add(drive.Name+drive.VolumeLabel);
                    path = drive.Name;
                }
            }
           
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            list_RemovableDevices();
    
        }

        private void metroButton_BrowseFolder_Click(object sender, EventArgs e)
        {

            if (metroRadioButton_İmage.Checked == true)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "İmage File |*.iso";
                file.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                file.Multiselect = false;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    textBox_Browse.Text = file.FileName;
                }

             }
            else
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.SelectedPath = Environment.SpecialFolder.Desktop.ToString();
                if (folder.ShowDialog()==DialogResult.OK)
                {
                    textBox_Browse.Text = folder.SelectedPath;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            list_RemovableDevices();
        }

        private void metroButton_Burn_Click(object sender, EventArgs e)
        {
            string error = "You must fill in the fields below:\n";
            try
            {
                if (metroComboBox_Devices.SelectedItem.ToString()=="")
                {
                    error += "\n -Device";
                }
            }
            catch (NullReferenceException)//Check NullReference exception error
            {
                error += "\n -Device";
            }
            finally
            {
                if (textBox_Browse.Text == "")
                {
                    error += "\n -Source";
                }
                if (error != "You must fill in the fields below:\n")//İF there is error 
                {
                    MetroMessageBox.Show(this, error, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    Process p = new Process();
                    p.StartInfo.FileName = Environment.SystemDirectory + @"\diskpart.exe";
                    p.StartInfo.UseShellExecute = false;                         
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    metroLabel_Status.Text = "Status : Starting";
                    p.Start();
                    metroLabel_Status.Text = "Status : Selecting disk";
                    MessageBox.Show("Select disk " );
                    p.StandardInput.WriteLine("Select disk ");
                    metroLabel_Status.Text = "Status : Cleaning";
                    p.StandardInput.WriteLine("clean");
                    metroLabel_Status.Text = "Status : Creating partition";
                    p.StandardInput.WriteLine("create partition primary");
                    metroLabel_Status.Text = "Status : Formatting";
                    p.StandardInput.WriteLine("format quick fs=fat32");
                    p.StandardInput.WriteLine("active");
                    metroLabel_Status.Text = "Status : Activating";
                    p.StandardInput.WriteLine("assign");
                    metroLabel_Status.Text = "Status : Assigning";
                    p.StandardInput.WriteLine("exit");
                    string output = p.StandardOutput.ReadToEnd();                 // Places the output to a variable
                    p.WaitForExit();
                    MessageBox.Show(output);
                }
            }     
        }

        private void metroCheckBox_Accept_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox_Accept.Checked == true)
            {
                metroButton_Burn.Enabled = true;
            }
            else
            {
                metroButton_Burn.Enabled = false;
            }
        }

        private void metroComboBox_Devices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskPartition.serialnumber=(SELECT * FROM win32_logicaldisk.deviceid=\"" + path + "");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    MessageBox.Show(queryObj["Type"].ToString());
                    if (queryObj["Name"].ToString()==metroComboBox_Devices.Text)
                    {
                        MessageBox.Show("no:" + (int.Parse(queryObj["DiskIndex"].ToString())));
                    }
                   
                }
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + err.Message);
            }

        }
    }
}
