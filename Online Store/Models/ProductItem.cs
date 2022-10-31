using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models;

public class ProductItem : INotifyPropertyChanged
{
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public Guid ID { get; set; }
    public Product Product { get; set; }
    private uint _count;

    public uint Count
    {
        get { return _count; }
        set 
        {
            _count = value;
            NotifyPropertyChanged();
        }
    }

    public double Price { get; set; }
    
    public double Discount { get; set; }

    public ProductItem(Product product, uint count, double price, double discount)
    {
        ID = Guid.NewGuid();
        Product = product;
        Count = count;
        Price = price;
        Discount = discount;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
