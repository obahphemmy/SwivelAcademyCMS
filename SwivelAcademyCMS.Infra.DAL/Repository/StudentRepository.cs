using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Entities;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.Infra.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Infra.DAL.Repository
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{

		public StudentRepository(SwivelDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<Student>> GetAllStudentsWithCourse()
		{
			var students = await _dbContext.Students.Include(s => s.Courses).ThenInclude(c => c.Course).ToListAsync();
			return students;
		}

		public async Task<Student> GetStudentWithCourse(int id)
		{
			var student = await _dbContext.Students.Where(s => s.Id == id).Include(s => s.Courses).ThenInclude(c => c.Course).FirstOrDefaultAsync();
			return student;
		}
	}
}
