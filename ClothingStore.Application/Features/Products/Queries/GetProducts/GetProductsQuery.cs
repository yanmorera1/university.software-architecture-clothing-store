using ClothingStore.Application.Models.ViewModels;
using MediatR;

namespace ClothingStore.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductVm>>
    {
        public string? Name { get; set; }
    }
}
