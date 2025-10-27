using demo.Dto;
using demo.Models;

namespace demo.Mappers;

public class TodoMapper
{
    public static TodoDto ToDto(Todo todo) => new()
    {
        Id = todo.Id,
        Title = todo.Title,
        Checked = todo.Checked
    };

    public static Todo ToEntity(TodoDto dto) => new(dto.Title)
    {
        Id = dto.Id,
        Checked = dto.Checked
    };
}