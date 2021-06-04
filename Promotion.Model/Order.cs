using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Model
{
    public class Order
    {
        public IEnumerable<ProductCart> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
