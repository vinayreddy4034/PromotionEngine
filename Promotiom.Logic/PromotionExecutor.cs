using Microsoft.EntityFrameworkCore;
using Promotion.DAL;
using Promotion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Promotiom.Logic
{
    public class PromotionExecutor : IPromotionExecutor
    {
        private readonly PromotionContext promotionContext;

        public PromotionExecutor(PromotionContext promotionContext)
        {
            if(promotionContext == null)
            {
                throw new ArgumentNullException(nameof(promotionContext));
            }
            this.promotionContext = promotionContext;
            promotionContext.Database.EnsureCreated();
        }
        public OrderDetails ApplyPromotion(IEnumerable<ProductCart> productItems)
        {
            if (productItems == null)
            {
                throw new ArgumentNullException(nameof(productItems));
            }
            var foundItems = new List<ProductCart>();
            var order = new OrderDetails { Items = productItems, TotalAmount = 0 };
            foreach (var promotion in promotionContext.Promotions.Include("ProductOffers"))
            {
                var validatedItems = promotion.Validate(order, foundItems);
                UpdateValidatedItems(foundItems, validatedItems);
            }
            ApplyRegularPrice(order, foundItems);
            return order;
        }

        private void UpdateValidatedItems(List<ProductCart> foundItems, IEnumerable<ProductCart> validatedItems)
        {
            if (validatedItems == null || validatedItems.Count() < 1)
                return;

            foreach (var item in validatedItems)
                if (!foundItems.Any(x => x.ProductId == item.ProductId))
                    foundItems.Add(item);
        }

        private void ApplyRegularPrice(OrderDetails order, List<ProductCart> foundItems)
        {
            foreach (var item in order.Items)
            {
                var validateItem = foundItems.FirstOrDefault(x => x.ProductId == item.ProductId) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    order.TotalAmount += quantity * promotionContext.Products.First(x => x.Id == item.ProductId).Price;
            }
        }
    }
}
