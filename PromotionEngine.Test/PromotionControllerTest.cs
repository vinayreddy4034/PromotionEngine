using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Promotion.Model;
using PromotionEngine.Controllers;

namespace PromotionEngine.Test
{
    public class PromotionControllerTest
    {
        [Test]
        public void PromotionController_InvalidObject_AssertBadResult()
        {
            //Arrange
            Mock<IPromotionExecutor> promotionExecutorMock = new Mock<IPromotionExecutor>();
            PromotionController promotionController = new PromotionController(promotionExecutorMock.Object);
            //Act
            var result = promotionController.Calculate(null);
            //Assert
            Assert.IsInstanceOf(typeof(BadRequestResult), result);
        }

        [Test]
        public void PromotionController_ValidData_AssertSucessFullRequest()
        {
            //Arrange
            Mock<IPromotionExecutor> promotionExecutorMock = new Mock<IPromotionExecutor>();
            PromotionController promotionController = new PromotionController(promotionExecutorMock.Object);
            promotionExecutorMock.Setup(x => x.ApplyPromotion(It.IsAny<ProductCart[]>())).Returns(new OrderDetails { TotalAmount = 130 });
            //Act
            var result = promotionController.Calculate(new ProductCart[] { new ProductCart { ProductId = "A", Quantity = 5 } });
            //Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }
    }
}
