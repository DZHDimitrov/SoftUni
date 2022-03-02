using Microsoft.EntityFrameworkCore;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Interfaces;
using SMS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {
            repo = _repo;
        }

        public IEnumerable<ProductViewModel> GetCartProducts(string userId)
        {
            return repo
                .All<Product>()
                .Where(p => p.Cart.User.Id == userId)
                .Select(p => new ProductViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price
                })
                .ToList();
        }

        public IEnumerable<CartViewModel> AddProduct(string productId, string userId)
        {
            var cart = repo.All<Cart>().Where(c => c.User.Id == userId).FirstOrDefault();

            var product = repo.All<Product>().FirstOrDefault(p => p.Id == productId);

            try
            {
                cart.Products.Add(product);
                repo.SaveChanges();

            }
            catch (System.Exception)
            { }

            return repo
                .All<Product>()
                .Where(p => p.Cart.User.Id == userId)
                .Select(p => new CartViewModel
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("f2"),

                }).ToList();
        }

        public bool BuyProducts(string userId)
        {
            var areBought = true;

            var cart = repo
                .All<Cart>()
                .Include(c => c.Products)
                .Where(c => c.User.Id == userId)
                .FirstOrDefault();

            try
            {
                cart.Products.Clear();
                repo.SaveChanges();

            }
            catch (System.Exception)
            {
                areBought = false;
            }

            return areBought;
        }

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            return repo.All<Product>().Where(p => p.Cart.User.Id == userId).Select(p => new CartViewModel { ProductName = p.Name, ProductPrice = p.Price.ToString() });
        }
    }
}
