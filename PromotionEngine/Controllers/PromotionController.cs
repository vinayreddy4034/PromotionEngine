using Microsoft.AspNetCore.Mvc;
using Promotion.Model;

namespace PromotionEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionController : ControllerBase
    {

        private readonly IPromotionExecutor _promotionExecutor;
        public PromotionController(IPromotionExecutor promotionExecutor)
        {
            _promotionExecutor = promotionExecutor;
        }

        [HttpPost]
        public IActionResult Calculate(ProductCart[] productCarts)
        {
            if(productCarts == null)
            {
                return BadRequest();
            }
            return Ok(_promotionExecutor.ApplyPromotion(productCarts));
        }
    }
}
