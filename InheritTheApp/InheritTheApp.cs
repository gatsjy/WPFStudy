using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InheritTheApp
{
    class InheritTheApp : Application
    {
        [STAThread]
        public static void Main()
        {
            InheritTheApp app = new InheritTheApp();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);

            Window win = new Window();
            win.Title = "Inherit thr App";
            win.Show();
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs args)
        {
            base.OnSessionEnding(args);

            MessageBoxResult result =
                MessageBox.Show("Do you want to save your data?",
                MainWindow.Title,
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes);

            args.Cancel = (result == MessageBoxResult.Cancel);
        }
    }
}
