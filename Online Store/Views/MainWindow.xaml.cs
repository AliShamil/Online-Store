using Online_Store.Models;
using Online_Store.User_Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Online_Store.Views
{
    public partial class MainWindow : Window
    {
    public ObservableCollection<ProductItem> Products { get; set; }
    public ObservableCollection<ProductItem> Basket { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Products = new();
            Basket = new();
            Product product = new Product("Mi 11", "Xiaomi", "China", "Phone", "https://avatars.mds.yandex.net/i?id=1fa6fba40f9ff0d90be3889f8345e746-4210949-images-thumbs&n=13","aSdqdasssssssssssssssssssssssssssssssssssssffaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            pnlProducts.Children.Add(new ProductItem_UC(new ProductItem(product, 1, 1200, 20), Basket));
            pnlProducts.Children.Add(new ProductItem_UC(new ProductItem(product, 1, 1200, 20), Basket));
            pnlProducts.Children.Add(new ProductItem_UC(new ProductItem(product, 1, 1200, 20), Basket));
            pnlProducts.Children.Add(new ProductItem_UC(new ProductItem(product, 1, 1200, 20), Basket));

        }

            private void btnAddProduct_Click(object sender, RoutedEventArgs e)
            {
                AddProduct window = new();

                if (window.ShowDialog() == true)
                {
                    if (window.ProductItem != null)
                    pnlProducts.Children.Insert(0, new ProductItem_UC(window.ProductItem, Basket));
                }
            }

            private void BtnBasket_Click(object sender, RoutedEventArgs e)
            {
                BasketInfo window = new(Basket);

                window.ShowDialog();
            }


            private void ButtonSearch_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    foreach (var control in pnlProducts.Children.OfType<ProductItem_UC>())
                        control.Visibility = Visibility.Visible;

                    return;
                }


                foreach (var control in pnlProducts.Children.OfType<ProductItem_UC>())
                {
                    if (!control.ProductItem.Product.Name!.ToLower().Contains(txtSearch.Text.ToLower()))
                        control.Visibility = Visibility.Collapsed;
                }
            }

            private void txtSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                    ButtonSearch_Click(sender, e);
            }

       
    }
}
