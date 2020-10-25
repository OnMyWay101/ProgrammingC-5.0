using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += FetchButtonClicked;
        }

        private TaskScheduler _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private void FetchButtonClicked(object sender, RoutedEventArgs e)
        {
            var w = new WebClient();
            string url = "http://www.interact-sw.co.uk/iangblog/";
            Task<string> webGetTask = w.DownloadStringTaskAsync(url);
            webGetTask.ContinueWith(t =>
            {
                string webContent = t.Result;
                textBox.Text = webContent;
            },
            _uiScheduler);
        }
    }
}
