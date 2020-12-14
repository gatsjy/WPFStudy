using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CompileXamlWindow
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// Partial 키워드는 CompileXamlWindow 클래스가 다른 어딘가에 추가적인 코드를 가지고 있다는 것을 명시해 그 코드는 C# 코드 비하인드 파일 속에 있다.
    public partial class CompileXamlWindow : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CompileXamlWindow());
        }

        public CompileXamlWindow()
        {
            // 필드를 초기화하고 이벤트 핸들러를 가져오기 위해 필요한 메소드 호출
            // xaml로 부터 생성된 리스트박스와 델립스 엘리먼트 필드 이름을 lstbox와 elips로 설정하고,
            // button과 lsitBox 컨드롤의 이벤트 핸들러를 연결시키는 매우 중요한 기능을 한다.
            InitializeComponent();

            // 브러시 이름으로 ListBox를 채움
            foreach (PropertyInfo prop in typeof(Brushes).GetProperties())
                lstbox.Items.Add(prop.Name);
        }

        //MessageBox를 띄워 주는 Button 이벤트 핸들러
        private void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Button btn = sender as Button;
            MessageBox.Show("The button labled '" + btn.Content + "' has been clicked");
        }

        // Ellipse의 Fill 프로퍼티를 바꾸는 ListBox 이벤트 핸들러
        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox;
            string strItem = lstbox.SelectedItem as string;
            PropertyInfo prop = typeof(Brushes).GetProperty(strItem);
            elips.Fill = (Brush)prop.GetValue(null, null);
        }
    }
}
