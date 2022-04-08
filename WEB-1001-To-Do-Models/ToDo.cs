using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_1001_To_Do_Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? CompletionDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
