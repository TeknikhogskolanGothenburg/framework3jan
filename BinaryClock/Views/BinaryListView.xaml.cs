using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace BinaryClock.Views
{
    public sealed partial class BinaryListView : UserControl
    {


        public IEnumerable<bool> BinaryData
        {
            get { return (IEnumerable<bool>)GetValue(BinaryDataProperty); }
            set { SetValue(BinaryDataProperty, value); }
        }

        public static readonly DependencyProperty BinaryDataProperty =
            DependencyProperty.Register(nameof(BinaryData), typeof(IEnumerable<bool>), typeof(BinaryListView), new PropertyMetadata(default(IEnumerable<bool>)));


        public BinaryListView()
        {
            this.InitializeComponent();
        }
    }
}
