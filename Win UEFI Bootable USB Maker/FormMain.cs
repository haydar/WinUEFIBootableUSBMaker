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
using DiscUtils;
using DiscUtils.Iso9660;


namespace Win_UEFİ_Bootable_USB_Maker
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        string path = "";
        string diskNo = "";

    

    void ExtractISO(string ISOName, string ExtractionPath)
    {
        using (FileStream ISOStream = File.Open(ISOName, FileMode.Open))
        {
            CDReader Reader = new CDReader(ISOStream, true, true);
            ExtractDirectory(Reader.Root, ExtractionPath + Path.GetFileNameWithoutExtension(ISOName) + "\\", "");
            Reader.Dispose();
        }
    }
    void ExtractDirectory(DiscDirectoryInfo Dinfo, string RootPath, string PathinISO)
    {
        if (!string.IsNullOrWhiteSpace(PathinISO))
        {
            PathinISO += "\\" + Dinfo.Name;
        }
        RootPath += "\\" + Dinfo.Name;
        AppendDirectory(RootPath);
        foreach (DiscDirectoryInfo dinfo in Dinfo.GetDirectories())
        {
            ExtractDirectory(dinfo, RootPath, PathinISO);
        }
        foreach (DiscFileInfo finfo in Dinfo.GetFiles())
        {
            using (Stream FileStr = finfo.OpenRead())
            {
                using (FileStream Fs = File.Create(RootPath + "\\" + finfo.Name)) // Here you can Set the BufferSize Also e.g. File.Create(RootPath + "\\" + finfo.Name, 4 * 1024)
                {
                    FileStr.CopyTo(Fs, 4 * 1024); // Buffer Size is 4 * 1024 but you can modify it in your code as per your need
                }
            }
        }
    }
    static void AppendDirectory(string path)
    {
        try
        {
            if (!Directory.Exists(path))
            {
                    Directory.CreateDirectory(path);
            }
        }
        catch (DirectoryNotFoundException Ex)
        {
            AppendDirectory(Path.GetDirectoryName(path));
        }
        catch (PathTooLongException Exx)
        {
            AppendDirectory(Path.GetDirectoryName(path));
        }
    }


    void list_RemovableDevices()
        {
            metroComboBox_Devices.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady == true)
                {  
                    metroComboBox_Devices.Items.Add(drive.Name+drive.VolumeLabel);
                    
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
                if (error != "You must fill in the fields below:\n")//İf there is error 
                {
                    MetroMessageBox.Show(this, error, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    #region CommandProcessesOfDiskpart
                    Process p = new Process();
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.FileName = Environment.SystemDirectory + @"\diskpart.exe";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardInput = true;
                    metroLabel_Status.Text = "Status : Starting";
                    p.Start();
                    metroLabel_Status.Text = "Status : Selecting disk";
                    MessageBox.Show("Select disk " + diskNo);
                    p.StandardInput.WriteLine("Select disk " + diskNo);
                    metroLabel_Status.Text = "Status : Cleaning";
                    p.StandardInput.WriteLine("clean");
                    metroLabel_Status.Text = "Status : Creating partition";
                    p.StandardInput.WriteLine("create partition primary");
                    metroLabel_Status.Text = "Status : Formatting";
                    p.StandardInput.WriteLine("format quick fs=fat32");
                    metroLabel_Status.Text = "Status : Activating";
                    p.StandardInput.WriteLine("active");
                    metroLabel_Status.Text = "Status : Assigning";
                    p.StandardInput.WriteLine("assign");
                    p.StandardInput.WriteLine("exit");
                    p.WaitForExit();
                    metroLabel_Status.Text = "Status : Prepering Device for Copying Installer Files ";
                    #endregion
                    if (metroRadioButton_İmage.Checked==true)
                    {
                        MessageBox.Show(textBox_Browse.Text+" dd "+path);
                      
                        ExtractISO(@""+textBox_Browse.Text,path+@"\\");
                    }


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
            #region findPath
            string tempPath = metroComboBox_Devices.Text;
            path = tempPath.Remove(2, 1);
            MessageBox.Show(path);
            #endregion

            #region findDiskIndex  
            try //Finding DiskIndex used by WQL (Sql for WMI) here
            {
                var searcher = new ManagementObjectSearcher(@"select * from Win32_DiskDrive");
                foreach (ManagementObject disk in searcher.Get())
                {
                    var query = string.Format(@"ASSOCIATORS OF 
                    {{Win32_DiskDrive.DeviceID='{0}'}}
                    WHERE AssocClass = Win32_DiskDriveToDiskPartition",
                    disk.Properties["DeviceID"].Value);
                    foreach (ManagementObject diskPartition in new ManagementObjectSearcher(query).Get())
                    {
                        var query2 = string.Format(@"ASSOCIATORS OF 
                        {{Win32_DiskPartition.DeviceID='{0}'}}
                        WHERE AssocClass = Win32_LogicalDiskToPartition",
                        diskPartition.Properties["DeviceId"].Value);

                        foreach (ManagementObject logicalDisk in new ManagementObjectSearcher(query2).Get())
                        {
                            if (path == logicalDisk.Properties["DeviceID"].Value.ToString())
                            {
                                string tempDiskNo=diskPartition.Properties["DeviceId"].Value.ToString();
                                diskNo = tempDiskNo[6].ToString();//there is DiskIndex on 6th Index 
                                MessageBox.Show(diskNo);
                            }       
                        }
                    }
                }
               
            }
           
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + err.Message);
            }

            #endregion
        }
    }
}
