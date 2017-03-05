using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MobileStore.UnitTests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            Mobile mobile = new Mobile
            {
                MobileId = 2,
                Name = "Mobile2",
                ImageData = new byte[] { },
                ImageMimeType = "image/png"
            };

            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile> {
                new Mobile {MobileId = 1, Name = "Mobile1"},
                mobile,
                new Mobile {MobileId = 3, Name = "Mobile3"}
            }.AsQueryable());

            MobileController controller = new MobileController(mock.Object);

            ActionResult result = controller.GetImage(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(mobile.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            Mock<IMobileRepository> mock = new Mock<IMobileRepository>();
            mock.Setup(m => m.Mobiles).Returns(new List<Mobile> {
                new Mobile {MobileId = 1, Name = "Mobile1"},
                new Mobile {MobileId = 2, Name = "Mobile2"}
            }.AsQueryable());

            MobileController controller = new MobileController(mock.Object);

            ActionResult result = controller.GetImage(10);

            Assert.IsNull(result);
        }
    }
}
