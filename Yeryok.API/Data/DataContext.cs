using Microsoft.EntityFrameworkCore;
using Yeryok.Shared.Entities;
using YerYok.Shared.Entities;

namespace Yeryok.API.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
