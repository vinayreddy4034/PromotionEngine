
using System.Collections.Generic;
namespace Promotion.Model
{
    /// <summary>
    /// Calculates and applies promotion for Products
    /// </summary>
    public interface IPromotionExecutor
    {
        /// <summary>
        /// Applies promotion for product items
        /// </summary>
        /// <param name="productItems">List of product items</param>
        /// <returns></returns>
        OrderDetails ApplyPromotion(IEnumerable<ProductCart> productItems);
    }
}
