using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Controllers;
using MobileStore.WebUI.Models;
using MobileStore.WebUI.HtmlHelpers;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Mobile1"},
                new Mobile { MobileId = 2, Name = "Mobile2"},
                new Mobile { MobileId = 3, Name = "Mobile3"},
                new Mobile { MobileId = 4, Name = "Mobile4"},
                new Mobile { MobileId = 5, Name = "Mobile5"}
            });
            MobileController controller = new MobileController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            MobilesListViewModel result = (MobilesListViewModel)controller.List(null, 2).Model;

            // Утверждение
            List<Mobile> mobiles = result.Mobiles.ToList();
            Assert.IsTrue(mobiles.Count == 2);
            Assert.AreEqual(mobiles[0].Name, "Mobile4");
            Assert.AreEqual(mobiles[1].Name, "Mobile5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Mobile1"},
                new Mobile { MobileId = 2, Name = "Mobile2"},
                new Mobile { MobileId = 3, Name = "Mobile3"},
                new Mobile { MobileId = 4, Name = "Mobile4"},
                new Mobile { MobileId = 5, Name = "Mobile5"}
            });
            MobileController controller = new MobileController(mock.Object);
            controller.pageSize = 3;

            // Act
            MobilesListViewModel result
                = (MobilesListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Games()
        {
            // Организация (arrange)
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Mobile1", Category="Cat1"},
                new Mobile { MobileId = 2, Name = "Mobile2", Category="Cat2"},
                new Mobile { MobileId = 3, Name = "Mobile3", Category="Cat1"},
                new Mobile { MobileId = 4, Name = "Mobile4", Category="Cat2"},
                new Mobile { MobileId = 5, Name = "Mobile5", Category="Cat3"}
            });
            MobileController controller = new MobileController(mock.Object);
            controller.pageSize = 3;

            // Action
            List<Mobile> result = ((MobilesListViewModel)controller.List("Cat2", 1).Model)
                .Mobiles.ToList();

            // Assert
            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Name == "Mobile2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "Mobile4" && result[1].Category == "Cat2");
        }

        [TestMethod]
        public void Can_Create_Categories()
        {
            // Организация - создание имитированного хранилища
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile> {
                new Mobile { MobileId = 1, Name = "Mobile1", Category="Sumsung"},
                new Mobile { MobileId = 2, Name = "Mobile2", Category="Nokia"},
                new Mobile { MobileId = 3, Name = "Mobile3", Category="Fly"},
                new Mobile { MobileId = 4, Name = "Mobile4", Category="Prestigio"},
            });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Действие - получение набора категорий
            List<string> results = ((IEnumerable<string>)target.Menu().Model).ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 3);
            Assert.AreEqual(results[0], "Samsung");
            Assert.AreEqual(results[1], "Nokia");
            Assert.AreEqual(results[2], "Fly");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Организация - создание имитированного хранилища
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new Mobile[] {
                new Mobile { MobileId = 1, Name = "Mobile1", Category="Nokia"},
                new Mobile { MobileId = 2, Name = "Mobile2", Category="Prestigio"}
            });

            // Организация - создание контроллера
            NavController target = new NavController(mock.Object);

            // Организация - определение выбранной категории
            string categoryToSelect = "Fly";

            // Действие
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Утверждение
            Assert.AreEqual(categoryToSelect, result);
        }

        [TestMethod]
        public void Generate_Category_Specific_Game_Count()
        {
            /// Организация (arrange)
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile>
            {
                new Mobile { MobileId = 1, Name = "Mobile1", Category="Cat1"},
                new Mobile { MobileId = 2, Name = "Mobile2", Category="Cat2"},
                new Mobile { MobileId = 3, Name = "Mobile3", Category="Cat1"},
                new Mobile { MobileId = 4, Name = "Mobile4", Category="Cat2"},
                new Mobile { MobileId = 5, Name = "Mobile5", Category="Cat3"}
            });
            MobileController controller = new MobileController(mock.Object);
            controller.pageSize = 3;

            // Действие - тестирование счетчиков товаров для различных категорий
            int res1 = ((MobilesListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((MobilesListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((MobilesListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((MobilesListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

            // Утверждение
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(resAll, 5);
        }
    }
}
