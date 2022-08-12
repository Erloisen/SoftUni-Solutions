using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOModels.ExportModels;
using CarDealer.DTOModels.ImportModels;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        private static string filePath;
        public static void Main(string[] args)
        {
            CarDealerContext carDealerContext = new CarDealerContext();
            /*
            carDealerContext.Database.EnsureDeleted();
            carDealerContext.Database.EnsureCreated();

            //Query 9. Import Suppliers
            InitializeFilePath(GlobalConstants.DatasetsImportFilePath, GlobalConstants.SuppliersJsonImportFilePath);
            ImportSuppliers(carDealerContext, File.ReadAllText(filePath));

            //Query 10. Import Parts
            InitializeFilePath(GlobalConstants.DatasetsImportFilePath, GlobalConstants.PartsJsonImportFilePath);
            ImportParts(carDealerContext, File.ReadAllText(filePath));

            //Query 11. Import Cars
            InitializeFilePath(GlobalConstants.DatasetsImportFilePath, GlobalConstants.CarsJsonImportFilePath);
            ImportCars(carDealerContext, File.ReadAllText(filePath));

            //Query 12. Import Customers
            InitializeFilePath(GlobalConstants.DatasetsImportFilePath, GlobalConstants.CustomersJsonImportFilePath);
            ImportCustomers(carDealerContext, File.ReadAllText(filePath));

            //Query 13. Import Sales
            InitializeFilePath(GlobalConstants.DatasetsImportFilePath, GlobalConstants.SalesJsonImportFilePath);
            var result = ImportSales(carDealerContext, File.ReadAllText(filePath));
            Console.WriteLine(result);

            //Query 14. Export Ordered Customers
            var orderedCustomers = GetOrderedCustomers(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.OrderedCustomersPath);
            File.WriteAllText(filePath, orderedCustomers);

            //Query 15.Export Cars from Make Toyota
            var carsFromMakeToyota = GetCarsFromMakeToyota(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.CarFromMakeToyotaPath);
            File.WriteAllText(filePath, carsFromMakeToyota);

            //Query 16. Export Local Suppliers
            var exportLocalSupplier = GetLocalSuppliers(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.ExportLocalSupplierPath);
            File.WriteAllText(filePath, exportLocalSupplier);

            //Query 17.Export Cars with Their List of Parts
            var carsWithParts = GetCarsWithTheirListOfParts(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.CarsAndPartsPath);
            File.WriteAllText(filePath, carsWithParts);

            //Query 18. Export Total Sales by Customer
            var totalSalesByCustomer = GetTotalSalesByCustomer(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.CustomersTotalSalesPath);
            File.WriteAllText(filePath, totalSalesByCustomer);
            */

            //Query 19. Export Sales with Applied Discount
            var salesWithAppliedDiscount = GetSalesWithAppliedDiscount(carDealerContext);
            InitializeFilePath(GlobalConstants.DatasetsExportFilePath, GlobalConstants.SalesWithAppliedDiscountPath);
            File.WriteAllText(filePath, salesWithAppliedDiscount);
        }

        //19. Problem
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithAppliedDiscount = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    customerName = x.Customer.Name,
                    Discount = x.Discount.ToString("f2"),
                    price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("f2"),
                    priceWithDiscount = (x.Car.PartCars.Sum(p => p.Part.Price) 
                                      - x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100).ToString("f2")
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(salesWithAppliedDiscount, Formatting.Indented);
        }

        //18. Problem
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        { 
            var totalSalesByCustomer = context.Customers
                .Where(x => x.Sales.Any(c => c.Car != null))
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.SelectMany(s => s.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            return JsonConvert.SerializeObject(totalSalesByCustomer, settings);
        }
        
        //17. Problem
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InizializeAutoMapper();

            var carsWithParts = context.Cars
                .ProjectTo<CarsWithPartsList>(mapper.ConfigurationProvider);

            var carsWithPartsToJson = JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
            return carsWithPartsToJson;
        }

        //16. Problem
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InizializeAutoMapper();

            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .OrderBy(s => s.Id)
                .ProjectTo<LocalSupplier>(mapper.ConfigurationProvider);

            var localSuppliersToJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return localSuppliersToJson;
        }

        //15. Problem
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            InizializeAutoMapper();

            string carMake = "Toyota";

            var carsFromMake = context.Cars
                .Where(c => c.Make == carMake)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<SpecificMakeCar>(mapper.ConfigurationProvider);

            var carsFromMakeToJson = JsonConvert.SerializeObject(carsFromMake, Formatting.Indented);
            return carsFromMakeToJson;
        }

        //14. Problem
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InizializeAutoMapper();

            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<OrderedCustomers>(mapper.ConfigurationProvider);

            var orderedCustomersToJson = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
            return orderedCustomersToJson;
        }

        //13. Problem
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InizializeAutoMapper();

            var salesDto = JsonConvert.DeserializeObject<ICollection<SalesImputModel>>(inputJson);
            var sales = mapper.Map<ICollection<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedDataMsg, sales.Count());
        }

        //12. Problem
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InizializeAutoMapper();

            var customerDto = JsonConvert.DeserializeObject<ICollection<CustomerInputModel>>(inputJson);
            var customers = mapper.Map<ICollection<Customer>>(customerDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedDataMsg, customers.Count());
        }

        //11. Problem
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InizializeAutoMapper();

            var cars = new List<Car>();
            var carsDto = JsonConvert.DeserializeObject<ICollection<CarsInputModel>>(inputJson);
            
            foreach (var car in carsDto)
            {
                var currentCar = mapper.Map<Car>(car);

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedDataMsg, cars.Count());

        }

        //10. Problem
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InizializeAutoMapper();

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var partsDto = JsonConvert.DeserializeObject<ICollection<PartInputModel>>(inputJson)
                .Where(x => supplierIds.Contains(x.SupplierId));

            var parts = mapper.Map<IEnumerable<Part>>(partsDto);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedDataMsg, parts.Count());
        }

        //09. Problem
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InizializeAutoMapper();

            var supplierDto = JsonConvert.DeserializeObject<ICollection<SupplierInputModel>>(inputJson);

            var supplier = mapper.Map<IEnumerable<Supplier>>(supplierDto);

            context.Suppliers.AddRange(supplier);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedDataMsg, supplier.Count());
        }

        private static void InitializeFilePath(string datasetsFilePath, string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), datasetsFilePath, fileName);
        }

        private static void InizializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}