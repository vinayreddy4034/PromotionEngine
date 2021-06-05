using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promotiom.Logic;
using Promotion.DAL;
using Promotion.Model;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    public class PromotionExecutorTest
    {
        private PromotionContext promotionContext;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<PromotionContext>()
     .UseInMemoryDatabase("PromotionTestDB")
     .Options;
            promotionContext = new PromotionContext(options);
        }

        [Test]
        public void PromotionExecutor_ConstructObject_AssertArgumentNullException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => { IPromotionExecutor promotionExecutor = new PromotionExecutor(null); });
        }


        [Test]
        public void PromotionExecutor_ApplyPromotionEmptyProductCart_AssertArgumentNullException()
        {
            //Arrange
            IPromotionExecutor promotionExecutor = new PromotionExecutor(promotionContext);
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => { promotionExecutor.ApplyPromotion(null); });
        }

        [Test,Sequential]
        public void PromotionExecutor_ApplyPromotionEmptyProductCart_AssertExpectedPrice([ValueSource("TestProducts")] List<ProductCart> productCarts, [ValueSource("TestTotalAmounts")] double expectedPrice)
        {
            //Arrange
            IPromotionExecutor promotionExecutor = new PromotionExecutor(promotionContext);
            //Act
            var orderDetails = promotionExecutor.ApplyPromotion(productCarts);
            //Assert
            Assert.That(orderDetails.TotalAmount == expectedPrice, "Total amount is wrong");
        }

        private static List<ProductCart>[] TestProducts()
        {
            return new List<ProductCart>[] { 
                new List<ProductCart> { new ProductCart {ProductId="A",Quantity=5 } },
                 new List<ProductCart> { new ProductCart {ProductId="A",Quantity=2 } },
                 new List<ProductCart> { new ProductCart {ProductId="C",Quantity=1 }, new ProductCart { ProductId = "D", Quantity = 1 } }
            };
        }

        private static double[] TestTotalAmounts()
        {
            return new double[] { 230,100,30 };
        }
    }
}