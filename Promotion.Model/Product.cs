using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Promotion.Model
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public double Price { get; set; }
    }
}
