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
        private readonly ToDoDBContext _db;

        [FromForm]
        public ToDo todo { get; set; }

        public ICollection<ToDo> ToDoList { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            ToDoList = _db.ToDos.Where(item => item.IsCompleted == false).ToList();
        }

        public IActionResult OnPost()
        {
            _db.Add<ToDo>(todo);
            _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        public IActionResult OnPostComplete([FromQuery] int Id)
        {
            ToDo item = _db.ToDos.FirstOrDefault(item => item.Id == Id);
            item.IsCompleted = true;
            item.CompletionDate = DateTime.Now;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
