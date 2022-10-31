using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Models;

public class Product
{

    public string? Name { get; set; }
    public string? Company { get; set; }
    public string? Description { get; set; }
    public string? Country { get; set; }
    public string? Category { get; set; }
    public string? ImageUrl { get; set; }


    public Product(string? name, string? company, string? country, string? category, string? imageUrl, string? description = "Empty")
    {
        Name = name;
        Company = company;
        Description = description;
        Country = country;
        Category = category;
        ImageUrl = imageUrl;
    }
}
