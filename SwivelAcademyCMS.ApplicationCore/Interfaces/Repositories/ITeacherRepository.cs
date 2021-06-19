using SwivelAcademyCMS.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories
{
	public interface ITeacherRepository : IRepository<Teacher>
	{
		Task<Teacher> GetTeacherWithCourse(int id);
		Task<IEnumerable<Teacher>> GetAllTeachersWithCourse();
	}
}
