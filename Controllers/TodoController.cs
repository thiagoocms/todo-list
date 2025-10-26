using demo.Dto;
using demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController(TodoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var list = await service.GetAllAsync();

        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var dto = await service.GetByIdAsync(id);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(TodoDto dto)
    {
        dto = await service.CreateAsync(dto);

        return Ok(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, TodoDto dto)
    {
        dto = await service.UpdateAsync(id, dto);

        return Ok(dto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        await service.DeleteByIdAsync(id);

        return NoContent();
    }
}