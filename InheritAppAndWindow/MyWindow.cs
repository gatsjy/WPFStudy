using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InheritAppAndWindow
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            Title = "Inherit App & Window";
        }
        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            base.OnMouseDown(args);

            string strMessage =
                string.Format("Window clicked widh {0} button at point({1})", args.ChangedButton, args.GetPosition(this));
            MessageBox.Show(strMessage, Title);
        }
    }
}
