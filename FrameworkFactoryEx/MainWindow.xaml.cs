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

namespace FrameworkFactoryEx
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Width = 800;
            Height = 600;
            Title = "FrameworkElementFactory";
            FontFamily = new FontFamily("나눔고딕");
            FontSize = 16;

            // Button 컨트롤 템플릿을 생성
            ControlTemplate controlTemplate = new ControlTemplate(typeof(Button));

            // 프레임워크 엘리먼트 팩토리를 생성한다.
            FrameworkElementFactory bfe = new FrameworkElementFactory(typeof(Border));

            bfe.Name = "border";
            bfe.SetValue(Border.BorderBrushProperty, Brushes.Red);
            bfe.SetValue(Border.BorderThicknessProperty, new Thickness(3));
            bfe.SetValue(Border.BackgroundProperty, SystemColors.ControlLightBrush);

            // ContentPresenter ContentPresenter 프레임워크 엘리먼트 팩토리를 생성한다.
            FrameworkElementFactory cpfe = new FrameworkElementFactory(typeof(ContentPresenter));

            cpfe.Name = "contentPresenter";
            cpfe.SetValue(ContentPresenter.ContentProperty, new TemplateBindingExtension(Button.ContentProperty));
            cpfe.SetValue(ContentPresenter.MarginProperty, new TemplateBindingExtension(Button.PaddingProperty));

            // 프레임워크 엘리먼트 팩토리를 Border 프레임워크 엘리먼트 팩토리 자식에 추가한다.
            bfe.AppendChild(cpfe);

            // Button 컨트롤 템플릿의 비주얼 트리에 Border 프레임워크 엘리먼트 팩토리를 설정한다.
            controlTemplate.VisualTree = bfe;

            Button button = new Button();
            button.Content = "커스텀 템플릿을 갖는 버튼";
            button.Template = controlTemplate;
            button.Padding = new Thickness(40);
            button.FontSize = 40;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            Content = button;
        }
    }
}
