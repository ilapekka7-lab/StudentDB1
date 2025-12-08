

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
                    case "1": CRUDOperationStudent.ShowStudents(db); break;
                    case "2": CRUDOperationStudent.AddStudent(db); break;
                    case "3": CRUDOperationStudent.UpdateById(db); break;
                    case "4": CRUDOperationStudent.UpdateByName(db); break;
                    case "5": CRUDOperationStudent.DeleteById(db); break;
                    default: Console.WriteLine("Ошибка ввода"); break;
                }
            } while (command != "0");




        }

      
    }
}
