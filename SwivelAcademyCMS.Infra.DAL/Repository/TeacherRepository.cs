using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Entities;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.Infra.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Infra.DAL.Repository
{
	public class TeacherRepository : Repository<Teacher>, ITeacherRepository
	{
		public TeacherRepository(SwivelDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<Teacher>> GetAllTeachersWithCourse()
		{
			var teachers = await _dbContext.Teachers.Include(s => s.Courses).ThenInclude(c => c.Course).ToListAsync();
			return teachers;
		}

		public async Task<Teacher> GetTeacherWithCourse(int id)
		{
			var teacher = await _dbContext.Teachers.Where(s => s.Id == id).Include(s => s.Courses).ThenInclude(c => c.Course).FirstOrDefaultAsync();
			return teacher;
		}
	}
}
