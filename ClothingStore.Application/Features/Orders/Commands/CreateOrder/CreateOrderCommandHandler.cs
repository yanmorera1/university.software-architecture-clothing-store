using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Exceptions;
using ClothingStore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateOrderCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Repository<Product>().GetAsync(p => request.ProducIds.Contains(p.Id) && p.Available);
            if (products == null)
                throw new BadRequestException("The products listed in the order are not found or are not available");

            var order = new Order()
            {
                TotalPrice = products.Sum(p => p.Price)
            };
            await _unitOfWork.Repository<Order>().AddAsync(order);

            foreach (var product in products)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = product.Id,
                    OrderId = order.Id,
                    Price = product.Price
                };
                _unitOfWork.Repository<OrderDetail>().AddEntity(orderDetail);
            }
            await _unitOfWork.Complete();
            return order.Id;
        }
    }
}
