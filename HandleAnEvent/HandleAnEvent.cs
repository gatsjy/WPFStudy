using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HandleAnEvent
{
    class HandleAnEvent
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();

            Window win = new Window();
            win.Title = "Handle An Event";
            win.MouseDown += WindowOnMouseDown;
            app.Run(win);
        }

        // 첫번째 인자, sender는 이벤트를 발생시키는 객체
        // 이벤트 핸들러는 이 객체를 Window 타입의 객체로 안전하게 형 변환한다.
        private static void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            Window win = sender as Window;
            string strMessage =
                string.Format("Window clicked with {0} button at point({1})",args.ChangedButton, args.GetPosition(win));
            //MessageBox.Show(strMessage, win.Title);
            MessageBox.Show(strMessage, Application.Current.MainWindow.Title);
        }
    }
}
