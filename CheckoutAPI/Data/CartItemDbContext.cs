using CheckoutAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutAPI.Repositories
{
    public class CartItemDbContext : DbContext
    {
        public CartItemDbContext(DbContextOptions<CartItemDbContext> options):base(options){}
        public DbSet<CartItem> CartItems { get; set; }
    }
}
