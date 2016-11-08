using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishList.Models;

namespace WishList.ViewModels.Home
{
    public class ListViewModel
    {
        public User User { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}