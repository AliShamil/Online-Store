using Online_Store.Models;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// ProductInfo.xaml etkileşim mantığı
    /// </summary>
    public partial class ProductInfo : Window
    {

        public ProductItem ProductItem { get; set; }

        public ProductInfo(ProductItem productItem)
        {
            ProductItem = productItem;
            DataContext = this;

            InitializeComponent();
            if (ProductItem.Count == 0)
            {
                txtbCount.Text = "";
                txtbCountLast.Text = "Out Of Stock !";
            }
        }

    }
}
