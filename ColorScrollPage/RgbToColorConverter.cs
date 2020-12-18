using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorScroll
{
    class RgbToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type typeTarget, object param, CultureInfo culture)
        {
            Color clr = Color.FromRgb((byte)(double)value[0], (byte)(double)value[1], (byte)(double)value[2]);

            if (typeTarget == typeof(Color))
                return clr;

            if (typeTarget == typeof(Brush))
                return new SolidColorBrush(clr);

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Color clr;
            object[] primaries = new object[3];

            if (value is Color)
                clr = (Color)value;

            else if (value is SolidColorBrush)
                clr = (value as SolidColorBrush).Color;

            else
                return null;

            primaries[0] = clr.R;
            primaries[1] = clr.G;
            primaries[2] = clr.B;
            return primaries;
        }
    }
}
