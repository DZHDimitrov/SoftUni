using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            var jsonCategoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            var jsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            var jsonUsers = File.ReadAllText("../../../Datasets/users.json");
            var jsonProducts = File.ReadAllText("../../../Datasets/products.json");

            ImportUsers(dbContext, jsonUsers);
            ImportProducts(dbContext, jsonProducts);
            ImportCategories(dbContext, jsonCategories);
            ImportCategoryProducts(dbContext, jsonCategoryProducts);

            var result = GetUsersWithProducts(dbContext);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = LoadData<CategoryProduct>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = LoadData<Category>(inputJson);
            categories = categories.Where(c => c.Name != null);
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = LoadData<User>(inputJson);
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = LoadData<Product>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(products, GetJsonSettings());
            //File.WriteAllText("../../../Datasets/products-in-range.json", json);
            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Where(ps => ps.Buyer != null).Count() >= 1)
                .OrderBy(u=> u.LastName)
                .ThenBy(u=> u.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(ps => new
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName
                    })
                })
                .ToList();
            var json = JsonConvert.SerializeObject(users,GetJsonSettings());
            //File.WriteAllText("../../../Datasets/get-sold-products.json", json);
            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count())
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
                })
                .ToList();
            var json = JsonConvert.SerializeObject(categories, GetJsonSettings());
            //File.WriteAllText("../../../Datasets/get-categories-by-products-count.json", json);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersCount = context.Users.Where(u => u.ProductsSold.Where(ps => ps.Buyer != null).Count() >= 1).Count();

            var users = context.Users
               .Include(x => x.ProductsSold)
               .ToList()
               .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
               .Select(x => new
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   age = x.Age,
                   soldProducts = new
                   {
                       count = x.ProductsSold.Where(b => b.BuyerId != null).Count(),
                       products = x.ProductsSold.Where(b => b.BuyerId != null).Select(p => new
                       {
                           name = p.Name,
                           price = p.Price
                       })
                       .ToList()
                   }
               })
               .ToList()
               .OrderByDescending(x => x.soldProducts.products.Count())
               .ToList();

            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver
            };

            var json = JsonConvert.SerializeObject(resultObject, jsonSettings);
            //File.WriteAllText("../../../Datasets/get-users-with-products.json", json);
            return json;
        }

        private static JsonSerializerSettings GetJsonSettings()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            };
            return jsonSettings;
        }

        public static IEnumerable<T> LoadData<T>(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}