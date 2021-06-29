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

namespace StudyDependencyProperty
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

        /// <summary>
        /// Dependency Property 위한 래퍼 속성 MyFruit 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string MyFruit
        {
            get
            {
                return (string)GetValue(MyProperty);
            }
            set
            {
                SetValue(MyProperty, value);
            }
        }

        /// <summary>
        /// 의존프로퍼티 값 등록
        /// 의존 프로퍼티에 대한 정의는 특정 의존 속성 값이 변경되면 자동으로 어떤 행동을 처리할 수 있게 매핑해 주는 것,,,,
        /// </summary>
        public static readonly DependencyProperty MyProperty = DependencyProperty.Register(
            "MyFruit",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMyPropertyChanged)));

        /// <summary>
        /// 특정 값이 변경되면 실행되는 이벤트 핸들러
        /// </summary>
        public static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow win = d as MainWindow;

            // OldValue를 통해 변하기 이전값을 세팅하고 NewValue를 통해 변한 이후의 값을 세팅한다.
            win.Title = (e.OldValue == null) ? "선택된 과일 없음" : $"이전 선택된 과일은 {e.OldValue.ToString()} 입니다.";
            win.uiTb_Fruit.Text = e.NewValue.ToString();
        }

        /// <summary>
        /// ComboBox SelectionChanged 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            ComboBoxItem item = cb.SelectedItem as ComboBoxItem;
            MyFruit = item.Content.ToString();
        }
    }
}
