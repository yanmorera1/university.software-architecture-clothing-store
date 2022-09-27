using ClothingStore.Application.Models.ViewModels;
using MediatR;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderVm>
    {
        public int OrderId { get; set; }
    }
}
