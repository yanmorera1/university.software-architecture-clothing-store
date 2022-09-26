using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Models.ViewModels;
using ClothingStore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHanlder : IRequestHandler<GetProductsQuery, IEnumerable<ProductVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProductsQueryHanlder> _logger;
        private readonly IMapper _mapper;

        public GetProductsQueryHanlder(IUnitOfWork unitOfWork, ILogger<GetProductsQueryHanlder> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Name))
                return _mapper.Map<List<ProductVm>>(await _unitOfWork.Repository<Product>().GetAsync(p => p.Name.Contains(request.Name)));

            return _mapper.Map<IEnumerable<ProductVm>>(await _unitOfWork.Repository<Product>().GetAllAsync());
        }
    }
}
