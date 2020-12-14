using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace LoadXamlFile
{
    class LoadXamlFile : Window
    {
        Frame frame;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXamlFile());
        }

        public LoadXamlFile()
        {
            Title = "Load XAML File";

            DockPanel dock = new DockPanel();
            Content = dock;

            // Open File 대화상자 생성
            Button btn = new Button();
            btn.Content = "Open File...";
            btn.Margin = new Thickness(12);
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.Click += ButtonOnClick;
            dock.Children.Add(btn);
            DockPanel.SetDock(btn, Dock.Top);

            // 로드한 XAML을 호스팅할 Frame을 생성
            frame = new Frame();
            dock.Children.Add(frame);
        }

        private void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";

            if ((bool)dlg.ShowDialog())
            {
                try
                {

                    // XmlTextReader로 파일을 읽음
                    XmlTextReader xmlreader = new XmlTextReader(dlg.FileName);

                    // XAML을 객체로 변환
                    object obj = XamlReader.Load(xmlreader);

                    // Window면 Show 메소드 호출
                    if (obj is Window)
                    {
                        Window win = obj as Window;
                        win.Owner = this;
                        win.Show();
                    }

                    // 그렇지 않으면 Frame의 Content로 설정
                    else
                        frame.Content = obj;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }
        }
    }
}
