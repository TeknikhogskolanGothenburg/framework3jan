using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace BinaryClock.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Color backgroundColor = Color.FromArgb(255, 0, 0, 255);

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set 
            { 
                if(backgroundColor != value)
                {
                    backgroundColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundColor)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundBrush)));
                }
            }
        }

        public SolidColorBrush BackgroundBrush 
        {
            get { return new SolidColorBrush(BackgroundColor); }  
        }

        private IEnumerable<IEnumerable<bool>> timeData;

        public IEnumerable<IEnumerable<bool>> TimeData
        {
            get { return timeData; }
            set 
            {
                if(timeData != value)
                { 
                    timeData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeData)));
                }
            }
        }


    }
}
