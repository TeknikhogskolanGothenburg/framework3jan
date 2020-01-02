using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace BinaryClock.Converters
{
    class BooleanToBrushConverter : IValueConverter
    {
        public Brush ActiveBrush { get; set; }
        public Brush InactiveBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var asBool = value as bool?;
            if(asBool.HasValue)
            {
                return asBool.Value ? ActiveBrush : InactiveBrush;
            }
            throw new ArgumentException("Value is not a boolean");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
