using Microsoft.EntityFrameworkCore;
using System;
using WEB_1001_To_Do_Models;

namespace WEB_1001_To_Do_DB_Context
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions<ToDoDBContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
