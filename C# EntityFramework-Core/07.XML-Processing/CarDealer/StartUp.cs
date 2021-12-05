using CarDealer.Data;
using CarDealer.DataTransferObjects.Export;
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
            ImportSales(context, salesXml);
            GetCarsWithDistance(context);
            GetCarsFromMakeBmw(context);
            GetLocalSuppliers(context);
            GetCarsWithTheirListOfParts(context);
            GetTotalSalesByCustomer(context);
            GetSalesWithAppliedDiscount(context);

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSaleWithAppliedDiscountDtoXML
                {
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Car = new ExportCarDtoXML
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            var xml = XmlConvert.Serialize(sales,"sales");
            return xml;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                 .Where(c => c.Sales.Any())
                 .Select(c => new ExportCustomerWithAtleastOneCardDtoXML
                 {
                     FullName = c.Name,
                     BoughtCars = c.Sales.Count,
                     SpentMoney = c.Sales.Select(s => s.Car).SelectMany(s => s.PartCars).Sum(s => s.Part.Price)
                 })
                 .OrderByDescending(x => x.SpentMoney)
                 .ToArray();

            var xml = XmlConvert.Serialize(customers, "customers");
            return xml;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars.
                Select(c => new ExportCarWithPartsDtoXML
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(pc => new ExportCarPartsDtoXML
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var xml = XmlConvert.Serialize(carsWithParts, "cars");
            return xml;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportSuppliersNotAbroadDtoXML
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var xml = XmlConvert.Serialize(suppliers, "suppliers");
            return xml;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarsFromBMWDtoXML
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();
            var xml = XmlConvert.Serialize<ExportCarsFromBMWDtoXML[]>(cars, "cars");
            return xml;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarsDistanceDtoXML
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlResult = XmlConvert.Serialize<ExportCarsDistanceDtoXML[]>(cars, "cars");
            ;
            return xmlResult;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";
            var deserializedSales = XmlConvert.Deserialize<ImportSalesDTO>(inputXml, root);
            var sales =
                deserializedSales
                .Where(s => s.CarId != null && context.Cars.Any(c => c.Id == s.CarId))
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