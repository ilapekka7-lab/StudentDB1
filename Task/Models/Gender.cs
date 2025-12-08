using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Gender
    {
        [Key] // первичный ключ
        public int? GenderId { get; set; }
        [MaxLength(5)] //максимальная длина поля в таблице
        public string? GenderName { get; set; }
    }
}
