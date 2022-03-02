using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Interfaces;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request,IProductService _productService) : base(request)
        {
            productService = _productService;
        }


        [Authorize]
        public Response Create()
        {
            return View(new {IsAuthenticated = true});
        }

        [HttpPost]
        [Authorize]
        public Response Create(CreateProductViewModel model)
        {
            var (isCreated, error) = productService.Create(model);

            if (!isCreated)
            {
                return View(new { ErrorMessage = error },"/Error");
            }

            return Redirect("/");
        }
    }
}
