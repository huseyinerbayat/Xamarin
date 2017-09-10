using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinMapApplication.Converters
{
    class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource("XamarinMapApplication.Images." + (value ?? "").ToString().Replace("XamarinMapApplication.Images.", ""));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
