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
            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            List<Mobile> result = ((IEnumerable<Mobile>)controller.Index().
                ViewData.Model).ToList();

            // Утверждение
            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual("Product1", result[0].Name);
            Assert.AreEqual("Product2", result[1].Name);
            Assert.AreEqual("Product3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Mobile()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            Mobile game1 = controller.Edit(1).ViewData.Model as Mobile;
            Mobile game2 = controller.Edit(2).ViewData.Model as Mobile;
            Mobile game3 = controller.Edit(3).ViewData.Model as Mobile;

            // Assert
            Assert.AreEqual(1, game1.MobileId);
            Assert.AreEqual(2, game2.MobileId);
            Assert.AreEqual(3, game3.MobileId);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Mobile()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            Mobile result = controller.Edit(6).ViewData.Model as Mobile;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Mobile
            Mobile mobile = new Mobile { Name = "Test" };

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(mobile, null);

            // Утверждение - проверка того, что к хранилищу производится обрашение
            mock.Verify(m => m.SaveMobile(mobile));

            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Mobile
            Mobile game = new Mobile { Name = "Test" };

            // Организация - добавление ошибки в состояние модели
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(game, null);

            // Утверждение - проверка того, что обрашение к хранилищу НЕ производится 
            mock.Verify(m => m.SaveMobile(It.IsAny<Mobile>()), Times.Never());

            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Mobiles()
        {
            // Организация - создание объекта Mobile
            Mobile mobile = new Mobile { MobileId = 2, Name = "Name2" };

            // Организация - создание имитированного хранилища данных
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Product1"},
                new Mobile { MobileId = 2, Name = "Product2"},
                new Mobile { MobileId = 3, Name = "Product3"},
                new Mobile { MobileId = 4, Name = "Product4"},
                new Mobile { MobileId = 5, Name = "Product5"}
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие - удаление mobile
            controller.Delete(mobile.MobileId);

            // Утверждение - проверка того, что метод удаления в хранилище
            // вызывается для корректного объекта Mobile
            mock.Verify(m => m.DeleteMobile(mobile.MobileId));
        }
    }
}
