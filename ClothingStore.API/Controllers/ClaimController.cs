using ClothingStore.Application.Features.Claims.Commands.CreateClaim;
using ClothingStore.Application.Features.Claims.Queries.GetClaimByClientEmail;
using ClothingStore.Application.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClaimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimVm>>> GetClaimByClientEmail([FromQuery] GetClaimByClientEmailQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateClaim([FromBody] CreateClaimCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
