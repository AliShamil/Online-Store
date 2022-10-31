using Online_Store.Models;
using Online_Store.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_Store.User_Controls
{
    public partial class ProductItem_UC : UserControl
    {
        ObservableCollection<ProductItem> _basket;
        

        public ProductItem ProductItem { get; set; }

        public ProductItem_UC(ProductItem productItem, ObservableCollection<ProductItem> basket)
        {
            InitializeComponent();

            DataContext = this;

            ProductItem = productItem;
            _basket = basket;

        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductInfo window = new(ProductItem);
            window.Show();
        }

        private void BtnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if (!_basket.Contains(ProductItem))
                _basket.Add(ProductItem);
        }
    }
}
