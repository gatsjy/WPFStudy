using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlipThroughTheBrushes
{
    class FlipThroughTheBrushes : Window
    {
        int index = 0;
        PropertyInfo[] repos;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FlipThroughTheBrushes());
        }
    }
}
