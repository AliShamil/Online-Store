using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.FakeData
{
    public static class FakeProducts
    {
        public static List<ProductItem> GetProducts { get; } = new()
        {
            new ProductItem(new Product("Mi 11", "Xiaomi", "China", "Electronics", "https://avatars.dzeninfra.ru/get-zen_doc/4219899/pub_606300423ebe7f2d78cb2cc2_6063004a4fcbbf222b2892c9/scale_1200"), 250, 1200, 10),
            new ProductItem(new Product("TUF Gaming F17", "Assus", "Taiwan", "Electronics", "https://theroco.com/assets/2018/12/asus-tuf-gaming-fx505-review-main.jpg"), 20, 2800, 20),
            new ProductItem(new Product("Assassins Creed Brotherhood", "Unity", "USA", "Game", "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/02a23bb6-c43f-4ee0-91d4-b3981bb1a6c7/df7uwll-bf9d459e-b2dd-4d35-b5b7-aa2982dbacb0.jpg/v1/fill/w_1131,h_707,q_70,strp/vei3kd_by_love1jay_df7uwll-pre.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9ODAwIiwicGF0aCI6IlwvZlwvMDJhMjNiYjYtYzQzZi00ZWUwLTkxZDQtYjM5ODFiYjFhNmM3XC9kZjd1d2xsLWJmOWQ0NTllLWIyZGQtNGQzNS1iNWI3LWFhMjk4MmRiYWNiMC5qcGciLCJ3aWR0aCI6Ijw9MTI4MCJ9XV0sImF1ZCI6WyJ1cm46c2VydmljZTppbWFnZS5vcGVyYXRpb25zIl19.btfH2kqkuTk78irIMC3Uoz4-cYp-m_zWmmP5MCBbico"),  1200, 7, 0),
            new ProductItem(new Product("God of War", "Sony Interactive Entertainment", "USA", "Game", "https://gameguru.ru/media/wallpaper/43118/243411150_4886637094704309_6278405803409414787_n.jpg"),  110, 70, 0),
            new ProductItem(new Product("Red Dead Redemption 2", "Rockstar Games", "USA", "Game", "https://cdn1.ozone.ru/s3/multimedia-n/6045748895.jpg"),  1200, 80, 21),
            
        };
    }
}
