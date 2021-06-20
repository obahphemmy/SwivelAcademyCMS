using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Entities;
using System.Collections.Generic;

namespace SwivelAcademyCMS.Infra.DAL.DBContext
{
	public class SwivelDbContext : DbContext
	{
		public SwivelDbContext(DbContextOptions<SwivelDbContext> options) : base(options)
		{}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }
		public DbSet<TeacherCourse> TeacherCourses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			var courses = new List<Course>()
			{
				new Course{Id = 1, Title = "Introduction to Programming Using C#", CourseUnit = 4 },
				new Course{Id = 2, Title = "Algorithms", CourseUnit = 3 },
				new Course{Id = 3, Title = "Human Computer Interaction (HCI)", CourseUnit = 2 },
				new Course{Id = 4, Title = "Compiler Construction", CourseUnit = 4 },
				new Course{Id = 5, Title = "Advanced Algebra", CourseUnit = 3 },
				new Course{Id = 6, Title = "Statistics", CourseUnit = 1 },
				new Course{Id = 7, Title = "Computer Operations", CourseUnit = 2 }
			};

			builder.Entity<Course>().HasData(courses);


			builder.Entity<Student>().HasData(new Student { Id = 1, Firstname = "James", Lastname = "Stuart" },
				new Student { Id = 2, Firstname = "Michael", Lastname = "Oyelowo" });

			builder.Entity<Teacher>().HasData(new Teacher { Id = 1, Firstname = "Adewale", Lastname = "Rowland" },
			new Teacher { Id = 2, Firstname = "Festus", Lastname = "Emeka" });


			builder.Entity<StudentCourse>().HasData(new StudentCourse { Id = 1, CourseId = 1, StudentId = 1 },
				new StudentCourse {Id = 2, CourseId = 2, StudentId = 1 },
				new StudentCourse { Id = 3, CourseId = 3, StudentId = 1 },
				new StudentCourse { Id = 4, CourseId = 5, StudentId = 2 },
				new StudentCourse { Id = 5, CourseId = 6, StudentId = 2 },
				new StudentCourse { Id = 6, CourseId = 4, StudentId = 2 });

			builder.Entity<TeacherCourse>().HasData(new TeacherCourse {Id = 1, CourseId = 1, TeacherId = 1 },
				new TeacherCourse { Id = 2, CourseId = 2, TeacherId = 1 },
				new TeacherCourse { Id = 3, CourseId = 3, TeacherId = 1 },
				new TeacherCourse { Id = 4, CourseId = 5, TeacherId = 2 },
				new TeacherCourse { Id = 5, CourseId = 6, TeacherId = 2 },
				new TeacherCourse { Id = 6, CourseId = 4, TeacherId = 2 });

			base.OnModelCreating(builder);
		}
	}
}
