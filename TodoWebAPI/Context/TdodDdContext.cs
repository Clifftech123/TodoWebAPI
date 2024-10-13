using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Models;

namespace TodoWebAPI.Context
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder. ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
        }

    }


}

