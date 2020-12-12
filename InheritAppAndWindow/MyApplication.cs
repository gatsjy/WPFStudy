using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InheritAppAndWindow
{
    class MyApplication : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);
            MyWindow win = new MyWindow();
            win.Show();
        }
    }
}
