using Microsoft.EntityFrameworkCore;
using System;
using WEB_1001_To_Do_Models;

namespace WEB_1001_To_Do_DB_Context
{
    // The DB Context to use inside Index Page Model
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options) { }

        // This DB has one table named "ToDos"
        public DbSet<ToDo> ToDos { get; set; }
    }
}
