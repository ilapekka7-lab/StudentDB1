using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Student
    {
        public int StudentID { get; set; }  

        
        public string Name { get; set; } = string.Empty;

       
        public string Surname { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;  

        public DateTime BirthDate { get; set; }
    }
}
