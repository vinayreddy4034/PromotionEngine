using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Promotion.Model
{   
    public class ProductOffer
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int PromotionId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("PromotionId")]
        public virtual Promotion Promotion { get; set; }
    }
}
