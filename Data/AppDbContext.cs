using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=demo.db");
    }

    public DbSet<Todo> Todos { get; set; }
}