using System.Globalization;

namespace MVVM_Kolory
{
    internal class DoubleToByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double)value; //założenie: od 0 do 1
            return (byte)Math.Round(255 * d);            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte b = (byte)value; //założenie: od 0 do 255
            return b / 255.0;
        }
    }

    internal class RGBToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0 || values.Any(v => v == null)) return Colors.Black;
            double r = (double)values[0];
            double g = (double)values[1];
            double b = (double)values[2];
            return Color.FromRgba(r, g, b, 1.0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
