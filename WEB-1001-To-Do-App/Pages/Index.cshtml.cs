using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            ToDoList = _db.ToDos.Select(item => item).ToList();
        }

        public void OnPost()
        {
            _db.Add<ToDo>(todo);
            _db.SaveChangesAsync();
        }
    }
}
