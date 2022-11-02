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
                    sb.Append($"All Fields must be written !\n");
                    break;
                }
            }

            if (!Regex.IsMatch(txtPrice.Text, @"^([0-9]+([,][0-9]*)?|[,][0-9]+)$"))
                sb.Append($"Invaild Price !\n");

            if (!Regex.IsMatch(txtCount.Text, @"^(0|[1-9][0-9]*)$"))
                sb.Append($"Invalid Count !\n");

            if (!Regex.IsMatch(txtDiscount.Text, @"^([0-9]+([,][0-9]*)?|[,][0-9]+)$"))
                sb.Append($"Invalid Discount !\n");


            if (sb.Length > 0)
            {
                MessageBox.Show($"{sb}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProductItem = new(
                new Product(txtName.Text,txtCompany.Text, txtCountry.Text,txtCategory.Text,txtImageUrl.Text,txtDesctiption.Text),
                uint.Parse(txtCount.Text),
                double.Parse(txtPrice.Text),
                double.Parse(txtDiscount.Text));

            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;


        private void ProductAddWin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ButtonAccept_Click(sender, e);
            else if (e.Key == Key.Delete)
                ButtonCancel_Click(sender, e);
        }
    }
}
