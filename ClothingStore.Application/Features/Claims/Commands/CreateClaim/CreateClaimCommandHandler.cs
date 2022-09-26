using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ClothingStore.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateClaimCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateClaimCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateClaimCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = _mapper.Map<Claim>(request);
            await _unitOfWork.Repository<Claim>().AddAsync(claim);
            await SendEmailToAdmin();
            return claim.Id;
        }

        private async Task SendEmailToAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
