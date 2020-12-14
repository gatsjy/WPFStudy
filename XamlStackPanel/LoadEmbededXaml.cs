using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace XamlStackPanel
{
    class LoadEmbededXaml : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadEmbededXaml());
        }
        public LoadEmbededXaml()
        {
            Title = "Load Embeded Xaml";

            // 다음과 같이 해석가능 하도록 만든다.
            // Button btn = (Button) XamlReader.Load(xmlreader);
            string strXaml =
                "<Button xmlns='http://schemas.microsoft.com/" +
                                "winfx/2006/xaml/presentation'" +
                "   Foreground='LightSeaGreen' FontSize ='24pt'>" +
                "Click me!" +
                "</Button>";
            StringReader strreader = new StringReader(strXaml);
            XmlTextReader xmlreader = new XmlTextReader(strreader);
            object obj = XamlReader.Load(xmlreader);

            Content = obj;
        }
    }
}
