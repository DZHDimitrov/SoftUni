using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Interfaces;
using SMS.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public ProductService(IValidationService _validationService,IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;
        }

        public (bool isCreated, string error) Create(CreateProductViewModel model)
        {
            bool created = true;
            string error = null;

            var (isValid,validationError) = validationService.ValidateModel(model);

            var errors = new List<string>();

            if (!isValid)
            {
                errors.Add(validationError);
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price,NumberStyles.Float,CultureInfo.InvariantCulture,out price) || price <0.05M || price > 1000M)
            {
                errors.Add("Incorrect price");
            }

            if (!isValid)
            {
                return (false, string.Join(", ", errors));
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = price,
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();

            }
            catch (System.Exception)
            {
                created = false;
                error = "Could not save in database";
            }

            return (created, error);
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return repo
                .All<Product>()
                .Select(p => new ProductViewModel 
                { 
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price 
                })
                .ToList();
        }
    }
}
