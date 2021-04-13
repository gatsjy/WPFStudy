using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace RenderTehGraphic
{
    class RenderTheGraphic : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new RenderTheGraphic());
        }
        public RenderTheGraphic()
        {
            Title = "Render the Graphic";
            SimpleEllipse ellipse = new SimpleEllipse();
            Content = ellipse;
        }
    }
}
