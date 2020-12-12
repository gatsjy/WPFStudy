using System;
using System.Windows;
using System.Windows.Controls;

namespace ClickTheButton
{
    class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }

        public ClickTheButton()
        {
            Title = "Click the Button";

            Button btn = new Button();
            btn.Content = "_Click me, please!";
            btn.Click += ButtonOnClick;
            //해당 컨트롤에 포커싱 한다.
            //btn.Focus();
            //기본 버튼으로 설정해 놓는다.
            btn.IsDefault = true;
            //Esc키에 대해 반응할 수 있게 한다.
            btn.IsCancel = true;
            btn.Padding = new Thickness(96);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Button has been clicked and all is well", Title);
        }
    }
}
