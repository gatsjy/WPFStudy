using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace XamlStackPanel
{
    class LoadXamlResource : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXamlResource());
        }
        public LoadXamlResource()
        {
            Title = "Load Xaml Resource";

            Uri uri =
                new Uri("pack://application:,,,/LoadXamlResource.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            FrameworkElement el = XamlReader.Load(stream) as FrameworkElement;
            Content = el;

            Button btn = el.FindName("MyButton") as Button;

            if (btn != null)
                btn.Click += ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The button labeled'" +
                (e.Source as Button).Content +
                "' has been clicked");
        }
    }
}
