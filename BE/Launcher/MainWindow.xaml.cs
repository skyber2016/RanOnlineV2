using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Worker = new BackgroundWorker();
            this.Http = new HttpClient()
            {
                BaseAddress = new Uri("http://admin.ranonlinevn.com")
            };
            this.Worker.DoWork += Worker_DoWork;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.ProgressChanged += Worker_ProgressChanged;
            this.Worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private IDictionary<string,IEnumerable<FileEntity>> GetUpdate()
        {
            var jsonState = this.Http.GetAsync("/update/update.json");
            jsonState.Wait();
            var jsonString = jsonState.Result.Content.ReadAsStringAsync();
            jsonString.Wait();
            return JsonConvert.DeserializeObject<IDictionary<string, IEnumerable<FileEntity>>>(jsonString.Result);
        }
        private string GetVersion()
        {
            var pathVersion = "version.dat";
            if (!File.Exists(pathVersion))
            {
                using(var w = new StreamWriter(pathVersion))
                {
                    w.Write(1);
                    return "1";
                }
            }
            else
            {
                var version = File.ReadAllText(pathVersion);
                if (string.IsNullOrWhiteSpace(version))
                {
                    version = "1";
                }
                return version;
            }

        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var update = this.GetUpdate();
            var version = this.GetVersion();
        }
    }
}
