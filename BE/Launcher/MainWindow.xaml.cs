using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Documents;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker Worker { get; set; }
        private HttpClient Http { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private string BaseAddress = "http://admin.ranonlinevn.com";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Worker = new BackgroundWorker();
            this.Http = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };

            this.Worker.DoWork += Worker_DoWork;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.ProgressChanged += Worker_ProgressChanged;


            FlowDocument myFlowDoc = new FlowDocument();

            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));

            this.Worker.RunWorkerAsync();

            

        }
        

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
                    using (var w = new StreamWriter(pathVersion))
                    {
                        w.Write(1);
                        return 1L;
                    }
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
                version += 1;
                return this.CalcDownload(data,ref version, result);
            }
            return result;
        }
        private void DownloadFile(List<FileInfomaion> files, int next)
        {
            if (next == files.Count)
                return;
            var file = files[next];
            if (!Directory.Exists(file.Folder))
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
                    this.UpdateProgresText(file.Name + "\n");
                    this.DownloadFile(files, ++next);
                };
                wc.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
                {
                    this.UpdateGTotal(e.BytesReceived);
                };
                var task = wc.DownloadFileTaskAsync(new Uri($"{this.BaseAddress}{file.Path}"), file.Location);
                task.Wait();
            }
        }


        private long TotalSize { get; set; }
        private long CurrentSize { get; set; }
        private void UpdateGTotal(long current)
        {
            this.gTotal.Dispatcher.Invoke(() =>
            {
                this.gTotal.Value += current;
            });
        }
        private  void UpdateMaxGTotal(long max)
        {
            this.gTotal.Dispatcher.Invoke(() =>
            {
                this.gTotal.Maximum = max;
            });
        }
        private void UpdateProgresText(string text)
        {
            this.rtbData.Dispatcher.Invoke(() =>
            {
                this.rtbData.AppendText(text);
                this.rtbData.ScrollToEnd();

            });
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var update = this.GetUpdate();
            var version = this.GetVersion();
            var listLink = this.CalcDownload(update,ref version, new FileEntity());
            this.UpdateMaxGTotal(listLink.TotalSize);
            this.DownloadFile(listLink.Files,0);
        }
    }
}
