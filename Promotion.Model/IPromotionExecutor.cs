
using System.Collections.Generic;
namespace Promotion.Model
{
    public interface IPromotionExecutor
    {
        Order ApplyPromotion(IEnumerable<ProductCart> productItems);
    }
}
