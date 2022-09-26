using ClothingStore.Application.Models.ViewModels;
using MediatR;

namespace ClothingStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ProductVm, IRequest<int>
    {
    }
}
