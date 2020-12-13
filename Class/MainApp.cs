using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //Base a = new Base("a");
            //a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            //b.DerivedMethod();
        }
    }
}
