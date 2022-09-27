using ClothingStore.Application.Features.Orders.Commands.CreateOrder;
using ClothingStore.Application.Features.Orders.Queries.GetOrderById;
using ClothingStore.Application.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetOrderById([FromQuery] GetOrderByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
