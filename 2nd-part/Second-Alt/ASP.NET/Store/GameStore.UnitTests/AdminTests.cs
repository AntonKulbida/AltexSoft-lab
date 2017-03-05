using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Games()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);

            List<Mobile> result = ((IEnumerable<Mobile>)controller.Index().
                ViewData.Model).ToList();

            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual("Product1", result[0].Name);
            Assert.AreEqual("Product2", result[1].Name);
            Assert.AreEqual("Product3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Mobile()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);

            Mobile game1 = controller.Edit(1).ViewData.Model as Mobile;
            Mobile game2 = controller.Edit(2).ViewData.Model as Mobile;
            Mobile game3 = controller.Edit(3).ViewData.Model as Mobile;

            Assert.AreEqual(1, game1.MobileId);
            Assert.AreEqual(2, game2.MobileId);
            Assert.AreEqual(3, game3.MobileId);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Mobile()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);

            Mobile result = controller.Edit(6).ViewData.Model as Mobile;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();

            AdminController controller = new AdminController(mock.Object);

            Mobile mobile = new Mobile { Name = "Test" };

            ActionResult result = controller.Edit(mobile, null);

            mock.Verify(m => m.SaveMobile(mobile));

            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();

            AdminController controller = new AdminController(mock.Object);

            Mobile game = new Mobile { Name = "Test" };

            controller.ModelState.AddModelError("error", "error");

            ActionResult result = controller.Edit(game, null);

            mock.Verify(m => m.SaveMobile(It.IsAny<Mobile>()), Times.Never());

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Mobiles()
        {
            Mobile mobile = new Mobile { MobileId = 2, Name = "Name2" };

            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            AdminController controller = new AdminController(mock.Object);

            controller.Delete(mobile.MobileId);

            mock.Verify(m => m.DeleteMobile(mobile.MobileId));
        }
    }
}
