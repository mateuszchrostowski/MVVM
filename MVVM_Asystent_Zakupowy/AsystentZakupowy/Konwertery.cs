using System.Globalization;

namespace AsystentZakupowy
{
    internal class DecimaToStringConverter : IValueConverter
    {
        private IFormatProvider fp = new CultureInfo("pl-PL");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal d = (decimal)value;
            return d.ToString(fp);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            decimal d = decimal.Parse(s, fp);
            return d;
        }
    }
}
