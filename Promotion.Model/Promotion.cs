using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Promotion.Model
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public PromotionType Type { get; set; }
        public double PromotionAmount { get; set; }
        public virtual ICollection<ProductOffer> ProductOffers { get; set; }


        public IEnumerable<ProductCart> Validate(Order order, IEnumerable<ProductCart> validatedItems)
        {
            var foundItems = new List<ProductCart>();
            if (ProductOffers == null || ProductOffers.Count < 1)
                return foundItems;

            foreach (var promotionItem in ProductOffers)
            {
                var foundItem = validatedItems.FirstOrDefault(x => x.ProductId == promotionItem.ProductId) ??
                  order.Items.FirstOrDefault(x => x.ProductId == promotionItem.ProductId);
                if (foundItem == null || foundItem.Quantity < promotionItem.Quantity)
                    return null;

                if (!foundItems.Any(x => x.ProductId == foundItem.ProductId))
                    foundItems.Add(new ProductCart { ProductId=foundItem.ProductId,Quantity=foundItem.Quantity });
            }

            ApplyPromotion(order, foundItems);

            return foundItems;
        }

        private void ApplyPromotion(Order order, List<ProductCart> foundItems)
        {
            var found = foundItems.Count() > 0;
            if (found)
            {
                do
                {
                    order.TotalAmount += PromotionAmount;
                    foreach (var promotionItem in ProductOffers)
                    {
                        var item = foundItems.FirstOrDefault(x => x.ProductId == promotionItem.ProductId);
                        if (item != null)
                        {
                            item.Quantity -= promotionItem.Quantity;
                            if (found)
                                found = item.Quantity >= promotionItem.Quantity;
                        }
                    }
                } while (found);
            }
        }
    }
}
