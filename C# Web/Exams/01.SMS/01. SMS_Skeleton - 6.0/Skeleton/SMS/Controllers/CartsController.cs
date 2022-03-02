using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private ICartService cartService;

        public CartsController(Request request,ICartService _cartService) : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);
            return View(new { Products = products });
        }

        public Response AddProduct(string productId)
        {
            var products = cartService.AddProduct(productId, User.Id);

            return View(new { products = products },"/Carts/Details");
        }

        public Response Buy()
        {
            var areBought = cartService.BuyProducts(User.Id);

            if (areBought)
            {
                return Redirect("/");
            }

            return View();
        }
    }
}
