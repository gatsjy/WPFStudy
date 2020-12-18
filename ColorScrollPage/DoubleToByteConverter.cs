using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ColorScroll
{
    // (변환하는 형식, 대상 형식)
    // 여기서는 Double -> byte
    [ValueConversion(typeof(double), typeof(byte))]
    class DoubleToByteConverter : IValueConverter
    {
        public object Convert(object value, Type typeTarget, object param, CultureInfo culture)
        {
            return (byte)(double)value;
        }

        public object ConvertBack(object value, Type typeTarget, object param, CultureInfo culture)
        {
            return (double)(byte)value;
        }
    }
}
