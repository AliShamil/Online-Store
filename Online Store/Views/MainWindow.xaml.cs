using Bogus;
using Online_Store.FakeData;
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
            Faker faker = new Faker();
            
            InitializeComponent();
            DataContext = this;
            Products = new();
            Basket = new();

            foreach (var item in FakeProducts.GetProducts)
            {
                pnlProducts.Children.Add(new ProductItem_UC(item,ref pnlProducts,Basket));
            }
            
        }

            private void btnAddProduct_Click(object sender, RoutedEventArgs e)
            {
                AddProduct window = new();

                if (window.ShowDialog() == true)
                {
                    if (window.ProductItem != null)
                    pnlProducts.Children.Insert(0, new ProductItem_UC(window.ProductItem, ref pnlProducts, Basket));
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


                foreach (var item in pnlProducts.Children.OfType<ProductItem_UC>())
                {
                
                    if(item.ProductItem.Price.ToString()==txtSearch.Text)
                       item.Visibility = Visibility.Visible;
                    else if(txtSearch.Text.Contains('-'))
                {
                   var words = txtSearch.Text.Trim().Split('-');
                    if(words.Length<=2)
                    {
                        double firstPart = 0;
                        double secondPart = 0;
                        if (double.Parse(words[0]) < double.Parse(words[1]))
                        {
                         firstPart = double.Parse(words[0]);
                         secondPart = double.Parse(words[1]);
                        }
                        else if(double.Parse(words[0]) > double.Parse(words[1]))
                        {
                            firstPart = double.Parse(words[1]);
                            secondPart = double.Parse(words[0]);
                        }
                        else
                        {
                            firstPart= double.Parse(words[0]);
                            secondPart = double.Parse(words[0]);
                        }
                            
                        if(item.ProductItem.Price>= firstPart && item.ProductItem.Price <=secondPart)
                            item.Visibility = Visibility.Visible;
                        else
                            item.Visibility = Visibility.Collapsed;
                    }
                }
                    else if (!item.ProductItem.Product.Name!.ToLower().Contains(txtSearch.Text.ToLower()))
                        item.Visibility = Visibility.Collapsed;
                }
            }

            private void txtSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                    ButtonSearch_Click(sender, e);
            }


    }
}
