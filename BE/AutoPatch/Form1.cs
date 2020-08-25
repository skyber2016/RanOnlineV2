using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
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
            p.StartInfo.FileName = "Patcher.exe";
            p.StartInfo.Arguments = Guid.NewGuid().ToString();
            p.Start();
            Environment.Exit(0);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var hash = this.Client.DownloadString(this.BaseAddress + "/update/" + "Launcher.json");
            var pathLauncher = "Patcher.exe";
            var pathLauncherZip = "Patcher.zip";
            if (!File.Exists(pathLauncher))
            {
                this.DownloadFile(pathLauncherZip);
            }
            else
            {
                var hashFile = Hash(pathLauncher);
                if (hashFile != hash)
                {
                    this.DownloadFile(pathLauncherZip);
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
            this.UnZip(pathLauncher);
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar1.Invoke(new Action(() =>
            {
                this.progressBar1.Value = e.ProgressPercentage;
            }));
        }

        private void UnZip(string pathToZip)
        {
            var file = new FileInfo(pathToZip);
            using (ZipFile archive = new ZipFile(file.OpenRead()))
            {
                archive.Password = "nhduy";
                foreach (ZipEntry zipEntry in archive)
                {
                    try
                    {
                        if (!zipEntry.IsFile)
                        {
                            // Ignore directories
                            continue;
                        }
                        String entryFileName = zipEntry.Name;
                        // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                        // Optionally match entrynames against a selection list here to skip as desired.
                        // The unpacked length is available in the zipEntry.Size property.
                        // 4K is optimum
                        byte[] buffer = new byte[4096];
                        Stream zipStream = archive.GetInputStream(zipEntry);

                        // Manipulate the output filename here as desired.
                        String fullZipToPath = Path.Combine(Directory.GetCurrentDirectory(), entryFileName);
                        string directoryName = Path.GetDirectoryName(fullZipToPath);

                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                        // of the file, but does not waste memory.
                        // The "using" will close the stream even if an exception occurs.
                        using (FileStream streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
                        
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            File.Delete(pathToZip);
        }
    }
}
