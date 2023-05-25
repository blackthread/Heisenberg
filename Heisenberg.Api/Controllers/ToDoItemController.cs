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
          //  var dtos = await _mediator.Send(new GetToDoItemListQuery());
            var x = new List<ToDoItemVm>();
            x.Append(new ToDoItemVm { Id = 1, Description = "Test" });
            x.Append(new ToDoItemVm { Id = 2, Description = "Test2" });
            return Ok(x);
        }
    }
}
