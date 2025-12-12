using Microsoft.EntityFrameworkCore;
using Task.Models;
namespace Task
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=students.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasOne(s => s.Gender)
            .WithMany()
            .HasForeignKey(s => s.GenderId);

            modelBuilder.Entity<Student>()
           .HasOne(s => s.Group)
           .WithMany()
           .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Gender>().HasData(
           new Gender { GenderId = 1, GenderName = "Мужской" },
           new Gender { GenderId = 2, GenderName = "Женский" });

            modelBuilder.Entity<Group>().HasData(
            new Group { GroupId = 1, GroupName = "Математики" },
            new Group { GroupId = 2, GroupName = "Гуманитарии" });
        }
    }
}
