using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WishList.Models
{
    public class WishListContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}