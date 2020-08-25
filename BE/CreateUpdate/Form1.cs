using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    this.compressDirectory(files);
                    this.Run();
                }
            }
        }
        private void Run()
        {
            Process process = new Process();
            process.StartInfo.FileName = $"C:\\xampp\\htdocs\\update\\Update.exe";
            process.Start();
            process.WaitForExit();
            MessageBox.Show("Tạo bản cập nhật thành công!");

        }
        private int version()
        {
            var directory = Directory.GetDirectories(@"C:\xampp\htdocs\update\DATA").Select(x => new DirectoryInfo(x)).ToArray();
            return Convert.ToInt32(directory.LastOrDefault().Name);
        }
        private void compressDirectory(string[] filenames)
        {
            try
            {
                var zipName = Guid.NewGuid().ToString();
                var version = this.version();
                var path = $"C:\\xampp\\htdocs\\update\\DATA\\{version + 1}";
                var OutputFilePath = $"{path}\\{zipName}.zip";
                Directory.CreateDirectory(path);
                int CompressionLevel = 9;
                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.

                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
                {
                    OutputStream.Password = zipName;
                    // Define the compression level
                    // 0 - store only to 9 - means best compression
                    OutputStream.SetLevel(CompressionLevel);

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {

                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        OutputStream.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;

                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                OutputStream.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    OutputStream.Finish();

                    // Close is important to wrap things up and unlock the file.
                    OutputStream.Close();

                }
            }
            catch (Exception ex)
            {
                // No need to rethrow the exception as for our purposes its handled.
                MessageBox.Show(ex.Message);
            }
        }

    }
}
