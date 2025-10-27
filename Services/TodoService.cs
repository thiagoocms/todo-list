using demo.Dto;
using demo.Mappers;
using demo.Models;
using demo.Repositories;

namespace demo.Services;

public class TodoService(TodoRepository repository)
{
    public async Task<TodoDto> CreateAsync(TodoDto dto)
    {
        var todo = TodoMapper.ToEntity(dto);

        await repository.SaveAsync(todo);

        return TodoMapper.ToDto(todo);
    }

    public async Task<TodoDto> UpdateAsync(int id, TodoDto dto)
    {
        var todo = await GetCheckByIdAsync(id);

        todo.Title = dto.Title;
        todo.Checked = dto.Checked;

        await repository.SaveAsync(todo);

        return TodoMapper.ToDto(todo);
    }

    public async Task DeleteByIdAsync(int id)
    {
        var todo = await GetCheckByIdAsync(id);

        await repository.DeleteAsync(todo);
    }

    public async Task<List<TodoDto>> GetAllAsync()
    {
        var todos = await repository.GetAllAsync();

        return todos.Select(TodoMapper.ToDto).ToList();
    }

    public async Task<TodoDto> GetByIdAsync(int id)
    {
        var todo = await GetCheckByIdAsync(id);

        return TodoMapper.ToDto(todo);
    }

    private async Task<Todo> GetCheckByIdAsync(int id)
    {
        var todo = await repository.GetByIdAsync(id);

        return todo ?? throw new BadHttpRequestException("item não encontrado");
    }
}