using SwivelAcademyCMS.ApplicationCore.Entities;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.Infra.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Infra.DAL.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SwivelDbContext _dbContext;

		public IRepository<Course> Courses { get; private set; }

		public IStudentRepository Students { get; private set; }

		public ITeacherRepository Teachers { get; private set; }
		public IRepository<StudentCourse> StudentCourses { get; private set; }
		public IRepository<TeacherCourse> TeacherCourses { get; private set; }

		public UnitOfWork(IRepository<Course> courseRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository, IRepository<StudentCourse> studentCourseRepository, SwivelDbContext dbContext, IRepository<TeacherCourse> teacherCourseRepository)
		{
			Courses = courseRepository;
			Students = studentRepository;
			Teachers = teacherRepository;
			StudentCourses = studentCourseRepository;
			_dbContext = dbContext;
			TeacherCourses = teacherCourseRepository;
		}


		public async Task<int> Complete()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}

