using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace EX01_Pokemon.View.Converters
{
    public class TypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return new BitmapImage(new Uri("https://www.clipartmax.com/png/small/129-1298272_free-icons-png-pokemon-ball-no-background.png"));

            string type = value.ToString().ToLowerInvariant();
            return new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/{type}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
