using ClothingStore.Application.Models.ViewModels;
using MediatR;

namespace ClothingStore.Application.Features.Claims.Queries.GetClaimByClientEmail
{
    public class GetClaimByClientEmailQuery : IRequest<IEnumerable<ClaimVm>>
    {
        public string ClientEmail { get; set; }
    }
}
