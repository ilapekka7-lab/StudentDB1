

namespace Task
{
    internal class Program
    {
        static void Main()
        {
            using var db = new StudentDbContext();
            db.Database.EnsureCreated(); 

            string ? command;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Показать студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Изменить по ID");
                Console.WriteLine("4. Изменить по имени");
                Console.WriteLine("5. Удалить по ID");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1": ShowStudents(db); break;
                    case "2": AddStudent(db); break;
                    case "3": UpdateById(db); break;
                    case "4": UpdateByName(db); break;
                    case "5": DeleteById(db); break;
                }
            } while (command != "0");
        }

        static void ShowStudents(StudentDbContext db)
        {
            var students = db.Students.ToList();
            foreach (var s in students)
                Console.WriteLine($"{s.Id}. {s.Surname} {s.Name}, {s.Address}, {s.Gender}, {s.BirthDate:dd.MM.yyyy}");
            Console.ReadKey();
        }

        static void AddStudent(StudentDbContext db)
        {
            Console.Write("Имя: "); string? name = Console.ReadLine();
            Console.Write("Фамилия: "); string? surname = Console.ReadLine();
            Console.Write("Адрес: "); string? address = Console.ReadLine();
            Console.Write("Пол (М/Ж): "); string? gender = Console.ReadLine();
            Console.Write("Дата рождения (dd.MM.yyyy): ");
            DateTime birth = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            db.Students.Add(new Student
            { Name = name, Surname = surname, Address = address, Gender = gender, BirthDate = birth });
            db.SaveChanges();
            Console.WriteLine("Добавлен!");
            Console.ReadKey();
        }

        static void UpdateById(StudentDbContext db)
        {
            Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
            var student = db.Students.Find(id);
            if (student != null)
            {
                Console.Write("Новое имя: "); student.Name = Console.ReadLine();
                Console.Write("Новая фамилия: "); student.Surname = Console.ReadLine();
                db.SaveChanges();
                Console.WriteLine("Обновлен!");
            }
            else Console.WriteLine("Не найден!");
            Console.ReadKey();
        }

        static void UpdateByName(StudentDbContext db)
        {
            Console.Write("Имя для поиска: "); string name = Console.ReadLine();
            var student = db.Students.FirstOrDefault(s => s.Name == name);
            if (student != null)
            {
                Console.Write("Новый адрес: "); student.Address = Console.ReadLine();
                db.SaveChanges();
                Console.WriteLine("Обновлен!");
            }
            else Console.WriteLine("Не найден!");
            Console.ReadKey();
        }

        static void DeleteById(StudentDbContext db)
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
