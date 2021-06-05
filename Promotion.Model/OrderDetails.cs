using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion.Model
{
    public class OrderDetails
    {
        public IEnumerable<ProductCart> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
