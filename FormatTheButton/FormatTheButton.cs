using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace FormatTheButton
{
    class FormatTheButton : Window
    {
        Run runButton;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheButton());
        }
        public FormatTheButton()
        {
            Title = "Format the Button";

            // 버튼을 생성하고 Window의 Content로 설정
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.MouseEnter += ButtonOnMouseEnter;
            btn.MouseLeave += ButtonOnMouseLeave;
            Content = btn;

            // TextBlock을 생성하고 버튼의 Content로 설정
            TextBlock txtblk = new TextBlock();
            txtblk.FontSize = 24;
            txtblk.TextAlignment = TextAlignment.Center;
            btn.Content = txtblk;

            // TextBlock에 서식화된 텍스트를 추가
            txtblk.Inlines.Add(new Italic(new Run("Click")));
            txtblk.Inlines.Add(" the ");
            txtblk.Inlines.Add(runButton = new Run("button"));
            txtblk.Inlines.Add(new LineBreak());
            txtblk.Inlines.Add("to launch the ");
            txtblk.Inlines.Add(new Bold(new Run("rocket")));
        }

        private void ButtonOnMouseLeave(object sender, MouseEventArgs e)
        {
            runButton.Foreground = Brushes.Red;
        }

        private void ButtonOnMouseEnter(object sender, MouseEventArgs e)
        {
            runButton.Foreground = SystemColors.ControlTextBrush;
        }
    }
}
