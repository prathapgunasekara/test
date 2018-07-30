using Microsoft.EntityFrameworkCore;
using WebApplication1.Common.Models;

namespace WebApplication1.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todoitem> TodoItems { get; set; }
    }
}
