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
                viewModel.Time = DateTime.Now;
            };
            clock.Start();
            return clock;
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
