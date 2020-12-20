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

namespace ContentTemplateDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 새로운 EmplyeeButton을 추가하는 코드를 보여줌
            EmployeeButton btn = new EmployeeButton();
            btn.Content = new Employee("Jim", "Jim.png", new DateTime(1975, 6, 15), false);
            stack.Children.Add(btn);
        }

        // 버튼의 Click 이벤트 핸들러
        private void EmplyeeButtonClick(object sender, RoutedEventArgs args)
        {
            Button btn = args.Source as Button;
            Employee emp = btn.Content as Employee;
            MessageBox.Show(emp.Name + " button clicked!", Title);
        }
    }
}
