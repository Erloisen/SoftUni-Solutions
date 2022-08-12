using AutoMapper;
using CarDealer.DTOModels.ExportModels;
using CarDealer.DTOModels.ImportModels;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Query 09. Import Suppliers
            this.CreateMap<SupplierInputModel, Supplier>();

            //Query 10. Import Parts
            this.CreateMap<PartInputModel, Part>();

            //Query 11. Import Cars
            this.CreateMap<CarsInputModel, Car>();

            //Query 12. Import Customers
            this.CreateMap<CustomerInputModel, Customer>();

            //Query 13. Import Sales
            this.CreateMap<SalesImputModel, Sale>();

            //Query 14. Export Ordered Customers
            this.CreateMap<Customer, OrderedCustomers>()
                .ForMember(oc => oc.BirthDate, mo => mo.MapFrom(c => c.BirthDate.ToString("dd/MM/yyyy")));

            //Query 15. Export Cars from Make Toyota
            this.CreateMap<Car, SpecificMakeCar>();

            //Query 16. Export Local Suppliers
            this.CreateMap<Supplier, LocalSupplier>()
                .ForMember(lc => lc.PartsCount, mo => mo.MapFrom(p => p.Parts.Count));

            //Query 17. Export Cars with Their List of Parts
            this.CreateMap<PartCar, PartExportModel>()
                .ForMember(pe => pe.Name, mo => mo.MapFrom(pc => pc.Part.Name))
                .ForMember(pe => pe.Price, mo => mo.MapFrom(pc => $"{pc.Part.Price:f2}"));

            this.CreateMap<Car, CarExportModel>();

            this.CreateMap<Car, CarsWithPartsList>()
                .ForMember(cpl => cpl.Car, mo => mo.MapFrom(c => c))
                .ForMember(cpl => cpl.PartCars, mo => mo.MapFrom(p => p.PartCars));
        }
    }
}
