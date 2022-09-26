using ClothingStore.Application.Models.ViewModels;
using MediatR;

namespace ClothingStore.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommand : ClaimVm, IRequest<int>
    {
    }
}
