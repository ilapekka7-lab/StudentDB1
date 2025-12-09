using Microsoft.EntityFrameworkCore;
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
                Console.WriteLine($"{s.StudentID}. {s.Surname}, {s.Name}, {s.Address}, {s.Gender?.GenderName}, {s.BirthDate:dd.MM.yyyy}");
                
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
            Console.Write("ID: ");
            var student = db.Students.Find(int.Parse(Console.ReadLine()));
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
            Console.Write("ID: "); 
            var student = db.Students.Find(int.Parse(Console.ReadLine()));
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                Console.WriteLine("Удален!");
            }
            else Console.WriteLine("Не найден!");
            Console.ReadKey();
        }

       public static void FindStudentsByGender(StudentDbContext db)
        {
            Console.WriteLine("\n🔍 Поиск студентов по полу");
            Console.Write("Введите пол (М или Ж): ");
            string? genderInput = Console.ReadLine()?.Trim().ToUpper();

            if (genderInput != "М" && genderInput != "Ж")
            {
                Console.WriteLine("❌ Введите только М или Ж!");
                Console.ReadKey();
                return;
            }

            // 1. Найди Gender по первой букве
            var gender = db.Genders
                .FirstOrDefault(g => g.GenderName.StartsWith(genderInput));

            if (gender == null)
            {
                Console.WriteLine("❌ Пол не найден!");
                Console.ReadKey();
                return;
            }

            // 2. Найди студентов с этим Gender (Include загружает связь!)
            var students = db.Students
                .Include(s => s.Gender)  // Загрузи Gender для каждого студента
                .Where(s => s.GenderId == gender.GenderId)
                .OrderBy(s => s.Surname)
                .ToList();

            // 3. Вывод результатов
            Console.WriteLine($"\n👥 Студенты ({gender.GenderName}):");
            Console.WriteLine(new string('=', 60));

            if (students.Count == 0)
            {
                Console.WriteLine("Никого не найдено.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.StudentID,3:D2}. {student.Surname,-15} {student.Name,-15} " +
                                    $"| {student.Address,-20} | {student.BirthDate:dd.MM.yyyy}");
                }
                Console.WriteLine($"\nВсего найдено: {students.Count} студентов.");
            }

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
