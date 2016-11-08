using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishList.Models;

namespace WishList.ViewModels.Home
{
    public class CreateViewModel
    {
        public User User { get; set; }
        public Item Item { get; set; }
    }
}