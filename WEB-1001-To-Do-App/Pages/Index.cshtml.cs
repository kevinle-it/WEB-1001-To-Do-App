using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_1001_To_Do_DB_Context;
using WEB_1001_To_Do_Models;

namespace WEB_1001_To_Do_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // The ToDoDBContext used to access to ToDoDb for doing data manipulation
        private readonly ToDoDBContext _db;

        // To Do item used for "Add new To Do" form
        [FromForm]
        public ToDo todo { get; set; }

        // ToDoList used for showing all incomplete To-Do list on Home page
        public ICollection<ToDo> ToDoList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        // Retrieve a list of incomplete To Dos from ToDoDb to show them on Home page
        public void OnGet()
        {
            ToDoList = _db.ToDos.Where(item => item.IsCompleted == false).ToList();
        }

        // Handle on click Add To-Do button to add new to do item
        public async Task<IActionResult> OnPost()
        {
            _db.Add<ToDo>(todo);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        // Handle on Checkbox change to mark a To Do item as completed
        public async Task<IActionResult> OnPostComplete([FromQuery] int Id)
        {
            ToDo item = _db.ToDos.FirstOrDefault(item => item.Id == Id);
            item.IsCompleted = true;
            item.CompletionDate = DateTime.Now;
            _db.Entry(item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
