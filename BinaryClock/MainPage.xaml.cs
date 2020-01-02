using BinaryClock.Converters;
using BinaryClock.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace BinaryClock
{
    public sealed partial class MainPage : Page
    {
        readonly private MainViewModel viewModel = new MainViewModel();
        readonly private Task colorUpdateTask;
        readonly private DispatcherTimer clock;


        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            colorUpdateTask = BackgroundColorUpdate();
            clock = CreateClock();
        }

        private DispatcherTimer CreateClock()
        {
            var clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromSeconds(1);
            clock.Tick += (o, e) => 
            {
                UpdateViewModelForCurrentTime(DateTime.Now);
            };
            clock.Start();
            return clock;
        }

        private void UpdateViewModelForCurrentTime(DateTime currentTime)
        {
            var seconds = new int[] { currentTime.Second / 10, currentTime.Second % 10 };
            var minutes = new int[] { currentTime.Minute / 10, currentTime.Minute % 10 };
            var hours = new int[] { currentTime.Hour / 10, currentTime.Hour % 10 };
            viewModel.TimeData = new List<IEnumerable<bool>>
            {
                IntegerToBooleanArrayConverter.ConvertToBools(hours[0], 2),
                IntegerToBooleanArrayConverter.ConvertToBools(hours[1], 4),
                IntegerToBooleanArrayConverter.ConvertToBools(minutes[0], 3),
                IntegerToBooleanArrayConverter.ConvertToBools(minutes[1], 4),
                IntegerToBooleanArrayConverter.ConvertToBools(seconds[0], 3),
                IntegerToBooleanArrayConverter.ConvertToBools(seconds[1], 4),
            };
        }

        private Task BackgroundColorUpdate()
        {
            return Task.Run(async () =>
            {
                int iterations = 0;
                while(true)
                {
                    await Task.Delay(50);
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        viewModel.BackgroundColor = Color.FromArgb(
                            255,
                            (byte)(128 + (int)(Math.Sin(iterations * .01f) * 127)),
                            (byte)(128 + (int)(Math.Sin(iterations * .0125f + 1) * 127)),
                            (byte)(128 + (int)(Math.Sin(iterations * .005f + 1) * 127))
                            );
                    }
                    );
                    iterations++;
                }
            }
            );
        }
    }
}
