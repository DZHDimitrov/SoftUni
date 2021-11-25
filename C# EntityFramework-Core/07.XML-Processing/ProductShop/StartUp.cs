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
            var result = ImportCategoryProducts(context, categoryProductsXML);
            System.Console.WriteLine(result);
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