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

namespace DependencyPropertyEx1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "MyColor", // 의존속성으로 등록
            typeof(String),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));

        private static void OnMyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            MainWindow win = obj as MainWindow;

            SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewValue.ToString());

            win.Background = brush;
            win.Title = (e.OldValue == null) ? "이전배경색 없음" : "배경색" + e.OldValue.ToString();
            win.textBox1.Text = e.NewValue.ToString();
        }
        
        public String Mycolor
        {
            get
            {
                return (String)GetValue(MyProperty);
            }
            set
            {
                SetValue(MyProperty, value);
            }
        }

        private void ContextMenu_Checked(object sender, RoutedEventArgs e)
        {
            string str = (e.Source as MenuItem).Header as string;
            Mycolor = str;
        }
    }
}
