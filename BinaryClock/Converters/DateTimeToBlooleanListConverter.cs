using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BinaryClock.Converters
{
    class DateTimeToBooleanListConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var convertedDateTime = value as DateTime?;
            if(convertedDateTime.HasValue)
            {
                var currentTime = convertedDateTime.Value;
                var seconds = new int[] { currentTime.Second / 10, currentTime.Second % 10 };
                var minutes = new int[] { currentTime.Minute / 10, currentTime.Minute % 10 };
                var hours = new int[] { currentTime.Hour / 10, currentTime.Hour % 10 };
                var result = new List<IEnumerable<bool>>
                {
                    IntegerToBooleanArrayConverter.ConvertToBools(hours[0], 2),
                    IntegerToBooleanArrayConverter.ConvertToBools(hours[1], 4),
                    IntegerToBooleanArrayConverter.ConvertToBools(minutes[0], 3),
                    IntegerToBooleanArrayConverter.ConvertToBools(minutes[1], 4),
                    IntegerToBooleanArrayConverter.ConvertToBools(seconds[0], 3),
                    IntegerToBooleanArrayConverter.ConvertToBools(seconds[1], 4),
                };
                return result;
            }
            throw new ArgumentException("Value is not a DateTime");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
