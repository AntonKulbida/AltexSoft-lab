using System.Web.Mvc;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace MobileStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IMobileRepository repository;

        public AdminController (IMobileRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Mobiles);
        }

        public ViewResult Edit(int mobileId)
        {
            Mobile game = repository.Mobiles
                .FirstOrDefault(g => g.MobileId == mobileId);
            return View(game);
        }

        [HttpPost]
        public ActionResult Edit(Mobile mobile, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    mobile.ImageMimeType = image.ContentType;
                    mobile.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(mobile.ImageData, 0, image.ContentLength);
                }
                repository.SaveMobile(mobile);
                TempData["message"] = string.Format("Changes in \"{0}\" were saved", mobile.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(mobile);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Mobile());
        }

        [HttpPost]
        public ActionResult Delete(int mobileId)
        {
            Mobile deletedMobile = repository.DeleteMobile(mobileId);
            if (deletedMobile != null)
            {
                TempData["message"] = string.Format("Game \"{0}\" was deleted",
                    deletedMobile.Name);
            }
            return RedirectToAction("Index");
        }
	}
}