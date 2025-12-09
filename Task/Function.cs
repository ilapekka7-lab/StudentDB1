using Task.Models;

namespace Task
{
    

   public static class CRUDOperationStudent
    {
        /// <summary>
        /// Получить всех студентов
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        public static void ShowStudents(StudentDbContext db)
        {
            var students = db.Students.ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentID}. {s.Surname} {s.Name}, {s.Address}, {s.Gender?.GenderName}, {s.BirthDate:dd.MM.yyyy}");
                
            }
            Console.ReadKey();
        }

        public static void AddStudent(StudentDbContext db)
        {
            var student = new Student();
            Console.Write("Имя: ");
            student.Name = Console.ReadLine();

            Console.Write("Фамилия: ");
            student.Surname = Console.ReadLine();

            Console.Write("Адрес: ");
            student.Address = Console.ReadLine();

            Console.Write("Пол (М/Ж): ");
            string gender = Console.ReadLine(); 
            var selectedGender = db.Genders.FirstOrDefault(g => g.GenderName == gender); // поиск гендера по его имени
            student.Gender = selectedGender; 

            Console.Write("Дата рождения (dd.MM.yyyy): ");
            DateTime birth = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
            student.BirthDate = birth;

            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("Добавлен!");
            Console.ReadKey();
        }

        public static void UpdateById(StudentDbContext db)
        {
            Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
            var student = db.Students.Find(id);
            if (student != null)
            {
                Console.Write("Новое имя: ");
                student.Name = Console.ReadLine();

                Console.Write("Новая фамилия: ");
                student.Surname = Console.ReadLine();

                Console.Write("Новый Адрес: ");
                student.Address = Console.ReadLine();

                Console.Write("Пол (М/Ж): ");
                string? gender = Console.ReadLine();
                var selectedGender = db.Genders.FirstOrDefault(g => g.GenderName == gender); // поиск гендера по его имени
                student.Gender = selectedGender;

                Console.Write("Дата рождения (dd.MM.yyyy): ");
                student.BirthDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);
               

                Console.Write("");
                db.SaveChanges();
                Console.WriteLine("Обновлен!");
            }
            else Console.WriteLine("Не найден!");
            Console.ReadKey();
        }

        //public static void UpdateByName(StudentDbContext db)
        //{
        //    Console.Write("Имя для поиска: ");
        //    string? name = Console.ReadLine();
        //    var student = db.Students.FirstOrDefault(s => s.Name == name);
        //    if (student != null)
        //    {

        //        Console.Write("Новый адрес: ");
        //        student.Address = Console.ReadLine();
        //        db.SaveChanges();
        //        Console.WriteLine("Обновлен!");
        //    }
        //    else Console.WriteLine("Не найден!");
        //    Console.ReadKey();
        //}

        public static void DeleteById(StudentDbContext db)
        {
            Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
            var student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                Console.WriteLine("Удален!");
            }
            else Console.WriteLine("Не найден!");
            Console.ReadKey();
        }
    }
}
