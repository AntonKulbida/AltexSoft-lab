using System.Linq;
using System.Web.Mvc;
using MobileStore.Domain.Entities;
using MobileStore.Domain.Abstract;
using MobileStore.WebUI.Models;

namespace MobileStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMobileRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IMobileRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int gameId, string returnUrl)
        {
            Mobile game = repository.Mobiles
                .FirstOrDefault(g => g.MobileId == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int mobileId, string returnUrl)
        {
            Mobile mobile = repository.Mobiles
                .FirstOrDefault(g => g.MobileId == mobileId);

            if (mobile != null)
            {
                cart.RemoveLine(mobile);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
	}
}