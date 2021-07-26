using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DispatcherEx
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// dhsmfdms thfwlrgl wkf ahfmrpTek.. bb
    /// https://www.youtube.com/watch?v=2GG-DM6E8ZY
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void SetTextCallbackDelegate(string text);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(SetText));
            t.Start();
        }
        
        private void SetText()
        {
            this.Dispatcher.Invoke(() => { textBox.Text = "Text is Set"; });
        }
    }
}
