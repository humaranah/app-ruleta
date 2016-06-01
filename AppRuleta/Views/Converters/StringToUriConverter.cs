using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace AppRuleta.Views.Converters
{
    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                return new BitmapImage(new Uri(value as string, UriKind.RelativeOrAbsolute));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is BitmapImage)
            {
                return (value as BitmapImage).UriSource.AbsolutePath;
            }
            return null;
        }
    }
}
