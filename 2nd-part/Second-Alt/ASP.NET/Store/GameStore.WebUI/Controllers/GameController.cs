using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStore.Domain.Abstract;
using MobileStore.Domain.Entities;
using MobileStore.WebUI.Models;

namespace MobileStore.WebUI.Controllers
{
    public class MobileController : Controller
    {
        private IMobileRepository repository;
        public int pageSize = 4;

        public MobileController(IMobileRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            MobilesListViewModel model = new MobilesListViewModel
            {
                Mobiles = repository.Mobiles
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.MobileId)
                    .Skip((page - 1)*pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                        repository.Mobiles.Count() :
                        repository.Mobiles.Where(mobile => mobile.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int mobileId)
        {
            Mobile mobile = repository.Mobiles
                .FirstOrDefault(g => g.MobileId == mobileId);

            if (mobile != null)
            {
                return File(mobile.ImageData, mobile.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
	}
}