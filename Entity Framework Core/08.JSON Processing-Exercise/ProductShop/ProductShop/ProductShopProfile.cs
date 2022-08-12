using AutoMapper;
using ProductShop.Data.Models.DataTranferObjects;
using ProductShop.Data.Models.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Query 1. Import Users
            this.CreateMap<UserInputModel, User>();

            //Query 2. Import Products
            this.CreateMap<ProductInputModel, Product>();

            //Query 3. Import Categories
            this.CreateMap<CategoryInputModel, Category>();

            //Query 4. Import Categories and Products
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();
        }
    }
}
