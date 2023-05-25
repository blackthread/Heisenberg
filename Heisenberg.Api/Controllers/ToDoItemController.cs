using Heisenberg.Application.Features.ToDoItems.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Heisenberg.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : Controller
    {
        private readonly IMediator _mediator;

        public ToDoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllToDoItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ToDoItemVm>>> GetAllToDoItems()
        {
            var dtos = await _mediator.Send(new GetToDoItemListQuery());
            return Ok(dtos);
        }
    }
}
