using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    public readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [Route("")]
    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest("Deu ruim!");
        }
    }

    [Route("")]
    [HttpGet]
    public IActionResult GetAllTodos([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var todos = repository.GetAll(user);
        return Ok(todos);
    }

    [Route("{todoId}")]
    [HttpGet]
    public async Task<IActionResult> GetTodoById([FromServices] ITodoRepository repository, Guid todoId)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var todo = await repository.GetTodoById(id: todoId, user: user);

        return Ok(todo);
    }

    [Route("Done")]
    [HttpGet]
    public IActionResult GetAllDoneTodos([FromServices] ITodoRepository repository)
    {
        var todos = repository.GetAllDone("gabriel");

        return Ok(todos);
    }

    [Route("Undone")]
    [HttpGet]
    public IActionResult GetAllUndoneTodos([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var todos = repository.GetAllUndone(user);

        return Ok(todos);
    }

    [Route("Period")]
    [HttpGet]
    public IActionResult GetTodoByPeriod(
        [FromServices] ITodoRepository repository, 
        [FromQuery] DateTime date, 
        [FromQuery] bool done
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        var todos = repository.GetByPeriod(user: user, date: date, done: done);

        return Ok(todos);
    }

    [Route("")]
    [HttpPut]
    public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommand command)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        command.User = user;

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public async Task<IActionResult> MarkTodoAsDone([FromBody] MarkTodoAsDoneCommand command)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        command.User = user;

        var reponse = await _mediator.Send(command);

        return Ok(reponse);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public async Task<IActionResult> MarkTodoAsUndone([FromBody] MarkTodoAsUndoneCommand command)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        command.User = user;

        var reponse = await _mediator.Send(command);

        return Ok(reponse);
    }
}
