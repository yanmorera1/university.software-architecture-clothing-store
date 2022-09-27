using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Exceptions;
using ClothingStore.Application.Models.ViewModels;
using ClothingStore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetOrderByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetOrderByIdQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OrderVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(request.OrderId);
            if (order == null)
                throw new NotFoundException($"Order with id {request.OrderId} was not found");
            var orderDetails = await _unitOfWork.Repository<OrderDetail>().GetAsync(od => od.OrderId == order.Id);
            var orderDetailProducIds = orderDetails.Select(od => od.ProductId);
            var products = _mapper.Map<IEnumerable<ProductVm>>(await _unitOfWork.Repository<Product>().GetAsync(p => orderDetailProducIds.Contains(p.Id)));
            var orderVm = new OrderVm
            {
                RelatedProducts = products.ToList(),
                TotalPrice = order.TotalPrice
            };
            return orderVm;
        }
    }
}
