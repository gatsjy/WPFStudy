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

namespace AttachedPropertiedDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// NewName이란 없는 프로퍼티를 만들어줘서 상호적으로 사용가능하게 만들 수 있는 기능이다!
    /// 이런 방식으로 자신에게 없는 종속성을 만들어줘서 상호 소통할 수 있는 창고를 만들어 줄 것이라고 생각한다!
    /// https://www.youtube.com/watch?v=_h0-DlLXxMM
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_Click(object sender, RoutedEventArgs e)
        {
            UIElement uIElement = (UIElement)sender;

            MessageBox.Show("Title of yr Control is = " + GetNewName(uIElement), "AttachedProperty");
        }

        public static string GetNewName(DependencyObject obj)
        {
            return (string)obj.GetValue(NewNameProperty);
        }

        public static void SetNewName(DependencyObject obj, string value)
        {
            obj.SetValue(NewNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for NewName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewNameProperty =
            DependencyProperty.RegisterAttached("NewName", typeof(string), typeof(MainWindow), new PropertyMetadata());

        //public int MyProperty
        //{
        //    get { return (int)GetValue(MyPropertyProperty); }
        //    set { SetValue(MyPropertyProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyPropertyProperty =
        //    DependencyProperty.Register("MyProperty", typeof(int), typeof(ownerclass), new PropertyMetadata(0));


    }
}
