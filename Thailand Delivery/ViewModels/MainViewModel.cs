using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Schema;
using System.Collections.ObjectModel;


namespace Thailand_Delivery
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "McDonald's", LineTwo = "1711", LineThree = "http://www.mcthai.co.th/deliverycontent.php?catid=1", LineFour = @"pic\mcdelivery.png", LineFive = 0, LineSix = 24 });
            this.Items.Add(new ItemViewModel() { LineOne = "KFC", LineTwo = "1150", LineThree = "http://www.kfc.co.th/menu.php", LineFour = @"pic\kfc.png", LineFive = 10, LineSix = 24 });
            this.Items.Add(new ItemViewModel() { LineOne = "Chester's Grill", LineTwo = "1145", LineThree = "http://www.chestersgrill.co.th", LineFour = @"pic\chesters.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "The Pizza Company", LineTwo = "1112", LineThree = "http://www.pizza.co.th/pizza_menu/pizza_en.php", LineFour = @"pic\thepizza.png", LineFive = 10, LineSix = 24 });
            this.Items.Add(new ItemViewModel() { LineOne = "Pizza Hut", LineTwo = "1150", LineThree = "http://www.pizzahut.co.th/menu.php", LineFour = @"pic\pizzahut.png", LineFive = 10, LineSix = 24 });
            this.Items.Add(new ItemViewModel() { LineOne = "Narai Pizzeria", LineTwo = "026780555", LineThree = "http://www.naraipizzeria.com/pizza1.html", LineFour = @"pic\narai.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "Scoozi", LineTwo = "027158555", LineThree = "http://www.scoozipizza.com/All%20pizza.php#", LineFour = @"pic\scoozi.png", LineFive = 11, LineSix = 22 });
            this.Items.Add(new ItemViewModel() { LineOne = "MK", LineTwo = "022485555", LineThree = "http://www.mkrestaurant.com/mkdelivery/index.php", LineFour = @"pic\mk.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "Yayoi", LineTwo = "022485555", LineThree = "http://www.mkrestaurant.com/yayoi/menu.htm", LineFour = @"pic\yayoi.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "OISHI", LineTwo = "027123456", LineThree = "http://www.oishigroup.com/product_delivery.php", LineFour = @"pic\oishi.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "S&P", LineTwo = "1344", LineThree = "http://www.snpfood.com/info/sandpdelivery.php", LineFour = @"pic\snpdelivery.png", LineFive = 9, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "JJ", LineTwo = "027123000", LineThree = "http://www.jjdelivery.com/menu/", LineFour = @"pic\jjdelivery.png", LineFive = 10, LineSix = 21 });
            this.Items.Add(new ItemViewModel() { LineOne = "See Fah", LineTwo = "028008080", LineThree = "http://www.seefah.com/products/seefah-delivery/menu/appetizer", LineFour = @"pic\seefah.png", LineFive = 10, LineSix = 21 });
            

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}