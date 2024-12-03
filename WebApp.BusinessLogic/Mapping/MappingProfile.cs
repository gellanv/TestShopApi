using AutoMapper;
using WebApp.BusinessLogic.Models.Request;
using WebApp.BusinessLogic.Models.Response;
using WebApp.DataAccess.Entities;

namespace WebApp.BusinessLogic.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        _ = this.CreateMap<CategoryModel, Category>().ReverseMap();
        _ = this.CreateMap<CustomerModel, Customer>().ReverseMap();
        _ = this.CreateMap<ProductModel, Product>().ReverseMap();
        _ = this.CreateMap<PurchaseModel, Purchase>().ReverseMap();
        _ = this.CreateMap<PurchaseProductModel, PurchaseProduct>().ReverseMap();

        _ = CreateMap<Customer, BirthdayCustomer>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.MiddleName} {src.LastName}".Trim()));

        _ = CreateMap<Purchase, RecentCustomerPurphase>()
            .ForMember(dest => dest.LastPurchaseDate, opt => opt.MapFrom(src => src.PurchaseDate))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Customer.Id))
            .ForMember(dest => dest.FullName, opt => opt.Ignore());
    }
}
