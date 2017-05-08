using System;
using System.Globalization;
using Xamarin.Forms;

namespace PhoneBook.Helper
{
    class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource("PhoneBook.Images." + (value ?? "").ToString().Replace("PhoneBook.Images.", ""));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
