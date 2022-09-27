using MediatR;

namespace ClothingStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public List<int> ProducIds { get; set; }
    }
}
