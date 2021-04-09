using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FlipThroughTheBrushes
{
    class FlipThroughTheBrushes : Window
    {
        int index = 0;
        PropertyInfo[] props;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FlipThroughTheBrushes());
        }
        public FlipThroughTheBrushes()
        {
            // 명시적으로 public과 static 프로퍼티만으로 제한하고 있다.
            props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            SetTitleAndBackground();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                index += e.Key == Key.Up ? 1 : props.Length - 1;
                index %= props.Length;
                SetTitleAndBackground();
            }
            base.OnKeyDown(e);
        }
        void SetTitleAndBackground()
        {
            Title = "Flip Through the Brushes - " + props[index].Name;
            Background = (Brush)props[index].GetValue(null, null);
        }
    }
}
