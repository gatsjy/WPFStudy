using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DecimalScrollBar
{
    [ValueConversion(typeof(double), typeof(decimal))]
    class DoubleToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type typeTarget, object param, CultureInfo culture)
        {
            decimal num = new decimal((double)value);
            if (param != null)
                num = Decimal.Round(num, Int32.Parse(param as string));

            return num;
        }

        public object ConvertBack(object value, Type typeTarget, object param, CultureInfo culture)
        {
            return Decimal.ToDouble((decimal)value);
        }
    }
}
