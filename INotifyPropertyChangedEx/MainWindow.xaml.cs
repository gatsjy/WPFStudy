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

namespace INotifyPropertyChangedEx
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>

    /*
     * WPF는 MVVM 패턴을 이용하기 위해 발전해온 개발 프로그램이다.
     * WINFORM의 한계를 넘어보려고 View단을 직접 조작하게끔 만들어 놓은 것이다
     * 1. INotifyPropertyChanged는 무엇인가?
     * WPF를 사용하면 Xaml파일이 보일 것이다
     * 그 부분이 view단에 해당하는 것으로 Source(Model)를 바인딩시켜서 화면에 보여주게 되는데
     * 이바인딩된 값이 바뀔때마다 변하는 것을 인지해주어 백단의 값을 자동으로 바꾸게 해주는 역할을 해주어
     * View와 ViewModel의 값을 실시간으로 바꾸게 되는 것이다.
     * https://magpienote.tistory.com/52 
     * 
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
}
