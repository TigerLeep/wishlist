using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WishList.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Order { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}