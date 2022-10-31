using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// AddProduct.xaml etkileşim mantığı
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            DataContext = this;
        }
        public ProductItem? ProductItem { get; set; }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new();

            foreach (var txt in MainGrid.Children.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    sb.Append($"All Fields must be filled\n");
                    break;
                }
            }

            if (!Regex.IsMatch(txtProductPrice.Text, @"^([0-9]+([,][0-9]*)?|[,][0-9]+)$"))
                sb.Append($"Incorrect Format For Price\n");

            if (!Regex.IsMatch(txtProductCount.Text, @"^(0|[1-9][0-9]*)$"))
                sb.Append($"Incorrect Format For Count\n");

            if (!Regex.IsMatch(txtProductDiscount.Text, @"^([0-9]+([,][0-9]*)?|[,][0-9]+)$"))
                sb.Append($"Incorrect Format For Discount\n");


            if (sb.Length > 0)
            {
                MessageBox.Show($"{sb}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProductItem = new(
                new Product(txtProductName.Text,
                txtProductCompany.Text,
                txtDesctiption.Text, txtProductCountry.Text,
                txtProductCategory.Text, txtProductImage.Text),
                uint.Parse(txtProductCount.Text),
                double.Parse(txtProductPrice.Text),
                double.Parse(txtProductDiscount.Text));

            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
