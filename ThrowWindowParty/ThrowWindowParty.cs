using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ThrowWindowParty
{
    class ThrowWindowParty : Application
    {
        [STAThread]
        public static void Main()
        {
            ThrowWindowParty app = new ThrowWindowParty();
            app.ShutdownMode = ShutdownMode.OnMainWindowClose; // 메인 창이 닫힐 때 
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            Window winMain = new Window();
            winMain.Title = "Main Window";
            winMain.MouseDown += WindowOnMouseDown;
            winMain.Show();

            for(int i = 0; i < 2; i++)
            {
                Window win = new Window();
                win.Title = "Extra Window No. " + (i + 1);
                //win.ShowInTaskbar = false;
                MainWindow = win;
                // Owner 프로퍼티에 다른 Window객체를 대입할 수 있다.
                // 아래처럼 코딩하면 메인창이 두 개의 창을 소유하게 된다.
                win.Owner = winMain;
                win.Show();
            }
        }

        private void WindowOnMouseDown(object sender, MouseButtonEventArgs args)
        {
            Window win = new Window();
            win.Title = "Modal Dialog Box";
            win.ShowDialog();
        }
    }
}
