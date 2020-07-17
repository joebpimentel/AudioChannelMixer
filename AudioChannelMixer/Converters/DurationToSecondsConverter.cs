using System;
using System.Globalization;
using System.Windows.Data;

namespace AudioChannelMixer.Converters
{
    public class DurationToSecondsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeSpanInSeconds = 0;
            if (value is TimeSpan timeSpanValue)
            {
                timeSpanInSeconds = (int) timeSpanValue.TotalSeconds;
            }

            return timeSpanInSeconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeSpan = new TimeSpan(0, 0, 0);
            if (value is int timeSpanInSeconds)
            {
                var days = timeSpanInSeconds / (24 * 60 * 60);
                timeSpanInSeconds -= days * 24 * 60 * 60;
                var hours = timeSpanInSeconds / (60 * 60);
                timeSpanInSeconds -= hours * 60 * 60;
                var minutes = timeSpanInSeconds / 60;
                timeSpanInSeconds -= minutes * 60;
                timeSpan = new TimeSpan(days, hours, minutes, timeSpanInSeconds);
            }

            return timeSpan;
        }
    }
}