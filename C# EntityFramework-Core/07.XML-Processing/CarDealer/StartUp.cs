using CarDealer.Data;
using CarDealer.DataTransferObjects.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            ImportSuppliers(context, suppliersXml);
            ImportParts(context, partsXml);
            ImportCars(context, carsXml);
            ImportCustomers(context, customersXml);
            var result = ImportSales(context, salesXml);
            System.Console.WriteLine(result);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";
            var deserializedSales = XmlConvert.Deserialize<ImportSalesDTO>(inputXml, root);
            var sales =
                deserializedSales
                .Where(s => s.CarId != null && context.Cars.Any(c=> c.Id == s.CarId))
                .Select(s => new Sale
                {
                    Discount = s.Discount,
                    CarId = (int)s.CarId,
                    CustomerId = s.CustomerId
                })
                .ToArray();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string root = "Customers";
            var deserializedCustomers = XmlConvert.Deserialize<ImportCustomerDTO>(inputXml, root);
            var customers = deserializedCustomers
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();
            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";
            var deserializedSuppliers = XmlConvert.Deserialize<ImportSuppliersDTO>(inputXml, root);
            var suppliers = deserializedSuppliers.Select(s => new Supplier { Name = s.Name, IsImporter = s.IsImporter }).ToArray();
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";
            var deserializedparts = XmlConvert.Deserialize<ImportPartsDTO>(inputXml, root);
            var parts = deserializedparts
                .Where(s => s.SupplierId != null & context.Suppliers.Any(x => x.Id == s.SupplierId))
                .Select(s => new Part
                {
                    Name = s.Name,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    SupplierId = (int)s.SupplierId
                })
                .ToList();
            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var carsDto = XmlConvert.Deserialize<ImportCarsDTO>(inputXml, root);

            var cars = new List<Car>();

            var allParts = context.Parts.Select(x => x.Id).ToList();

            foreach (var currentCar in carsDto)
            {
                var distinctedParts = currentCar.Parts.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(allParts);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TravelledDistance
                };

                foreach (var part in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = part
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}";
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}