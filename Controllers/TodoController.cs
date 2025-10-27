using demo.Dto;
using demo.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace demo.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController(TodoService service) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todas as tarefas",
        Description = "Retorna uma lista completa de todas as tarefas registradas no sistema."
    )]
    [SwaggerResponse(200, "Lista de tarefas retornada com sucesso.", typeof(IEnumerable<TodoDto>))]
    public async Task<IActionResult> GetAllAsync()
    {
        var list = await service.GetAllAsync();

        return Ok(list);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Busca uma tarefa pelo ID",
        Description = "Retorna os detalhes de uma tarefa específica através do seu identificador numérico."
    )]
    [SwaggerResponse(200, "Tarefa encontrada.", typeof(TodoDto))]
    [SwaggerResponse(404, "Tarefa não encontrada.")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var dto = await service.GetByIdAsync(id);

        return Ok(dto); 
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Cria uma nova tarefa",
        Description = "Registra uma nova tarefa no sistema com base nos dados fornecidos."
    )]
    [SwaggerResponse(201, "Tarefa criada com sucesso.", typeof(TodoDto))]
    [SwaggerResponse(400, "Dados inválidos.")]
    public async Task<IActionResult> CreateAsync([FromBody] TodoDto dto)
    {
        dto = await service.CreateAsync(dto);

        return Ok(dto);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(
        Summary = "Atualiza uma tarefa existente",
        Description = "Atualiza os dados de uma tarefa previamente registrada."
    )]
    [SwaggerResponse(200, "Tarefa atualizada com sucesso.", typeof(TodoDto))]
    [SwaggerResponse(404, "Tarefa não encontrada.")]
    [SwaggerResponse(400, "Dados inválidos.")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] TodoDto dto)
    {
        dto = await service.UpdateAsync(id, dto);

        return Ok(dto);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(
        Summary = "Remove uma tarefa",
        Description = "Exclui permanentemente uma tarefa existente pelo seu identificador."
    )]
    [SwaggerResponse(204, "Tarefa removida com sucesso.")]
    [SwaggerResponse(404, "Tarefa não encontrada.")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
    {
        await service.DeleteByIdAsync(id);

        return NoContent();
    }
}