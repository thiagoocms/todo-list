using demo.Data;
using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Repositories;

public class TodoRepository(AppDbContext context)
{
    public async Task<Todo> SaveAsync(Todo todo)
    {
        if (todo.Id == 0)
        {
            context.Todos.Add(todo);
        }
        else
        {
            context.Todos.Update(todo);
        }

        await context.SaveChangesAsync();
        
        return todo;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await context.Todos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await context.Todos.FindAsync(id);
    }

    public async Task DeleteAsync(Todo todo)
    {
        context.Todos.Remove(todo);
        await context.SaveChangesAsync();
    }
}