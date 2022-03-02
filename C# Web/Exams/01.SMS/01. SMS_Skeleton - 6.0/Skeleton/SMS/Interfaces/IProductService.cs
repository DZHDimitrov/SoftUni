using SMS.Models;
using System.Collections.Generic;

namespace SMS.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductViewModel> GetProducts();

        public (bool isCreated, string error) Create(CreateProductViewModel model);
    }
}
