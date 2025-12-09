using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Student
    {
        public int StudentID { get; set; }  
        
        public string Name { get; set; } = string.Empty;
       
        public string Surname { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }


        [ForeignKey(nameof(Gender))]      
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
    }
}
