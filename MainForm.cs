using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WLMToPst
{
    public partial class MainForm : Form
    {
        private PSTGenerator generator;
        private Thread conversionThread;

        public MainForm()
        {
            InitializeComponent();
            CheckConvertButtonEnabled();

            generator = new PSTGenerator();
        }

        private void btSelectInputFolder_Click(object sender, EventArgs e)
        {
            using (var wldDirBrowser = new FolderBrowserDialog())
            {
                wldDirBrowser.SelectedPath = Directory.GetCurrentDirectory();
                DialogResult result = wldDirBrowser.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(wldDirBrowser.SelectedPath))
                {
                    tbInputFolder.Text = wldDirBrowser.SelectedPath;
                }
                CheckConvertButtonEnabled();
            }
        }

        private void btSelectOutputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog wldPSTFileBrowser = new OpenFileDialog();
            wldPSTFileBrowser.InitialDirectory = Directory.GetCurrentDirectory();
            wldPSTFileBrowser.Title = "Save to PST file";
            wldPSTFileBrowser.CheckFileExists = false;
            wldPSTFileBrowser.CheckPathExists = true;
            wldPSTFileBrowser.DefaultExt = "pst";
            wldPSTFileBrowser.Filter = "Outlook PST files (*.pst)|*.pst|All files (*.*)|*.*";
            wldPSTFileBrowser.FilterIndex = 1;
            wldPSTFileBrowser.RestoreDirectory = true;
            wldPSTFileBrowser.ReadOnlyChecked = true;
            wldPSTFileBrowser.ShowReadOnly = true;

            if (wldPSTFileBrowser.ShowDialog() == DialogResult.OK)
            {
                tbOutputFile.Text = wldPSTFileBrowser.FileName;
            }

            CheckConvertButtonEnabled();
        }

        private void bnConvert_Click(object sender, EventArgs e)
        {
            if (conversionThread != null)
            {
                conversionThread.Abort();
                conversionThread = null;
            }

            conversionThread = new Thread(BeginConversion) { Name = "MainConversionThread" };
            CheckConvertButtonEnabled();
            conversionThread.Start();
        }

        private void BeginConversion()
        {
            string outputPstFullPath = Path.Combine(Directory.GetCurrentDirectory(), "testpst_" + new Random(Utils.ToUnixTimeInt(DateTime.Now)).Next(100, 1000) + ".pst");
            generator = new PSTGenerator();
            generator.UpdateConvertionThreadProgressHandler += UpdateConvertionThreadProgress;
            //generator.CreatePSTFromWindowsLiveMailFolder(outputPstFullPath, @"f:\_Backups_\Tiny\Users\Gebruiker\Windows Live Mail\Kpnmail (MH ab2\");
            generator.CreatePSTFromWindowsLiveMailFolder(tbOutputFile.Text, tbInputFolder.Text);
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(this, "Finished!");
                    conversionThread = null;
                    CheckConvertButtonEnabled();
                }));
            }
        }
        private void UpdateConvertionThreadProgress(float i, float total)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<float, float>(UpdateConvertionThreadProgress), new object[] { i, total });
                return;
            }
            
            pbMainProgress.Value = Math.Min((int)i, 100);
        }
        private void tbInputFolder_TextChanged(object sender, EventArgs e)
        {
            CheckConvertButtonEnabled();
        }

        private void tbOutputFile_TextChanged(object sender, EventArgs e)
        {
            CheckConvertButtonEnabled();
        }

        private void CheckConvertButtonEnabled()
        {
            bool inputDirValid = false;
            bool outputFileValid = false;
            try
            {
                var fileName = Path.GetFileName(tbOutputFile.Text);
                var fileExtension = Path.GetExtension(tbOutputFile.Text);
                inputDirValid = Directory.Exists(tbInputFolder.Text);
                outputFileValid = Directory.Exists(new FileInfo(tbOutputFile.Text).Directory.FullName) && string.IsNullOrEmpty(fileName) == false && string.IsNullOrEmpty(fileExtension) == false;
            } catch{}
            bnConvert.Enabled = conversionThread == null && inputDirValid && outputFileValid;
        }

    }
}
