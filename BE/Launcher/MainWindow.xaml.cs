using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker Worker { get; set; }
        private HttpClient Http { get; set; }
        private Stopwatch Watch { get; set; }
        public MainWindow()
        {
            string[] args = Environment.GetCommandLineArgs();
            var isValid =args.Where(item =>
            {
                Guid guid = Guid.NewGuid();
                var isOk = Guid.TryParse(item, out guid);
                return isOk;
            }).ToArray();
            if(isValid.Length == 0)
            {
                MessageBox.Show("Vui lòng KHÔNG vào game bằng file này!");
                Environment.Exit(0);
            }
            InitializeComponent();
        }

        private string BaseAddress = "https://admin.ranonlinevn.com";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Watch = new Stopwatch();
            this.Worker = new BackgroundWorker();
            this.Http = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };

            this.Worker.DoWork += Worker_DoWork;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.ProgressChanged += Worker_ProgressChanged;
            this.rtbData.Document.LineHeight = 1;

            this.Worker.RunWorkerAsync();
        }
        

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.hasPlayable = true;
            this.Dispatcher.Invoke(() =>
            {
                this.gTotal.IsIndeterminate = false;
                this.gTotal.Value = this.gTotal.Maximum;
                this.gCurrent.Value = this.gCurrent.Maximum;
                this.txtCurrent.Content = "100%";
                this.txtTotal.Content = "100%";
            });
            if (this.IsSuccess) {
                this.speed.Content = "Cập nhật thành công.";
                this.UpdateProgresText($"Đã cập nhật hoàn tất, bạn đã có thể vào game!");
            }
            else
            {
                this.speed.Content = "Cập nhật thất bại.";
                this.UpdateProgresText($"Bản cập nhật này đã xảy ra lỗi, vui lòng thông báo đến Admin để nhận sự trợ giúp. Xin cảm ơn!");
            }
            
        }
        private IDictionary<string, FileEntity> GetUpdate()
        {
            var jsonState = this.Http.GetAsync("/update/update.json");
            jsonState.Wait();
            var jsonString = jsonState.Result.Content.ReadAsStringAsync();
            jsonString.Wait();
            return JsonConvert.DeserializeObject<IDictionary<string, FileEntity>>(jsonString.Result);
        }
        private long GetVersion()
        {
            try
            {
                var pathVersion = "version.dat";
                if (!File.Exists(pathVersion))
                {
                    return 1L;
                }
                else
                {
                    var version = File.ReadAllText(pathVersion);
                    if (string.IsNullOrWhiteSpace(version))
                    {
                        return 1L;
                    }
                    return Convert.ToInt64(version);
                }
            }
            catch (Exception)
            {
                return 1L;
            }
        }
        private FileEntity CalcDownload(IDictionary<string, FileEntity> data,ref long version, FileEntity result)
        {
            if (data.ContainsKey(version.ToString()))
            {
                var dataTmp = data[version.ToString()];
                result.Files.AddRange(dataTmp.Files);
                result.TotalSize += dataTmp.TotalSize;
                result.TotalFile += dataTmp.TotalFile;
                version += 1;
                return this.CalcDownload(data,ref version, result);
            }
            return result;
        }
        private long CurrentSpeed { get; set; }
        private long TotalFile { get; set; } = 1;
        private void DownloadFile(List<FileInfomaion> files, int next)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            if (next == files.Count)
                return;
            var file = files[next];
            try
            {
                
                var currSpeed = 0L;
                if (!Directory.Exists(file.Folder) && file.Folder != "")
                {
                    Directory.CreateDirectory(file.Folder);
                }
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                    {
                        if (e.Error != null)
                        {
                            MessageBox.Show(e.Error.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                        if (file.Name.ToLower().EndsWith(".zip"))
                        {
                            this.UnZip(file.Name);
                        }

                    };
                    wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                    {
                        if(e.BytesReceived > currSpeed)
                        {
                            this.CurrentSpeed += e.BytesReceived - currSpeed;
                        }
                        currSpeed = e.BytesReceived;
                        this.UpdateGCurrent(e.ProgressPercentage);
                    };
                    this.UpdateMaxGCurrent(100);
                    var task = wc.DownloadFileTaskAsync(new Uri($"{this.BaseAddress}{file.Path}"), file.Location);
                    if (file.Name.ToLower().EndsWith(".zip"))
                    {
                        this.UpdateProgresText($"Downloading file {file.Name} ...{Environment.NewLine}");
                    }
                    else
                    {
                        this.UpdateProgresText(file.Location + "\n");
                    }
                    task.Wait();
                    
                    
                    this.DownloadFile(files, ++next);
                }
            }
            catch (Exception ex)
            {
                using (var w = new StreamWriter("error.log", true))
                {
                    w.WriteLine($"[{file.Name}][{ex.Message}]");
                }
                this.IsSuccess = false;
            }
            
        }


        private long TotalSize { get; set; }
        private long CurrentSize { get; set; }
        private long CurrentFile { get; set; }
        private void UpdateGTotal(long current)
        {
            this.gTotal.Dispatcher.Invoke(() =>
            {
                this.gTotal.Value += current;
            });
        }
        private void UpdateGCurrent(long current)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.gCurrent.IsIndeterminate = false;
                this.gCurrent.Value = current;
                this.txtCurrent.Content = $"{current}%";
            });
        }
        private  void UpdateMaxGTotal(long max)
        {
            this.gTotal.Dispatcher.Invoke(() =>
            {
                this.gTotal.Maximum = max;
            });
        }
        private  void UpdateMaxGCurrent(long max)
        {
        }
        private void UpdateProgresText(string text)
        {
            this.rtbData.Dispatcher.Invoke(() =>
            {
                this.rtbData.AppendText(text);
                this.rtbData.ScrollToEnd();

            });
        }
        private IDictionary<string,string> Settings { get; set; }
        private void GetSetting()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var api = "http://api.ranonlinevn.com/setting";
                    var json = client.DownloadString(api);
                    this.Settings = JsonConvert.DeserializeObject<IDictionary<string, string>>(json);
                }
            }
            catch (Exception)
            {
                this.IsSuccess = false;
                MessageBox.Show("CANNOT CONNECT TO SERVER");
                Environment.Exit(1);
            }
           
        }
        private void SettingMainImage()
        {
            
            this.mainImage.Dispatcher.Invoke(() =>
            {
                var img = "main_image";
                if (this.Settings.ContainsKey(img))
                {
                    var fullFilePath = this.Settings[img];

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();
                    this.mainImage.Source = bitmap;
                }
            });
        }
        private bool IsSuccess = true;
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.UnZip(@"D:\my\RanOnlineV2\BE\Launcher\bin\Debug\e4a6d689-62d7-4f7f-888e-dce9a87ce579.zip");
            this.speed.Dispatcher.Invoke(() =>
            {
                this.speed.Content = "Đang kết nối đến máy chủ...";
            });
            this.GetSetting();
            this.SettingMainImage();
            var update = this.GetUpdate();
            var version = this.GetVersion();
            var listLink = this.CalcDownload(update, ref version, new FileEntity());
            this.TotalSize = listLink.TotalSize;
            this.TotalFile = listLink.TotalFile;
            this.UpdateMaxGTotal(listLink.TotalFile);
            var task = this.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.gTotal.IsIndeterminate = false;
                this.gCurrent.IsIndeterminate = false;
            }));
            task.Wait();
            var timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Enabled = true;
            this.DownloadFile(listLink.Files, 0);
            if (this.IsSuccess)
            {
                using (var w = new StreamWriter("version.dat"))
                {
                    w.Write(version);
                }
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.speed.Dispatcher.Invoke(() =>
            {
                if(this.CurrentSpeed <= 1024)
                {
                    this.speed.Content = $"{this.CurrentSpeed} byte/s";
                }
                else
                {
                    var speed = (double)this.CurrentSpeed / 1024;
                    if(speed <= 1024)
                    {
                        this.speed.Content = $"{speed:#.#0} kb/s";
                    }
                    else
                    {
                        speed /= 1024;
                        this.speed.Content = $"{speed:#.#0} mb/s";
                    }
                }
                this.CurrentSpeed = 0;
            });
        }

        private void Image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.hasPlayable)
            {
                this.overlay.Cursor = Cursors.Hand;
                this.overlay.Visibility = Visibility.Visible;
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.overlay.Cursor = Cursors.Arrow;
            this.overlay.Visibility = Visibility.Hidden;
        }


        private void Overlay_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Image_MouseEnter(sender, e);
        }

        private void Overlay_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Image_MouseLeave(sender, e);
        }

        private bool hasPlayable { get; set; }

        private void Overlay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var file = this.Settings["run"];
            var args = this.Settings["run_args"];
            if (File.Exists(file))
            {
                var p = new Process();
                p.StartInfo.FileName = file;
                p.StartInfo.Arguments = args;
                p.Start();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show($"Không tìm thấy file {Directory.GetCurrentDirectory()}\\{file}");
            }
        }
        private void UnZip(string pathToZip)
        {
            var file = new FileInfo(pathToZip);
            using (ZipFile archive = new ZipFile(file.OpenRead()))
            {
                archive.Password = file.Name.Replace(file.Extension,String.Empty);
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
                        this.UpdateProgresText($"Extracting {entryFileName}{Environment.NewLine}");
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
                        this.txtTotal.Dispatcher.Invoke(() =>
                        {
                            if (this.TotalFile == 0)
                            {
                                this.TotalFile = 1;
                            }
                            var per = (double)this.CurrentFile / this.TotalFile * 100;
                            this.txtTotal.Content = (int)per + "%";
                            this.speed.Content = $"{this.CurrentFile} / {this.TotalFile}";
                            this.gTotal.Value = this.CurrentFile;
                            ++this.CurrentFile;
                        });
                    }
                    catch (Exception)
                    {
                        this.IsSuccess = false;
                    }

                }
            }
            
            this.UpdateProgresText($"Cleaning... {Environment.NewLine}");
            File.Delete(pathToZip);
        }
    }
}
