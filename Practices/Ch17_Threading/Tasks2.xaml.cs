using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ch17_Threading
{
    /// <summary>
    /// Tasks2xaml.xaml 的交互逻辑
    /// </summary>
    public partial class Tasks2 : Window
    {
        //Unit:Schedulers
        //Scheduling a continuation on the UI thread(Example17_20:P641)
        public Tasks2()
        {
            InitializeComponent();
        }

        private TaskScheduler _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();//报一个异常；
        private void FetchButtonClicked(object sender, RoutedEventArgs e)
        {
            var w = new WebClient();
            string url = "http://www.interact-sw.co.uk/iangblog/";
            Task<string> webGetTask = w.DownloadStringTaskAsync(url);
            webGetTask.ContinueWith(t =>
            {
                string webContent = t.Result;
                outputTextBox.Text = webContent;
            },
            _uiScheduler);
        }
    }
}
