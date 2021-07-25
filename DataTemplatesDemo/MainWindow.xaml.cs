using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTemplatesDemo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person obj { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            obj = new Person();

            obj.Name = "hanjuan";

            this.DataContext = this;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "바보" + Name;
        }
    }
}
