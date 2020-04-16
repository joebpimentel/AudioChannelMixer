using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioChannelMixer.Converters
{
    public class VolumeLevelToIconIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertedValue = "High";
            if (value == null)
            {
                return convertedValue;
            }

            int originalValue = (int)value;
            if (originalValue < 1)
            {
                convertedValue = "Mute";
            }
            else if (originalValue < 33)
            {
                convertedValue = "Low";
            }
            else if (originalValue < 66)
            {
                convertedValue = "Medium";
            }

            return convertedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}