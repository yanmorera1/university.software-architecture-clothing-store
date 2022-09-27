using AutoMapper;
using ClothingStore.Application.Features.Claims.Commands.CreateClaim;
using ClothingStore.Application.Features.Products.Commands.CreateProduct;
using ClothingStore.Application.Models.ViewModels;
using ClothingStore.Domain;

namespace ClothingStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Commands
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateClaimCommand, Claim>();
            #endregion

            #region Queries
            CreateMap<Product, ProductVm>();
            CreateMap<Claim, ClaimVm>();
            #endregion
        }
    }
}
