using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MobileStore.Domain.Abstract;

namespace MobileStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IMobileRepository repository;

        public NavController(IMobileRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Mobiles
                .Select(mobile => mobile.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
	}
}