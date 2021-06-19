using SwivelAcademyCMS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		public IRepository<Course> Courses { get; }
		public ITeacherRepository Teachers { get; }
		public IStudentRepository Students { get; }
		public IRepository<StudentCourse> StudentCourses { get; }
		public IRepository<TeacherCourse> TeacherCourses { get; }
		Task<int> Complete();
	}
}
