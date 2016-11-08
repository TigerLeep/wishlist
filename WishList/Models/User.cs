using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WishList.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual IEnumerable<Item> Items { get; set; }
    }
}