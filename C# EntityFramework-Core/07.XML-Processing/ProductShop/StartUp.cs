using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var usersXML = File.ReadAllText("../../../Datasets/users.xml");
            var productsXML = File.ReadAllText("../../../Datasets/products.xml");
            var categoryXML = File.ReadAllText("../../../Datasets/categories.xml");
            var categoryProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");
            ImportUsers(context, usersXML);
            ImportProducts(context, productsXML);
            ImportCategories(context, categoryXML);
            ImportUsers(context, usersXML);
            ImportProducts(context, productsXML);
            ImportCategories(context, categoryXML);
            ImportCategoryProducts(context, categoryProductsXML);
            GetSoldProducts(context);
            GetCategoriesByProductsCount(context);
            GetProductsInRange(context);
            var result = GetUsersWithProducts(context);
            System.Console.WriteLine(result);
        }
        
         public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count())
                .Select(u => new ExportUserAndHisProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDTO
                    {
                        Count = u.ProductsSold.Count,
                        SoldProducts = u.ProductsSold
                        .Select(p => new ExportSoldProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                    }
                })
                .ToList();

            var usersToExport = new ExportUsersDTO
            {
                Count = users.Count,
                Users = users.Take(10).ToList(),
            };

            var serializedUsers = XmlConvert.Serialize(usersToExport, root);
            return serializedUsers;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ExportProductsInRangeDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Take(10)
                .ToList();
            var serializedProducts = XmlConvert.Serialize(products, root);
            return serializedProducts;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";
            var categories = context.Categories
                .Select(c => new ExportCategoryDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var serializedCategories = XmlConvert.Serialize(categories, root);
            return serializedCategories;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(x => new UserSoldProducts
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(sp => new SoldProduct
                    {
                        Name = sp.Name,
                        Price = sp.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            var serializedUsers = XmlConvert.Serialize(users, root);
            return serializedUsers;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            var serializedCategoryProducts = XmlConvert.Deserialize<ImportCategoryProductDTO>(inputXml, root);

            var categoryProducts = serializedCategoryProducts
                .Where(cp => context.Categories.Any(c=> c.Id == cp.CategoryId) && context.Products.Any(p => p.Id == cp.ProductId))
                .Select(cp => new CategoryProduct 
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId 
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";
            var serializezCategories = XmlConvert.Deserialize<ImportCategoryDTO>(inputXml, root);

            var categories = serializezCategories
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }
        
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            //var attr = new XmlRootAttribute("Products");

            //var serializer = new XmlSerializer(typeof(ImportProductDTO[]), attr);

            //ImportProductDTO[] deserializedProducts = serializer.Deserialize(new StringReader(inputXml)) as ImportProductDTO[];

            const string root = "Products";
            var deserializedProducts = XmlConvert.Deserialize<ImportProductDTO>(inputXml, root);
            ;

            var currentProducts = deserializedProducts.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                BuyerId = x.BuyerId,
                SellerId = x.SellerId,
            })
                .ToList();
            context.Products.AddRange(currentProducts);
            context.SaveChanges();
            return $"Successfully imported {currentProducts.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var attr = new XmlRootAttribute("Users");

            var serializer = new XmlSerializer(typeof(ImportUserDTO[]), attr);

            ImportUserDTO[] deserializedUsers = serializer.Deserialize(new StringReader(inputXml)) as ImportUserDTO[];
            var users = deserializedUsers
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {context.Users.Count()}";
        }
    }
}
