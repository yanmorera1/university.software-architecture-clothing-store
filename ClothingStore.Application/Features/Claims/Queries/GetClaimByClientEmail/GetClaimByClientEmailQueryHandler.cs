using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Models.ViewModels;
using ClothingStore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Application.Features.Claims.Queries.GetClaimByClientEmail
{
    public class GetClaimByClientEmailQueryHandler : IRequestHandler<GetClaimByClientEmailQuery, IEnumerable<ClaimVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetClaimByClientEmailQueryHandler> _logger;

        public GetClaimByClientEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetClaimByClientEmailQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ClaimVm>> Handle(GetClaimByClientEmailQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ClaimVm>>(await _unitOfWork.Repository<Claim>().GetAsync(c => c.Email == request.ClientEmail));
        }
    }
}
