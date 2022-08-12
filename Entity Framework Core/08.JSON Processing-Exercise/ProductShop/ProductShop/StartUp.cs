using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using Newtonsoft.Json;

namespace ProductShop
{
    using Data;
    using Data.Models.DataTranferObjects;
    using Data.Models.Models;
    public class StartUp
    {
        static IMapper mapper;
        static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();
            /*
            productShopContext.Database.EnsureDeleted();
            productShopContext.Database.EnsureCreated();
            //Query 1. Import Users
            string inputJson = File.ReadAllText("../../../Datasets/users.json");
            ImportUsers(productShopContext, inputJson);

            //Query 2. Import Products
            inputJson = File.ReadAllText("../../../Datasets/products.json");
            ImportProducts(productShopContext, inputJson);

            //Query 3. Import Categories
            inputJson = File.ReadAllText("../../../Datasets/categories.json");
            ImportCategories(productShopContext, inputJson);
            
            //Query 4. Import Categories and Products
            inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            var result = ImportCategoryProducts(productShopContext, inputJson);
            Console.WriteLine(result);

            */
            //Query 5. Export Products in Range
            var productsInRange = GetProductsInRange(productShopContext);
            Console.WriteLine(productsInRange);

            //Query 6. Export Sold Products

        }

        //05. Problem
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
                })
                .OrderBy(p => p.Price)
                .ToList();

            var productsToJson = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return productsToJson;
        }

        //04. Problem
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedData, categoriesProducts.Count());
        }

        //03. Problem
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoCategories = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedData, categories.Count());
        }

        //02.Problem
        public static string ImportProducts(ProductShopContext context, string inputJson)
        { 
            InitializeAutomapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedData, products.Count());
        }

        //01. Problem
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutomapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return String.Format(GlobalConstants.SuccessfullyImportedData, users.Count());
        }
        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}
