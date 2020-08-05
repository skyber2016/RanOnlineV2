using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private WebClient Client { get; set; }
        private BackgroundWorker Worker { get; set; }
        private string BaseAddress
        {
            get
            {
                return "http://admin.ranonlinevn.com";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Client = new WebClient();
            this.Worker = new BackgroundWorker();
            this.Worker.DoWork += Worker_DoWork;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Launcher.exe";
            p.Start();
            Environment.Exit(0);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var hash = this.Client.DownloadString(this.BaseAddress + "/update/" + "Launcher.json");
            var pathLauncher = "Launcher.exe";
            if (!File.Exists(pathLauncher))
            {
                this.DownloadFile(pathLauncher);
            }
            else
            {
                var hashFile = Hash(pathLauncher);
                if (hashFile != hash)
                {
                    this.DownloadFile(pathLauncher);
                }
            }
        }
        private string Hash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash =  md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                }
            }
        }
        private void DownloadFile(string pathLauncher)
        {
            this.Client.DownloadProgressChanged += Client_DownloadProgressChanged;
            var task = this.Client.DownloadFileTaskAsync(this.BaseAddress + "/update/" + pathLauncher, pathLauncher);
            task.Wait();
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Invoke(new Action(() =>
            {
                this.progressBar1.Value = e.ProgressPercentage;
            }));
        }
    }
}
