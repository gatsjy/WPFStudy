using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SetFontSizeProperty_의존프로퍼티_
{
    // 다음 프로그램은 2행 3열로 된 Grid에서 여섯 개의 버튼을 만든다.
    // 각 버튼을 누르면 그 버튼에 쓰인 텍스트 값으로 FontSize 프로퍼티를 바꾼다.
    // 상단에 있는 세 개의 버튼은 Window의 FontSize 프로퍼티를 바꾸지만 하단의 버튼들은 클릭된 버튼의 FontSize 프로퍼티를 바꾼다.
    class SetFontSizeProperty : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetFontSizeProperty());
        }

        public SetFontSizeProperty()
        {
            Title = "Set FontSize Property";
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            FontSize = 16;
            double[] ftnsizes = { 8, 16, 32 };

            // Grid 패널 생성
            Grid grid = new Grid();
            Content = grid;

            // 행 과 열 정의
            for(int i = 0; i <2; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;
                grid.RowDefinitions.Add(row);
            }
            for(int i = 0; i < ftnsizes.Length; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(col);
            }

            // 6개의 버튼 생성
            for(int i = 0; i < ftnsizes.Length; i++)
            {
                Button btn = new Button();
                btn.Content = new TextBlock(new Run("Set window FontSize to " + ftnsizes[i]));
                // 1. 추가 TextBlock에 명시적으로 FontSize를 설정한 다음에는 어떤 값도 계승되지 않는다.
                (btn.Content as TextBlock).FontSize = 12;
                btn.Tag = ftnsizes[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += WindowFontSizeOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 0);
                Grid.SetColumn(btn, i);

                btn = new Button();
                btn.Content = new TextBlock(new Run("Set button FontSize to " + ftnsizes[i]));
                // 1. 추가 TextBlock에 명시적으로 FontSize를 설정한 다음에는 어떤 값도 계승되지 않는다.
                // 다음 코드를 추가하면 12로 박히고 그 후로는 어떤 클릭을 해도 프로퍼티가 변경되지 않는다
                // 즉 엘리먼트 트리에서의 조상으로부터 계승된 값은 기본값보다는 우선순위가 높고, 객체에 명시적으로 설정된 값은 가장 높은 우선순위를 가진다.
                (btn.Content as TextBlock).FontSize = 12;
                btn.Tag = ftnsizes[i];
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                btn.VerticalAlignment = VerticalAlignment.Center;
                btn.Click += ButtonFontSizeOnClick;
                grid.Children.Add(btn);
                Grid.SetRow(btn, 1);
                Grid.SetColumn(btn, i);
            }
        }

        // Grid 자체에는 FontSize란 프로퍼티가 존재하지 않는다.
        private void WindowFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            FontSize = (double)btn.Tag;
        }

        // 하단의 버튼 이벤트 : 이벤트 핸들러에서 클릭된 버튼의 FontSize 프로퍼티만 설정하기 때문에 그 버튼만 변겨오딘다.
        // 개별적으로 FontSize를 설정한 버튼은 더 이상 Window의 FontSize가 바뀌어도 이에 반응하지 않는다.
        // Button에 대해 FontSize를 지정하는 것이 Window에서 상속한 FontSize 보다 우선시 된다.
        private void ButtonFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.FontSize = (double)btn.Tag;
        }
    }
}
