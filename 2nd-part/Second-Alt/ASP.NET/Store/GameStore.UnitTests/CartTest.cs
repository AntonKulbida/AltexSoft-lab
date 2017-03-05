using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using MobileStore.Domain.Entities;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.WebUI.Controllers;
using MobileStore.WebUI.Models;
using System.Web.Mvc;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {

            Mobile mobile1 = new Mobile { MobileId = 1, Name = "Mobile1" };
            Mobile mobile2 = new Mobile { MobileId = 2, Name = "Mobile2" };


            Cart cart = new Cart();

            cart.AddItem(mobile1, 1);
            cart.AddItem(mobile2, 1);
            List<CartLine> results = cart.Lines.ToList();

            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Mobile, mobile1);
            Assert.AreEqual(results[1].Mobile, mobile2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            Mobile mobile1 = new Mobile { MobileId = 1, Name = "Mobile1" };
            Mobile mobile2 = new Mobile { MobileId = 2, Name = "Mobile2" };

            Cart cart = new Cart();

            cart.AddItem(mobile1, 1);
            cart.AddItem(mobile2, 1);
            cart.AddItem(mobile1, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.Mobile.MobileId).ToList();

            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);  
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            Mobile mobile1 = new Mobile { MobileId = 1, Name = "Mobile1" };
            Mobile mobile2 = new Mobile { MobileId = 2, Name = "Mobile2" };
            Mobile mobile3 = new Mobile { MobileId = 3, Name = "Mobile3" };

            Cart cart = new Cart();

            cart.AddItem(mobile1, 1);
            cart.AddItem(mobile2, 4);
            cart.AddItem(mobile3, 2);
            cart.AddItem(mobile2, 1);

            cart.RemoveLine(mobile2);

            Assert.AreEqual(cart.Lines.Where(c => c.Mobile == mobile2).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            Mobile mobile1 = new Mobile { MobileId = 1, Name = "Mobile1", Price = 100 };
            Mobile mobile2 = new Mobile { MobileId = 2, Name = "Mobile2", Price = 55 };

            Cart cart = new Cart();

            cart.AddItem(mobile1, 1);
            cart.AddItem(mobile2, 1);
            cart.AddItem(mobile1, 5);
            decimal result = cart.ComputeTotalValue();

            Assert.AreEqual(result, 655);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            Mobile mobile1 = new Mobile { MobileId = 1, Name = "Игра1", Price = 100 };
            Mobile mobile2 = new Mobile { MobileId = 2, Name = "Игра2", Price = 55 };

            Cart cart = new Cart();

            cart.AddItem(mobile1, 1);
            cart.AddItem(mobile2, 1);
            cart.AddItem(mobile1, 5);
            cart.Clear();

            Assert.AreEqual(cart.Lines.Count(), 0);
        }

        [TestMethod]
        public void Can_Add_To_Cart()
        {

            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile> {
                new Mobile {MobileId = 1, Name = "Mobile1", Category = "Cat1"},
            }.AsQueryable());

            Cart cart = new Cart();

            CartController controller = new CartController(mock.Object, null);

            controller.AddToCart(cart, 1, null);

            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToList()[0].Mobile.MobileId, 1);
        }

        [TestMethod]
        public void Adding_Game_To_Cart_Goes_To_Cart_Screen()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile> {
                new Mobile {MobileId = 1, Name = "Mobile11", Category = "Cat1"},
            }.AsQueryable());

            Cart cart = new Cart();

            CartController controller = new CartController(mock.Object, null);

            RedirectToRouteResult result = controller.AddToCart(cart, 2, "myUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            Cart cart = new Cart();

            CartController target = new CartController(null, null);

            CartIndexViewModel result
                = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }

        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            Cart cart = new Cart();

            ShippingDetails shippingDetails = new ShippingDetails();

            CartController controller = new CartController(null, mock.Object);

            ViewResult result = controller.Checkout(cart, shippingDetails);

            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Never());

            Assert.AreEqual("", result.ViewName);

            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Mobile(), 1);

            CartController controller = new CartController(null, mock.Object);

            controller.ModelState.AddModelError("error", "error");

            ViewResult result = controller.Checkout(cart, new ShippingDetails());

            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Never());

            Assert.AreEqual("", result.ViewName);

            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Mobile(), 1);

            CartController controller = new CartController(null, mock.Object);

            ViewResult result = controller.Checkout(cart, new ShippingDetails());

            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()),
                Times.Once());

            Assert.AreEqual("Completed", result.ViewName);

            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }
    }
}
