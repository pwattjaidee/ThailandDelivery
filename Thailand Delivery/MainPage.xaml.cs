using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections;
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Globalization;

namespace Thailand_Delivery
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
           
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void DialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList selectedItems = e.AddedItems;
            ItemViewModel item = (ItemViewModel)DialList.SelectedItem;

            if ((item.LineSix > DateTime.Now.Hour) && (DateTime.Now.Hour >= item.LineFive))
            {
                PhoneCallTask call = new PhoneCallTask();
                call.DisplayName = item.LineOne;
                call.PhoneNumber = item.LineTwo;
                call.Show();
            }
            else
            {
                MessageBoxResult res = MessageBox.Show(item.LineOne + " is not open yet, still want me to call them?", "Oh no!", MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK)
                {
                    PhoneCallTask call = new PhoneCallTask();
                    call.DisplayName = item.LineOne;
                    call.PhoneNumber = item.LineTwo;
                    call.Show();
                }
                else
                {
                }
            }
        }

        private void WebList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IList selectedItems = e.AddedItems;
            ItemViewModel item = (ItemViewModel)WebList.SelectedItem;

            WebBrowserTask launcher = new WebBrowserTask();
            launcher.Uri = new Uri(item.LineThree, UriKind.Absolute);
            launcher.Show();
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        
    }
}