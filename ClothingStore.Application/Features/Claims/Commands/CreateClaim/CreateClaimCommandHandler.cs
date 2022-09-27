using AutoMapper;
using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Contracts.Services;
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
        private readonly IEmailService _emailService;

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
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.RelatedProductId);
            await SendEmailToAdmin(product, request.Names ,request.Email, request.Message);
            return claim.Id;
        }

        private async Task SendEmailToAdmin(Product product, string names, string email, string comment)
        {
            var message = @$"Ha recibido un reclamo de {names} por el producto {product.Name} 
                            con id {product.Id} con el comentario: {comment}";
            await _emailService.SendEmailAsync(email, message);
        }
    }
}
