using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;

namespace Ch17_Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = SynchronizationContext.Current;
            Task.Factory.StartNew(() =>
            {
                string pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                var folder = new DirectoryInfo(pictures);
                FileInfo[] allFiles = folder.GetFiles("*.jpg", SearchOption.AllDirectories);
                FileInfo largest = allFiles.OrderByDescending(f => f.Length).FirstOrDefault();

                //uiContext.Post(unusedArg =>
                //{
                //    textBox1.Text = string.Format("Largest file ({0}KB) is {1}", 
                //        largest.Length / (1024), largest.FullName);
                //}, 
                //null);

                //线程直接更新UI线程的界面元素为非法操作
                textBox1.Text = string.Format("Largest file ({0}KB) is {1}",
                        largest.Length / (1024), largest.FullName);
            });
        }
    }
}
