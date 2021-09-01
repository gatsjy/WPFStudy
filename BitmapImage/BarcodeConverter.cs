using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TECIT.TBarCode;

namespace BitmapImageDemo
{
    class BarcodeConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string inputStr = value as string;
            BitmapImage bi = new BitmapImage();

            if (value == null) return bi;
            if (string.IsNullOrEmpty(inputStr)) return bi;

            string returnOutputStr = inputStr.ToUpper();
            Barcode barcode = new Barcode();
            barcode.Data = returnOutputStr;
            barcode.BarcodeType = BarcodeType.Code39;
            barcode.Dpi = 100;
            barcode.SizeMode = SizeMode.FitToBoundingRectangle;
            barcode.TextClipping = false;
            barcode.IsTextVisible = false; // 하단에 텍스트가 나올 것인지 안나올 것인지..
            System.Drawing.Size optimalSize = barcode.CalculateOptimalBitmapSize(null, 1, 1);
            barcode.BoundingRectangle = new System.Drawing.Rectangle(0, 0, optimalSize.Width, optimalSize.Height);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                Bitmap barcodeBitmap = barcode.DrawBitmap();
                barcodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Position = 0;
                BitmapImage returnBi = new BitmapImage();
                returnBi.BeginInit();
                returnBi.StreamSource = ms;
                returnBi.CacheOption = BitmapCacheOption.OnLoad;
                returnBi.EndInit();
                return returnBi;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
