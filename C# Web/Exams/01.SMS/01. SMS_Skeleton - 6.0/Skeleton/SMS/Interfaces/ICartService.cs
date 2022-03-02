using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Interfaces
{
    public interface ICartService
    {
        public IEnumerable<CartViewModel> AddProduct(string productId, string userId);

        public IEnumerable<CartViewModel> GetProducts(string userId);

        public bool BuyProducts(string userId);
        
    }
}
