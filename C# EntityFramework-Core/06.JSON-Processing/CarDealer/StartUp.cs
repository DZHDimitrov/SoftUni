using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var jsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            var jsonParts = File.ReadAllText("../../../Datasets/parts.json");
            var jsonCars = File.ReadAllText("../../../Datasets/cars.json");
            var jsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            var jsonSales = File.ReadAllText("../../../Datasets/sales.json");
            ImportSuppliers(context, jsonSuppliers);
            ImportParts(context, jsonParts);
            ImportCars(context, jsonCars);
            ImportCustomers(context, jsonCustomers);
            ImportSales(context, jsonSales);

            var result = GetSalesWithAppliedDiscount(context);
        }

        //exports
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToList();
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            //File.WriteAllText("../../../Datasets/get-ordered-customers.json", json);
            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                car = new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                },
                parts = c.PartCars
                .Select(pc => new
                {
                    Name = pc.Part.Name,
                    Price = $"{pc.Part.Price:f2}"
                })
                .ToList()
            })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            //File.WriteAllText("../../../Datasets/get-cars-with-their-list-of-parts.json", json);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenBy(c => c.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            //File.WriteAllText("../../../Datasets/get-total-sales-by-customer.json", json);
            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100):f2}"
                })
                .ToList();
            var json = JsonConvert.SerializeObject(sales,Formatting.Indented);
            //File.WriteAllText("../../../Datasets/get-sales-with-applied-discount", json);
            return json;
        }

        //imports
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = LoadData<Supplier>(inputJson);
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported { suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var suppliers = context.Suppliers.Select(x => x.Id).ToArray();

            List<Part> parts = LoadData<Part>(inputJson)
                .Where(x => suppliers.Contains(x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarPartsDTO> cars = JsonConvert.DeserializeObject<List<CarPartsDTO>>(inputJson);

            foreach (var car in cars)
            {
                Car currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId)
                {
                    bool isValid = currentCar.PartCars.FirstOrDefault(x => x.PartId == part) == null;
                    bool isPartValid = context.Parts.FirstOrDefault(p => p.Id == part) != null;

                    if (isValid && isPartValid)
                    {
                        currentCar.PartCars.Add(new PartCar()
                        {
                            PartId = part
                        });
                    }
                }

                context.Cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = LoadData<Customer>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }

        private static IEnumerable<T> LoadData<T>(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}