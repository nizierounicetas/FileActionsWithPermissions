using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2._1
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        private static readonly string ZIP_PROCESS_PATH = "ZipFileProcess.exe";
        private static readonly string HASH_PROCESS_PATH = "HashFileProcess.exe";
        private static readonly string TO_PNG_CONVERSION_PROCESS_PATH = "ToPngConversionProcess.exe";

        private static readonly string[] graphicalExtensions = { ".jpg", ".jpeg", ".gif", ".bmp" };

        private bool fileChosen = false;
        private bool isGraphical = false;
        private MetroCheckBox[] checkboxes;

        public MainWindow()
        {
            InitializeComponent();
          //  ActiveControl = null;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (isAdmin())
            {
                MetroFramework.MetroMessageBox.Show(this, "App is run with admin rights", "Exiting...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            progressSpinner.Spinning = false;
            progressSpinner.Visible = false;
            btnPanel.Focus();
            filePathLbl.Text = "not chosen";
            checkboxes = new MetroCheckBox[]{ zipChB, hashChb, pngChb };
        }

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {
            btnPanel.Focus();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose file";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathLbl.Text = openFileDialog.FileName;
                fileChosen = true;
                isGraphical = Array.IndexOf(graphicalExtensions, Path.GetExtension(openFileDialog.FileName).ToLower()) != -1;

                if (isGraphical)
                {
                    pngChb.Enabled = true;
                }
                else
                {
                    pngChb.Checked = false;
                    pngChb.Enabled = false;
                }
            }

        }

        private async void enableBtn_Click(object sender, EventArgs e)
        {
            btnPanel.Focus();

            if (!fileChosen)
            {
                MetroFramework.MetroMessageBox.Show(this, "Choose a file to enable some actions", "File is not chosen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isChecked = false;
            foreach(var checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    isChecked = true;
                    break;
                }
            }


            if (!isChecked)
            {
                MetroFramework.MetroMessageBox.Show(this, "Choose some actions to process", "Actions are not chosen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Task> processes = new List<Task>();

            progressSpinner.Spinning = true;
            progressSpinner.Visible = true;

            DisableWindow();

            if (zipChB.Checked)
                processes.Add(Task.Run(ZipProcess));

            if (hashChb.Checked)
                processes.Add(Task.Run(HashProcess));

            if (pngChb.Checked)
                processes.Add(Task.Run(PngProcess));

            try
            {
                await Task.WhenAll(processes);
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                progressSpinner.Spinning = false;
                progressSpinner.Visible = false;

                zipChB.Checked = false;
                hashChb.Checked = false;
                pngChb.Checked = false;

                EnableWindow();
            }

        }

       private bool isAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void ZipProcess()
        {
            if (!File.Exists(ZIP_PROCESS_PATH))
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {ZIP_PROCESS_PATH} found", "Zip operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ZIP_PROCESS_PATH;
            startInfo.Arguments = $"\"{filePathLbl.Text}\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();
            process.WaitForExit();

            var code = process.ExitCode;

            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {filePathLbl.Text} found", "Zip operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -3)
            {
                startInfo.Verb = "runas";

                process.Start();
                process.WaitForExit();
                code = process.ExitCode;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Archive: {Path.GetDirectoryName(filePathLbl.Text)}\\{Path.GetFileNameWithoutExtension(filePathLbl.Text)}.zip", "File's zipped succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Some error occured", "Zip operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HashProcess()
        {
            if (!File.Exists(HASH_PROCESS_PATH))
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {HASH_PROCESS_PATH} found", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = HASH_PROCESS_PATH;
            startInfo.Arguments = $"\"{filePathLbl.Text}\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();
            process.WaitForExit();

            var code = process.ExitCode;

            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {filePathLbl.Text} found", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -3)
            {
                startInfo.Verb = "runas";

                process.Start();
                process.WaitForExit();
                code = process.ExitCode;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Hash file: {Path.GetDirectoryName(filePathLbl.Text)}\\{Path.GetFileNameWithoutExtension(filePathLbl.Text)}_hash_sha256", "Hash's saved succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Some error occured", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PngProcess()
        {
            if (!File.Exists(TO_PNG_CONVERSION_PROCESS_PATH))
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {TO_PNG_CONVERSION_PROCESS_PATH} found", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = TO_PNG_CONVERSION_PROCESS_PATH;
            startInfo.Arguments = $"\"{filePathLbl.Text}\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();
            process.WaitForExit();

            var code = process.ExitCode;

            if (code == -2)
            {
                MetroFramework.MetroMessageBox.Show(this, $"No {filePathLbl.Text} found", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -5)
            {
                MetroFramework.MetroMessageBox.Show(this, $"{filePathLbl.Text} already has PNG format", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -6)
            {
                MetroFramework.MetroMessageBox.Show(this, $"{filePathLbl.Text} is not graphical", "Conversion to png failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (code == -3)
            {
                startInfo.Verb = "runas";

                process.Start();
                process.WaitForExit();
                code = process.ExitCode;
            }

            if (code == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, $"Hash file: {Path.GetDirectoryName(filePathLbl.Text)}\\{Path.GetFileNameWithoutExtension(filePathLbl.Text)}_hash_sha256", "Hash's saved succesfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, $"Some error occured", "Hash operation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void hashChb_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void pngChb_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void zipChB_CheckedChanged(object sender, EventArgs e)
        {
            btnPanel.Focus();
        }

        private void DisableWindow()
        {
            chooseFileBtn.Enabled = false;
            enableBtn.Enabled = false;
            zipChB.Enabled = false;
            hashChb.Enabled = false;
            pngChb.Enabled = false;
        }

        private void EnableWindow()
        {
            chooseFileBtn.Enabled = true;
            enableBtn.Enabled = true;
            zipChB.Enabled = true;
            hashChb.Enabled = true;
            if (isGraphical)
                pngChb.Enabled = true;
        }
    }
}
