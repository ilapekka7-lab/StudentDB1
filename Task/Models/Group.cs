using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Group
    {
        [Key] //первичный ключ
        public int? GroupId { get; set; }

        public string? GroupName { get; set; }
    }
}
