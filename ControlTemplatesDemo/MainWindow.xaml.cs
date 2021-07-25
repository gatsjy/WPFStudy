using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ControlTemplatesDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// 이름을 지정하지 않으면... 모든 Button에 해당 설정이 적용된다. 하지만 Name을 거는 순간 내가 원하는 이름의 값에만 줄 수 있음.
    /// https://www.youtube.com/watch?v=lEtkuMNb1x0
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼 클릭했습니다.");
        }
    }
}
